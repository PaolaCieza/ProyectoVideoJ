using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flotante : MonoBehaviour
{
    public float TiempoDeVida = 2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        TiempoDeVida -= Time.deltaTime;
        if (TiempoDeVida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
