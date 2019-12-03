using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceManager : MonoBehaviour {
    public int mapWidth = 256;
    public float noiseScale;
    public int octaves;
    [Range(0, 1)]
    public float persistance;
    public float lacunarity;
    public bool autoUpdate;
    public int seed;
    public Vector2 offset;
    // Use this for initialization

    private float oilPrice;
    private float goldPrice;

    private float[,] noiseMapOil;
    private float[,] noiseMapGold;

    void Start () {
        noiseMapOil = Noise.GenerateNoiseMap(mapWidth, mapWidth, seed, noiseScale, octaves, persistance, lacunarity, offset);
        noiseMapGold = Noise.GenerateNoiseMap(mapWidth, mapWidth, seed+1, noiseScale, octaves, persistance, lacunarity, offset);
        GenerateGoldPrice();
        GenerateOilPrice();
    }
	
	// Update is called once per frame
	void Update () {
        GenerateGoldPrice();
        GenerateOilPrice();
    }

    private void GenerateGoldPrice() {
        goldPrice = noiseMapGold[Time.frameCount/60 % mapWidth, Time.frameCount / 60 % mapWidth]*1000;
    }

    private void GenerateOilPrice() {
        oilPrice = noiseMapOil[Time.frameCount / 60 % mapWidth, Time.frameCount / 60 % mapWidth]*100;
    }

    public float GetOilPrice() {
        return oilPrice;
    }

    public float GetGoldPrice() {
        return goldPrice;
    }
}
