using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateOilPrice : MonoBehaviour {

    PriceManager priceManager;
    Text oilPriceText;
    // Use this for initialization
    void Start() {
        priceManager = FindObjectOfType<PriceManager>();
        oilPriceText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        oilPriceText.text = "Pétrole : " + (int)priceManager.GetOilPrice();
    }
}
