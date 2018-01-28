using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    Text timeview;
    bool game_end = false;
    float start_time, current_time;
    public float game_duration = 120.0f;
    public bool win=false;
    // Use this for initialization
    void Start()
    {
        timeview = GameObject.Find("TimeToEnd").GetComponent<Text>();
        start_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        current_time = Time.time;
        timeview.text = (game_duration - (current_time - start_time)).ToString("0");
        if (current_time - start_time > game_duration)
            game_end = true;

        if (game_end)
            SceneManager.LoadScene("GameOverTimeEnded");
        if (win) { 

            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            for(int i=0; i<players.Length; i++)
            {
                if (players[i].GetComponent<CollisionController>().changed_clip == true)
                    win = false;
            }
            if (win)
                SceneManager.LoadScene("WinScene");
            else
                SceneManager.LoadScene("GameOverMixedSounds");

        }

    }

    bool getGameEnd()
    {
        return game_end;
    }
    void setGameEnd(bool val)
    {
        game_end = val;
    }

}

