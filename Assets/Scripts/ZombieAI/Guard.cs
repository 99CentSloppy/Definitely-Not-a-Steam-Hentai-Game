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

    public float acceleration;
    public float deceleration;
    public float closeEnoughMeters;

    public FPSController playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        speed = 4.5f;
        health = 100;
        ifHit = false;

        acceleration = 20f;
        deceleration = 60f;
        closeEnoughMeters = 4f;

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
        if (agent.hasPath)
            agent.acceleration = (agent.remainingDistance < closeEnoughMeters) ? deceleration : acceleration;
    }
}
