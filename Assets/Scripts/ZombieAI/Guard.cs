using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    public GameObject zombie;
    public GameObject player;
    private NavMeshAgent navmesh;
    public static float speed;

    public bool attack;
    public int countdown;
    public float nasru;
    public float maxPosX;
    public float minPosX;
    public float maxPosY;
    public float minPosY;

    // Start is called before the first frame update
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
        speed = 20.0f;
        attack = false;
        nasru = 3;
        maxPosX = 82;
        minPosX = -82;
        maxPosY = 89;
        minPosY = 60;
    }

    // Update is called once per frame
    void Update()
    {
        navmesh.speed = speed;
        if (attack == true)
        {
            //Zombie Spawning
            for (int i = 3; i > 0; i--)
            {
                i--;
                nasru--;
                if (nasru >= 0)
                {
                    nasru -= Time.deltaTime;
                    var newPos = new Vector3(Random.Range(minPosX, maxPosX), 0, Random.Range(minPosY, maxPosY));
                    nasru = 0;
                    GameObject go = GameObject.Instantiate(zombie);
                    go.transform.position = newPos;
                }
            }
            zombie.SetActive(true);
            navmesh.destination = player.transform.position;
        }
        else
        {
            zombie.SetActive(false);
        }

        
    }
}
