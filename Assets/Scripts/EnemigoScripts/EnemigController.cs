using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigController : MonoBehaviour
{

    public int rutina;
    public float cronometro;
    public Animator animator;
    public Quaternion angulo;
    public float grado;
    public bool atacando;
    public float velocidad;

    private VidaPlayer vidaPlayer;

    // Jugador
    public GameObject jugador;

    public float currentDamageTime;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        jugador = GameObject.FindWithTag("Player");
        vidaPlayer = jugador.GetComponent<VidaPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, jugador.transform.position) > 8) {
            
            animator.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;

        if (cronometro >= 4) {
            rutina = Random.Range(0,2);
            cronometro = 0;
        }

        switch (rutina)
        {
            
            case 0: 
                animator.SetBool("walk", false);
                break;
            
            case 1:
                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutina++;                
                break;
            
            case 2: 
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                animator.SetBool("walk", true);
                break;
        }
        } else {
            if (Vector3.Distance(transform.position, jugador.transform.position) > 1) {
                
                var lookPos = jugador.transform.position - transform.position;
                // lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                animator.SetBool("walk", false);

                animator.SetBool("run", true);
                transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
                animator.SetBool("attack", false);

            } else {
                animator.SetBool("walk", false);
                animator.SetBool("run", false);

                animator.SetBool("attack", true);
                currentDamageTime += Time.deltaTime;
                if(currentDamageTime > 0.5f){
                    vidaPlayer.vida -= 5;
                    currentDamageTime = 0.0f;
                }
                atacando = true;
            }

            
        }
    }

    public void Final_Ani() {
        animator.SetBool("attack", false);
        atacando = false;
    }    

}
