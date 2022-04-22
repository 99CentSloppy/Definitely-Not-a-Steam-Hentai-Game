using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveStart : MonoBehaviour
{
    public static WaveStart instance;

    public Text countdownText;
    public GameObject holdText;
    public bool gameStart;
    public bool waveStart;
    public float time;
    public int countdown;
    public GameObject zombieObject;

    public int zombieCount;
    public int waveCount;

    public float maxPosX;
    public float minPosX;
    public float maxPosY;
    public float minPosY;

    public Transform player;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameStart = true;
        waveStart = false;
        waveCount = 0;
        countdown = 0;
        time = 0;
        holdText = GameObject.Find("/WaveUI/Canvas/Text");

        zombieCount = 0;

        maxPosX = 82;
        minPosX = -82;
        maxPosY = 89;
        minPosY = 60;
    }


    public void WaveCall(int waveCount)
    {
        zombieCount = 5;
            if (zombieCount > 0) {
            SpawnZombie(zombieCount * waveCount);
            }

        waveStart = false;
    }

    public void SpawnZombie(int zombieCount)
    {
        zombieCount = 0;
        var newPos = new Vector3(UnityEngine.Random.Range(minPosX, maxPosX), 0, UnityEngine.Random.Range(minPosY, maxPosY));
        GameObject go = GameObject.Instantiate(zombieObject);
        go.transform.position = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStart == true)
        {
            time = 10;
            gameStart = false;
        }
        if(time > 0) {
            time -= Time.deltaTime;
            countdown = (int)time;
            countdownText.text = countdown.ToString();
        }

        //Zombie Spawning
        if (waveStart == true && zombieCount >= 0)
        {
            WaveCall(waveCount);
            waveCount++;
        }

        if (time <= 0)
        {
            countdownText.text = " ";
            holdText.SetActive(false);
            waveStart = true;
        }
       
    }
}
