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
    public float reloadTime = 1.5f;
    public bool reloading = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire && magCapacity >= 1 && reloading == false)
        {
            nextFire = Time.time + fireRate;
            shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && magCapacity < 30 && reloading == false)
        {
            reloading = true;
            StartCoroutine(reload());
            
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

    IEnumerator reload()
    {
        yield return new WaitForSeconds(3);
        magCapacity = 30;
        reloading = false;
    }

  

}
