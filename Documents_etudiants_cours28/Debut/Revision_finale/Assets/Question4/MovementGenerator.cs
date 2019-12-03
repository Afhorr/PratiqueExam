using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovementGenerator : MonoBehaviour {

    public int mapWidth = 256;
    public float noiseScale;
    public int octaves;
    [Range(0, 1)]
    public float persistance;
    public float lacunarity;
    public bool autoUpdate;
    public int seed;
    public Vector2 offset;

    public int maxNumberOfFishes = 100;
    private float timeLastUpdate;

    private float[,] noiseMapX;
    private float[,] noiseMapY;
    private void Start() {
        
        timeLastUpdate = Time.time;
    }

    private void Update() {
        foreach (Fish fish in FindObjectsOfType<Fish>()) {
            //Code pour le mouvement des poissons
           

        }
        if (Time.time - timeLastUpdate > 5) {
            //Code pour nouveau mouvement
           
            timeLastUpdate = Time.time;
        }
       
    }
    


    private void OnValidate() {
        if (mapWidth < 1) {
            mapWidth = 1;
        }
        if (lacunarity < 1) {
            lacunarity = 1;
        }
        if (octaves < 0) {
            octaves = 0;
        }

    }


}

