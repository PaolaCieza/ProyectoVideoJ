using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorBalaSon : MonoBehaviour
{
    private AudioSource sonido;
    public AudioClip sonidobala;    
    void Start()
    {        
        sonido = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){                        
            sonido.clip = sonidobala;
            sonido.Play();            
        }
    }
}
