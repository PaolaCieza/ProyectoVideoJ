using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moviPrueba : MonoBehaviour
{
    // Camera mycam;
    // void Start()
    // {
    //     mycam = GetComponent<Camera>();
    // }
    // void Update()
    // {
    //     float mouseX = (Input.mousePosition.x / Screen.width ) - 0.5f;
    //     float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;
    //     transform.localRotation = Quaternion.Euler (new Vector4 (-1f * (mouseY * 180f), mouseX * 360f, transform.localRotation.z));
    // }



    public float Speed = 30.0f;

    private Rigidbody Physics;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;

        Physics = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * Speed);

        //Rotación

        float mouseX = (Input.mousePosition.x / Screen.width ) - 0.5f;
        float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;
        transform.localRotation = Quaternion.Euler (new Vector4 (-1f * (mouseY * 180f), mouseX * 360f, transform.localRotation.z));


    }


}
