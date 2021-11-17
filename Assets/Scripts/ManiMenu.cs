using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManiMenu : MonoBehaviour
{
    [SerializeField] private GameObject cooperativo;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject menucooperativo;
    [SerializeField] private GameObject menucooperativoescena;
    public void EscenaJuego(){
        SceneManager.LoadScene("Intro");
    }

    public void CargarNivel(string nombreNivel){
        SceneManager.LoadScene(nombreNivel);
    }

    public void Multijugador(){
        menu.SetActive(false);
        menucooperativo.SetActive(true);
    }

    public void MultijugadorEscena(){
        menu.SetActive(false);
        menucooperativo.SetActive(false);
        menucooperativoescena.SetActive(true);
    }

    public void cooperativoFabrica(){
        SceneManager.LoadScene("MultijugadorFabrica");
    }

    public void cooperativoCampo(){
        SceneManager.LoadScene("MultijugadorCampo");
    }

    public void Salir(){
        Application.Quit();
    }

    public void SalirMultiplayer(){
        menu.SetActive(true);
        menucooperativo.SetActive(false);
    }
     public void SalirMultiplayerEscena(){
        menu.SetActive(false);   
        menucooperativo.SetActive(true);
        menucooperativoescena.SetActive(false);
    }

    
}
