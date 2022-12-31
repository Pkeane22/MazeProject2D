using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public Player player;
    public Maze maze;
    public TMP_Text timeText;
    public TMP_Text finishedMazeText;

    private float startTime;
    private float timeToFinish;
    private float makeNextMazeTime;

    // Start is called before the first frame update
    void Start()
    {
        timeText.enabled = false;
        finishedMazeText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(player.playerState == PlayerState.InMaze)
        {
            float time = Time.fixedTime - startTime;

            timeText.text = String.Format("{0}:{1:00.00}", Mathf.Floor(time / 60), time % 60);
        }
        else if(player.playerState == PlayerState.AfterEnd)
        {
            String finishTimeString = String.Format("{0}:{1:00.00}", Mathf.Floor(timeToFinish / 60), timeToFinish % 60);

            finishedMazeText.text = String.Format(
                "You finished the maze in {0}. \n " +
                "Next maze will generate in {1:F0} seconds.",
                finishTimeString, makeNextMazeTime - Time.fixedTime);

            if (makeNextMazeTime < Time.fixedTime)
            {
                timeText.enabled = false;
                finishedMazeText.enabled = false;

                player.playerState = PlayerState.BeforeStart;
                
                maze.NewMaze();
            }

        }
    }

    public void TryStartGame()
    {
        if (player.playerState == PlayerState.InMaze)
        {
            timeText.enabled = false;

            player.playerState = PlayerState.BeforeStart;
        }
        else
        {
            startTime = Time.fixedTime;
            timeText.enabled = true;
            timeText.text = startTime - startTime + "";

            player.playerState = PlayerState.InMaze;
        }
    }

    public void TryEndGame()
    {
        if (player.playerState == PlayerState.InMaze)
        {
            timeToFinish = Time.fixedTime - startTime;
            makeNextMazeTime = Time.fixedTime + 5;

            finishedMazeText.enabled = true;

            player.playerState = PlayerState.AfterEnd;
        }
    }
}
