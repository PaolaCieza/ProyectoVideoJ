using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManipuladorVida : MonoBehaviour
{    
    private string vidaPrefsName = "Vida";
    //LLamando a los script de vida y el inventario del botiquin  
    InventarioBotiquin inventarioBotiquin;
    VidaPlayer playerVida;

    // private AudioSource sonido;
    // public AudioClip sonidomensajemuerte;
    public Animator animacion;
    public int cantidad;
    public float damageTime;
    float currentDamageTime;
    

    [SerializeField] private GameObject mensajeMuerte;

    private void Awake() {
        playerVida = GameObject.FindWithTag("Player").GetComponent<VidaPlayer>();
    }

    void Start()
    {
        inventarioBotiquin = GameObject.FindGameObjectWithTag("Player").GetComponent<InventarioBotiquin>();

        // sonido = GetComponent<AudioSource>();        
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

            // sonido.clip = sonidomensajemuerte;
            // sonido.Play();
        }        

        if(Input.GetKeyDown(KeyCode.L)){
            if(inventarioBotiquin.CantidadBotiquin >= 1){
                inventarioBotiquin.CantidadBotiquin --;
                actualizarVidas(10);
            }
        }
    }

    void muerte(){
        mensajeMuerte.SetActive(true);
        
    }

    public void reiniciarentrecomillar(){

        /** PRUEBAS **/
        /* PlayerPrefs.SetFloat(vidaPrefsName, 100f); */
        /** FIN **/        
        
        SceneManager.LoadScene("Nivel 2");
    }


    public void actualizarVidas(int valor) {

        switch(playerVida.vida) {
            case 100: 
                valor = (valor<0) ? valor : 0;
            break;
            case 99: 
                valor = 1;
            break;
            case 98: 
                valor = 2;
            break;
            case 97: 
                valor = 3;
            break;
            case 96: 
                valor = 4;
            break;
            case 95: 
                valor = 5;
            break;
            case 94: 
                valor = 6;
            break;
            case 93: 
                valor = 7;
            break;
            case 92: 
                valor = 8;
            break;
            case 91: 
                valor = 9;
            break;
            default:
                
            break;
        }

        playerVida.vida += (float) valor;
        inventarioBotiquin.textBotiquin.text = "= " + inventarioBotiquin.CantidadBotiquin;
    }



}

