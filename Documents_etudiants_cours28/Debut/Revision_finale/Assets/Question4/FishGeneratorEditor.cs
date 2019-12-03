using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof (FishGenerator))]
public class FishGeneratorEditor : Editor {

  
    public override void OnInspectorGUI() {
        FishGenerator fishGen = (FishGenerator)target;
        if (DrawDefaultInspector()) {
            if (fishGen.autoUpdate) {
                fishGen.GenerateFishes();
            }
        }
        if (GUILayout.Button("Generator")) {
            fishGen.GenerateFishes();
        }
    }
   
}
#endif

