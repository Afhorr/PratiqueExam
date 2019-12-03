Shader "Custom/LavaShader" {
	Properties {
		_RGBLAVATEXT("RGB", 2D) = "white" {}
		_RGBLAVASPEED("RGB Lava speed", Range(0,10)) = 2
		_GROUNDLAVATEXT("Ground", 2D) = "white" {}
		_Tess("Tessellation", Range(1,32)) = 4
		_Displacement("Displacement", Range(0, 1.0)) = 0.3
		_DispTex("Disp Texture", 2D) = "gray" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:disp tessellate:tessDistance nolightmap

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 4.6
		#include "Tessellation.cginc"
		sampler2D _RGBLAVATEXT;
		sampler2D _GROUNDLAVATEXT;
		sampler2D _DispTex;

		struct Input {
			float2 uv_GROUNDLAVATEXT;
			float2 uv_RGBLAVATEXT;
		};

		half _Glossiness;
		half _Metallic;
		half _RGBLAVASPEED;
		float _Displacement;

		struct appdata {
			float4 vertex : POSITION;
			float4 tangent : TANGENT;
			float3 normal : NORMAL;
			float2 texcoord : TEXCOORD0;
		};
		float _Tess;

		float4 tessDistance(appdata v0, appdata v1, appdata v2) {
			float minDist = 10.0;
			float maxDist = 25.0;
			return UnityDistanceBasedTess(v0.vertex, v1.vertex, v2.vertex, minDist, maxDist, _Tess);
		}
		void disp(inout appdata v)
		{
			fixed2 scrolledWave = v.texcoord.xy * 0.2;
			fixed xScrollValue = _RGBLAVASPEED * _Time;
			fixed yScrollValue = _RGBLAVASPEED * _Time;
			scrolledWave += fixed2(0.5 * xScrollValue, 0.5 * yScrollValue);
			float d = tex2Dlod(_DispTex, float4(scrolledWave, 0, 0)).rgb * _Displacement;
			v.vertex.xyz += v.normal * d;
		}
		UNITY_INSTANCING_BUFFER_START(Props)
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed2 scrolledUV = IN.uv_RGBLAVATEXT;
			fixed2 scrolledUV2 = IN.uv_RGBLAVATEXT;
			fixed xScrollValue = _RGBLAVASPEED * _Time;
			fixed yScrollValue = _RGBLAVASPEED * _Time;

			scrolledUV += fixed2(xScrollValue, yScrollValue);
			scrolledUV2 += fixed2(0.05 * xScrollValue, 0.05 * yScrollValue);
			fixed4 c = tex2D(_GROUNDLAVATEXT, scrolledUV2);
			fixed4 a = tex2D(_RGBLAVATEXT, scrolledUV);
			fixed4 b = tex2D(_RGBLAVATEXT, scrolledUV2);
			o.Albedo = a.rgb * b.rgb;
			o.Albedo -= c.rgb * 2.5;

			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = 255;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
