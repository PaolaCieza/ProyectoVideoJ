using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuMultiplayer : MonoBehaviour
{
    [SerializeField] private GameObject botonInicio;
    [SerializeField] private GameObject menuConfirmar;

    public void Confirmar(){  
        botonInicio.SetActive(false);
        menuConfirmar.SetActive(true);
    }

    public void Si(){
        SceneManager.LoadScene("Inicio");
    }

    public void No(){  
        botonInicio.SetActive(true);
        menuConfirmar.SetActive(false);
    }
}
