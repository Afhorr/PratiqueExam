using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LayTrap : MonoBehaviour {
    public float reloadTime = 5;
    private float lastActivationTime;
    public GameObject trap;

    private void Start() {
        if(trap == null) {
            print("Le prefab du piege n'est défini");
        }
    }

    void Update() {
        if (Input.GetAxis("Fire1") > 0) {
            FireTrap();
        }
	}


    private void FireTrap() {
        if (CanFireTrap()) {
            GameObject newTrap = Instantiate(trap, gameObject.transform.position, Quaternion.identity);
            newTrap.GetComponent<Trap>().SetOwner(gameObject);
            lastActivationTime = Time.time;
        }
    }

    private bool CanFireTrap() {
        if ((Time.time - lastActivationTime)< reloadTime) {
            return false;
        }
        return true;
    }

    
}
