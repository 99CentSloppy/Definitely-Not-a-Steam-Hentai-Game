using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

public GameObject zombie;
    public Transform player;
    private NavMeshAgent agent;
    public static float speed;

    public WaveStart waveManager;

    public int countdown;

    public bool isDead;
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

        waveManager = WaveStart.getInstance();

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

    public void TakeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            waveManager.zombieCount--;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        TargetPlayer();
        if (agent.hasPath)
            agent.acceleration = (agent.remainingDistance < closeEnoughMeters) ? deceleration : acceleration;
    }
}
