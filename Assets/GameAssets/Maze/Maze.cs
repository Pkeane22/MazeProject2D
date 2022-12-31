using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maze : MonoBehaviour
{
    public GameObject player;
    public Tiles tiles;
    public Button newMazeButton;

    public Vector3 size;
    public float scale;

    // Start is called before the first frame update
    void Start()
    {
        NewMaze();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

    }

    void OnEnable()
    {
        newMazeButton.onClick.AddListener(NewMaze);
    }

    void OnDisable()
    {
        newMazeButton.onClick.RemoveListener(NewMaze);
    }

    public void NewMaze()
    {
        transform.localScale = Vector3.one;

        tiles.DestroyTiles();

        tiles.NewTiles(size / scale);

        ScaleEverything();

        SetMap();

        player.transform.position = new Vector3(0, -1 * (size.y - 1) / 2, 0) + (1.025f * Vector3.down);

        if(size.x % 2 == 0)
        {
            player.transform.position += 0.5f * Vector3.right;
        }
    }

    void ScaleEverything()
    {
        transform.localScale = new Vector3(scale, scale, 1);

        tiles.ScaleWalls(scale);

        player.transform.localScale = new Vector3(scale, scale, 1);
    }

    void SetMap()
    {
        Camera miniMapCamera = GameObject.FindGameObjectWithTag("MinimapCamera").GetComponent<Camera>();
        float x = scale > 1 && size.x / scale % 1 == 0.5f ? size.x + 1 : size.x;
        float y = scale > 1 && size.y / scale % 1 == 0.5f ? size.y + 1 : size.y;

        if (x > y)
        {
            miniMapCamera.orthographicSize = (x + (0.2f * scale)) / miniMapCamera.aspect / 2f;
        }
        else
        {
            miniMapCamera.orthographicSize = (y + (0.2f * scale)) / 2f;
        }
    }
}
