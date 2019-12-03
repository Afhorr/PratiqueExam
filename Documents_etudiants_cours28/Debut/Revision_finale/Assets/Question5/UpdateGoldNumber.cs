using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGoldNumber : MonoBehaviour {
  
    private PlayerAction playerAction;
    private Text goldNumberText;

    private void Start() {
        playerAction = FindObjectOfType<PlayerAction>();
        goldNumberText = GetComponent<Text>();   
    }


    void Update() {
        goldNumberText.text = "Or : " + playerAction.GetGoldNumber();
    }
}
