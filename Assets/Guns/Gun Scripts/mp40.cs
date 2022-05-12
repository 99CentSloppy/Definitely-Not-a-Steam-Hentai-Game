using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mp40 : MonoBehaviour
{

    public Transform player, gunContainer, fpsCam;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform spawnPoint;
    public int damage = 35;
    public float fireRate = .1f;
    private float nextFire = 0f;
    public int magCapacity = 30;
    public float distance = 100f;
    public float reloadTime = 1.5f;
    public bool reloading = false;
    public bool equipped = false;
    public static bool slotFull = false;
    public float pickUpRange = 4;
    public float dropForwardForce = 4, dropUpwardForce = 2;
    public ParticleSystem muzzleFlash;
    public GameObject bulletHole;

    public Guard zombie;


    private void Start()
    {
        muzzleFlash.Stop();
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire && magCapacity >= 1 && reloading == false && equipped)
        {
            nextFire = Time.time + fireRate;
            shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && magCapacity < 30 && reloading == false && equipped)
        {
            reloading = true;
            StartCoroutine(reload());
            
        }
        Vector3 distanceToPlayer = player.position - transform.position;
        if (Input.GetKeyDown(KeyCode.E) && !equipped && distanceToPlayer.magnitude <= pickUpRange && !slotFull){
            pickUp();
        }
        if (Input.GetKeyDown(KeyCode.G) && equipped && slotFull && reloading == false)
        {
            drop();
        }

    }

    public void shoot()
    {
        magCapacity--;
        RaycastHit hit;
        //fire effects
        muzzleFlash.Play();
        
        
       

        if(Physics.Raycast(spawnPoint.position, spawnPoint.forward, out hit, distance))
           {
            GameObject bH = Instantiate(bulletHole, hit.point + new Vector3(0f, 0f, -.02f), Quaternion.LookRotation(hit.normal));
            if (hit.transform.tag == "Enemy")
            {

                Debug.Log("Hit" + hit.collider.gameObject.name);

               Guard zombie = hit.collider.GetComponent<Guard>();

                zombie.health -= damage;
            }
            
        }
    }

    IEnumerator reload()
    {
        //reload animation
        yield return new WaitForSeconds(3);
        magCapacity = 30;
        reloading = false;
    }

    public void pickUp()
    {
        equipped = true;
        slotFull = true;

        rb.isKinematic = true;
        coll.isTrigger = true;

        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
    }

    public void drop()
    {
        equipped = false;
        slotFull = false;
        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);
    }
  

}
