using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update

    int life = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0){
            Destroy(transform.gameObject);
        }   
    }

    public void setDamage(){
        life--;
        Debug.Log("Me muerooooo");
    }
}
