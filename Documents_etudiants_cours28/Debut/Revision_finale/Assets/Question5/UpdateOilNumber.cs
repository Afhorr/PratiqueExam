using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateOilNumber : MonoBehaviour {
    private PlayerAction playerAction;
    private Text oilNumberText;

    private void Start() {
        playerAction = FindObjectOfType<PlayerAction>();
        oilNumberText = GetComponent<Text>();
    }

    void Update() {
        oilNumberText.text = "Pétrole : " + playerAction.GetOilNumber();
    }
}
