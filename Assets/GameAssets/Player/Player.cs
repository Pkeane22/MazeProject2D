using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerBody;
    private Vector3 input;
    private float speed = 2.0f;

    public PlayerState playerState;
    //private float startTime;
    //private float timeToFinish;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        input = GetInput();
    }

    void FixedUpdate()
    {
        MovePlayer();

        //switch (playerState)
        //{
        //    case PlayerState.BeforeStart:

        //        break;

        //    case PlayerState.Start:
        //        startTime = Time.fixedTime;
        //        break;

        //    case PlayerState.InMaze:

        //        break;

        //    case PlayerState.End:
        //        timeToFinish = startTime - Time.fixedTime;
        //        print(timeToFinish);
        //        break;

        //    case PlayerState.AfterEnd:

        //        break;
        //}
    }

    void MovePlayer()
    {
        //transform.position += speed * input * Time.fixedDeltaTime;
        playerBody.velocity = speed * input;
    }

    Vector3 GetInput()
    {
        return new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
    }

    //public void StartMaze()
    //{
    //    if(playerState == PlayerState.InMaze)
    //    {
    //        print("Exited Maze");
    //        playerState = PlayerState.BeforeStart;
    //    }
    //    else
    //    {
    //        print("Started Maze");
    //        startTime = Time.time;
    //        playerState = PlayerState.InMaze;
    //    }
    //}

    //public void EndMaze()
    //{
    //    if (playerState == PlayerState.InMaze)
    //    {
    //        timeToFinish = Time.time - startTime;
    //        print("Finished Maze in " + timeToFinish + " Seconds.");
    //        playerState = PlayerState.AfterEnd;
    //    }
    //}
}

public enum PlayerState
{
    BeforeStart = 0,
    Start = 1,
    InMaze = 2,
    End = 3,
    AfterEnd = 4
}