using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGoldPrice : MonoBehaviour {
    PriceManager priceManager;
    Text goldPriceText;
    // Use this for initialization
    void Start() {
        priceManager = FindObjectOfType<PriceManager>();
        goldPriceText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        goldPriceText.text = "Or : " + priceManager.GetGoldPrice();
    }
}
