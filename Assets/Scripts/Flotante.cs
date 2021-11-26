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



// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class tiempo : MonoBehaviour
// {
//     // public float tiempo_start; //Los segundos por los quales comienza i la variable que utilizaremos para que vaya contando segundos.
//     public float tiempo_end; //Segundos que queremos que pasen para que cambie de escena
//                              // Update is called once per frame
//     void Update()
//     {
//         tiempo_start += Time.deltaTime;//Función para que la variable tiempo_start vaya contando segundos.
//         if (tiempo_start >= tiempo_end) //Si pasan los segundos que hemos puesto antes...
//         {
//             Application.LoadLevel("AquíEscribísElnombredelaEscena");
//         }
//     }
// }
