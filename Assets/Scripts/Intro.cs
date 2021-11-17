using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
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
    }
}
