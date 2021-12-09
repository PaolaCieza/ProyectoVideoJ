using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update

    public int life = 5;
    private EnemigController controller;
    public Animator animator;
    private GenericScript genericSC;

    public GameObject effectDie;

    void Start()
    {
        genericSC = GameObject.Find("GenericObject").GetComponent<GenericScript>();
        animator = GetComponent<Animator>();
        controller = this.gameObject.GetComponent<EnemigController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0){
            GameObject die;
            genericSC.bajas++;
            genericSC.RefreshUI();
            Destroy(transform.gameObject);
            die = Instantiate(effectDie, gameObject.transform.position, Quaternion.Euler(-90,0,0));
            Destroy(die, 5f);
        }   
    }

    public void setDamage(int damage){
        life = life - damage;
        Debug.Log("Me muerooooo");
        animator.SetTrigger("damage");
        controller.damage = true;
    }
}
