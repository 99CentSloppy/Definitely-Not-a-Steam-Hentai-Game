using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    public GameObject zombie;
    public Transform player;
    private NavMeshAgent agent;
    public static float speed;

    public int countdown;

    public bool ifHit;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        speed = 20.0f;
        health = 100;

        player = WaveStart.instance.player;
        TargetPlayer();
    }

    public void TargetPlayer()
    {
        agent.speed = speed;
        agent.destination = player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TargetPlayer();
    }
}
