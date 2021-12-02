using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeInfomacion : MonoBehaviour
{
    public static int balas;
    public static int vida;
    public static int botiquines;
    public static int bajas;
    
    
private void Awake() {
        DontDestroyOnLoad(gameObject);
    }


}
