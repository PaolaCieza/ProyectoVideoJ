using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flotante : MonoBehaviour
{
    public float TiempoDeVida = 2;

    // public float inicioDeVida = 3;

    void Start()
    {
        // this.enabled=false;
        
    }

    // Update is called once per frame
    void Update(){

        // inicioDeVida -= Time.deltaTime;
        //     Debug.Log("Inicio de vida");
        // if(inicioDeVida <= 0){
        //     this.gameObject.SetActive(true);
        // }

        TiempoDeVida -= Time.deltaTime;
        if (TiempoDeVida <= 0)
        {
            // this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }




}
