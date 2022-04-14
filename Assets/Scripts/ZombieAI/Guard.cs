using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    public GameObject zombie;
    public GameObject player;
    private NavMeshAgent navmesh;

    public bool attack;
    public int countdown;

    // Start is called before the first frame update
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(attack == true)
        {
            zombie.SetActive(true);
            navmesh.destination = player.transform.position;
        }
        else
        {
            zombie.SetActive(false);
        }

        
    }
}
