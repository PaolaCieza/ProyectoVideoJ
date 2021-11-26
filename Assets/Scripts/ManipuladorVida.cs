using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManipuladorVida : MonoBehaviour
{
    VidaPlayer playerVida;

    public Animator animacion;
    public int cantidad;
    public float damageTime;
    float currentDamageTime;

    [SerializeField] private GameObject mensajeMuerte;
    // [SerializeField] private GameObject botonreiniciar;
    void Start()
    {
        playerVida = GameObject.FindWithTag("Player").GetComponent<VidaPlayer>();
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player"){
            currentDamageTime += Time.deltaTime;
            if(currentDamageTime > damageTime){
                playerVida.vida += cantidad;
                currentDamageTime = 0.0f;
            }
        }
    }

    void Update(){
        if(playerVida.vida <= 0){
            animacion.SetTrigger("Dead");
            mensajeMuerte.SetActive(true);

        } 
        Debug.Log(playerVida.vida);
    }

    void muerte(){
        mensajeMuerte.SetActive(true);
    }

    public void reiniciarentrecomillar(){
        SceneManager.LoadScene("Nivel 2");
    }

}
