using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AimPostProcessing : MonoBehaviour {
    private Material material;
	// Use this for initialization
	void Start () {
        material = new Material(Shader.Find("Custom/ShaderQ2"));

    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }


}
