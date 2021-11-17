using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    // private void juegoPausado = false;

    public void Pausa(){
        // juegoPausado = true;
        Time.timeScale = 0;   
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reanudar(){
        // juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    // public void Reiniciar(){
    //     Time.timeScale = 1f;
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }
    public void Inicio(){
        SceneManager.LoadScene("Inicio");
    }

    public void Cerrar(){
        Debug.Log("Cerrando juego");
        Application.Quit();
    }

}
