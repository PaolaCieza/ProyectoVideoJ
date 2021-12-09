using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject textoBalas;
    [SerializeField] private GameObject textoBotiquin;
    [SerializeField] private GameObject textoTiempo;
    [SerializeField] private GameObject textoMuertes;
    [SerializeField] private GameObject barraVida;


    public Scene scene;
    // public string nombreNivelReiniciar;
    // private void juegoPausado = false;

    private void Start() {
        scene = SceneManager.GetActiveScene();
    }
    public void Pausa(){
        // juegoPausado = true;
        Time.timeScale = 0;   
        botonPausa.SetActive(false);
        textoBalas.SetActive(false);
        textoBotiquin.SetActive(false);
        textoTiempo.SetActive(false);
        textoMuertes.SetActive(false);
        barraVida.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reanudar(){
        // juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        textoBalas.SetActive(true);
        textoBotiquin.SetActive(true);
        textoTiempo.SetActive(true);
        textoMuertes.SetActive(true);
        barraVida.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Reiniciar(){
        SceneManager.LoadScene(scene.buildIndex);
        Reanudar();
    }
    public void Inicio(){
        SceneManager.LoadScene(0);
        Debug.Log("holi giles");
    }
    public void VolverACasa(){
        SceneManager.LoadScene("Inicio");
        Debug.Log("llevar a inicio");
    }


    public void Cerrar(){
        Debug.Log("Cerrando juego");
        Application.Quit();
    }

}
