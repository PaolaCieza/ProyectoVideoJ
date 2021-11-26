using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractBotiquin : MonoBehaviour
{
    InventarioBotiquin inventarioBotiquin;

    void Start()
    {
        inventarioBotiquin = GameObject.FindGameObjectWithTag("Player").GetComponent<InventarioBotiquin>();

    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            inventarioBotiquin.CantidadBotiquin = inventarioBotiquin.CantidadBotiquin +1;
            inventarioBotiquin.textBotiquin.text = "= " + inventarioBotiquin.CantidadBotiquin;
            Destroy(gameObject);
        }
    }
}
