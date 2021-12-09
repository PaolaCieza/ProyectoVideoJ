using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public float tiempo_start; 
    public float tiempo_end; 
    private AudioSource sonido;
    public AudioClip llamada;
    public Animator animacion;  

    void Start()
    {
        sonido = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            sonido.clip = llamada;
            sonido.Play();
            animacion.SetTrigger("Neutro");
        }

        tiempo_start += Time.deltaTime;
        if (tiempo_start >= tiempo_end) 
        {
            SceneManager.LoadScene("Nivel 2");
        }

    }
}
