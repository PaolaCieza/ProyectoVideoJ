using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;

    [SerializeField] private Animator shootAnimator;
    [SerializeField] private Transform barrelLocation;

    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 3f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;

    private AudioSource sonido;
    public AudioClip sonidobala;
    private Transform cam;

    private float temp = 0;

    public GameObject obj;

    private Inventario balas;

    private void Awake() {
        cam = Camera.main.transform;
        balas = GameObject.FindWithTag("Player").GetComponent<Inventario>();
    }

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();

        

        sonido = GetComponent<AudioSource>();
    }

    void Update()
    {
        //If you want a different input, change it here
        if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.Q) && balas.Cantidad > 0)
        {
            //Calls animation on the gun that has the relevant animation events that will fire
            gunAnimator.SetTrigger("Fire");
            shootAnimator.SetTrigger ("Shoot");
            balas.Cantidad--;
        }
    }


    //This function creates the bullet behavior
    void Shoot()
    {
        if (muzzleFlashPrefab)
        {
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
            sonido.clip = sonidobala;
            sonido.Play();
            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //cancels if there's no bullet prefeb
        if (!bulletPrefab)
        { return; }

        // Create a bullet and add force on it in direction of the barrel

        RaycastHit hit;

        

        Vector3 direction = cam.TransformDirection(new Vector3(Random.Range(-0.02f, 0.05f), Random.Range(-0.02f,0.02f),1));
        //Debug.DrawRay(cam.position, direction * 100f, Color.red, 5f);
        if (Physics.Raycast(cam.position, direction, out hit, Mathf.Infinity, ~6))
        {
            
            if(hit.transform.gameObject.tag == "Enemy"){
                Damage damage = hit.transform.GetComponent<Damage>();
                damage.setDamage();
                //hit.collider.GetComponent<Rigidbody>().AddForce(hit.point * 5f);
            }
            //GameObject bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
            //bullet.transform.LookAt(hit.point);
            //bullet.GetComponent<Rigidbody>().AddForce(hit.point * shotPower);

            // if(hit.collider.GetComponent<Rigidbody>()){
            //     hit.collider.GetComponent<Rigidbody>().AddForce(hit.point * shotPower);
            // }
            //Destroy(bullet, destroyTimer);
            //Instantiate(obj, hit.point, Quaternion.identity);
            //Destroy(hit.collider.gameObject);

            //burretLocation.position = a;
            //Debug.Log(hit.collider.name);
        }
           

    }

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }

  
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 10);
    }
}
