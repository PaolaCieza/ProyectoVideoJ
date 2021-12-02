using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractTiempo : MonoBehaviour
{
    ControlarTiempo controlarTiempo;

    void Start()
    {
        controlarTiempo = GameObject.FindGameObjectWithTag("tiempo").GetComponent<ControlarTiempo>();

    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            controlarTiempo.tiempoMostrar += 10;
            Destroy(gameObject);
        }
    }
}
