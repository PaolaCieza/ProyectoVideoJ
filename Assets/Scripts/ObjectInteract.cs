using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    Inventario inventario;

    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();

    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            inventario.Cantidad = inventario.Cantidad +6;
            inventario.textBalas.text = "= " + inventario.Cantidad;
            Destroy(gameObject);
        }
    }
}
