using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlarTiempo : MonoBehaviour
{
    public Animator animacion;  
    public Text txtReloj;
    public int tiempo;
    public float tiempoSegundo = 0f;
    public float tiempoMostrar = 0f;
    private float timer;

    [SerializeField] private GameObject mensajeMuerte;

    // Start is called before the first frame update
    void Start()
    {
        tiempoMostrar = tiempo;
    }

    // Update is called once per frame
    void Update()
    {
        // Reloj
        tiempoSegundo = Time.deltaTime * 1;
        tiempoMostrar -=  tiempoSegundo;
        ActualizarReloj( tiempoMostrar );
    }

    void ActualizarReloj(float tiempo){
        int minutos = 0;
        int segundos = 0;
        string texto = "";

        if(tiempo <= 0) GameOver();
        else{
            minutos = (int) tiempo / 60;
            segundos = (int) tiempo % 60;
    
            texto = minutos.ToString("00") + ":" + segundos.ToString("00");
    
            txtReloj.text = texto;
        }

        
    }

    void GameOver(){
        animacion.SetTrigger("Dead");
        mensajeMuerte.SetActive(true);
    }

    void muerte(){
        mensajeMuerte.SetActive(true);
    }

public void reiniciarentrecomillar(){
        SceneManager.LoadScene("Nivel 2");
        
    }

}
