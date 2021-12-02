using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorEscena : MonoBehaviour
{
    // public string nombreNivelReiniciar;
    // public string nombreNivel;
    // public void CargarNivel(){
    //     SceneManager.LoadScene(nombreNivel);
    // }

    // private void OnTriggerEnter(Collider other) {
    //     if(other.tag == "Player"){
    //         this.CargarNivel();
    //     }
    // }


    private int nivel;
    public Scene scene;

    private void Start() {
        scene = SceneManager.GetActiveScene();
        nivel = scene.buildIndex + 1;
    }
    public void CargarNivel(){
        SceneManager.LoadScene(nivel);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            this.CargarNivel();
        }
    }


}

