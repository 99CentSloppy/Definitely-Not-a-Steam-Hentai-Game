using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveStart : MonoBehaviour
{

    public Text countdownText;
    public GameObject holdText;
    public bool gameStart;
    public float time;
    public int countdown;
    public Guard attack;
   
    // Start is called before the first frame update
    void Start()
    {
        gameStart = true;
        countdown = 0;
        time = 0;
        holdText = GameObject.Find("/WaveUI/Canvas/Text");
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


        if(time <= 0)
        {
            holdText.SetActive(false);
            attack.zombie.SetActive(true);
            attack.attack = true;
            countdownText.text = " ";
        }
    }
}
