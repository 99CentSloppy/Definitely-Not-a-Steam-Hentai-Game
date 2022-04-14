using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class mp40 : MonoBehaviour
{

    public Transform spawnPoint;
    public int damage = 35;
    public float fireRate = .1f;
    private float nextFire = 0f;
    public int magCapacity = 30;
    public float distance = 100f;
    public float reloadTime = 10;
    public bool reloading = false;
   


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && Time.time > nextFire && magCapacity >= 1)
        {
            nextFire = Time.time + fireRate;
            shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            reload();
        }
    }

    public void shoot()
    {
        magCapacity--;
        RaycastHit hit;
        


        if(Physics.Raycast(spawnPoint.position, spawnPoint.forward, out hit, distance))
        {
            if (hit.transform.tag == "Enemy")
            {
                Debug.Log("Hit");
            }
            
        }
    }

    public void reload()
    {

        magCapacity = 30;
    }

}
