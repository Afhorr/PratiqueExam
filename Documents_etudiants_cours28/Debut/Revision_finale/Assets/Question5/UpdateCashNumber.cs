using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCashNumber : MonoBehaviour {
    private PlayerAction playerAction;
    private Text cashNumberText;

    private void Start() {
        playerAction = FindObjectOfType<PlayerAction>();
        cashNumberText = GetComponent<Text>();
    }

    void Update() {
        cashNumberText.text = "Argent : " + (int)playerAction.GetAvailableCash();
    }
}
