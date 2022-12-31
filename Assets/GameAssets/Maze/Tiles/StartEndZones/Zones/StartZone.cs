using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZone : MonoBehaviour
{
    public Game game;

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<Game>().GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.gameObject.GetComponentInParent<Player>().StartMaze();
        game.TryStartGame();
    }
}
