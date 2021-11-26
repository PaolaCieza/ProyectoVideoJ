using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    // public float tiempo_start; 
    // public float tiempo_end; 
    private AudioSource sonido;
    public AudioClip llamada;

    void Start()
    {
        sonido = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            sonido.clip = llamada;
            sonido.Play();
            
        }

        // tiempo_start += Time.deltaTime;
        // if (tiempo_start >= tiempo_end) 
        // {
        //     Application.LoadLevel("Nivell 1");
        // }

    }
}
