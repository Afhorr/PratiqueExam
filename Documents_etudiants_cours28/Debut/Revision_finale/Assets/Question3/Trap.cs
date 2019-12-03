using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trap : MonoBehaviour {
    private GameObject owner;
    public Renderer rend;

   

    public void SetOwner(GameObject newOwner) {
        owner = newOwner;
        /*
         *  rend = GetComponent<Renderer>();
            rend.enabled = false;
            ou
            rend.enabled = true;


         */
        
    }

    public void Triggertrap(Collider2D collision) {

        print("Faire du dégat");
        Destroy(gameObject);
    }

    private bool TrapShouldTrigger(Collider2D collision) {
        if (collision.gameObject == owner) {
            return false;
        }
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
    
        if (TrapShouldTrigger(collision)) {
            Triggertrap(collision);
        }
        
    }

}
