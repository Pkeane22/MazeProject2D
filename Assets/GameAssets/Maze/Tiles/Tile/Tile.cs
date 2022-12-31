using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject[] walls;

    private GameObject tiles;
    private GameObject tilePrefab;
    private GameObject parent;
    private GameObject[] children = new GameObject[2];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTile(GameObject tiles, GameObject tilePrefab, GameObject parent)
    {
        this.tiles = tiles;
        this.tilePrefab = tilePrefab;
        this.parent = parent;

        if (true)
        {
            int rotation = TryAllDirections();

            if (rotation != -180)
            {
                Destroy(walls[(rotation % 360) / 90]);

                children[0] = Instantiate(tilePrefab, transform.position + (Quaternion.Euler(0, 0, rotation) * Vector3.up), Quaternion.Euler(Vector3.zero), tiles.transform);
                Destroy(children[0].GetComponent<Tile>().walls[((rotation + 180) % 360) / 90]);
                children[0].GetComponent<Tile>().SetTile(tiles, tilePrefab, gameObject);

                rotation = TryAllDirections();
                if (rotation != -180)
                {
                    Destroy(walls[(rotation % 360) / 90]);

                    children[1] = Instantiate(tilePrefab, transform.position + (Quaternion.Euler(0, 0, rotation) * Vector3.up), Quaternion.Euler(Vector3.zero), tiles.transform);
                    Destroy(children[1].GetComponent<Tile>().walls[((rotation + 180) % 360) / 90]);
                    children[1].GetComponent<Tile>().SetTile(tiles, tilePrefab, gameObject);
                }
            }

            RemoveDoubleWalls();
        }
    }

    int TryAllDirections()
    {
        int rotation = 90 * Random.Range(0, 4);

        if (TryDirection(rotation))
        {
            return rotation;
        }
        else if(TryDirection(rotation + 90))
        {
            return rotation + 90;
        }
        else if (TryDirection(rotation + 180))
        {
            return rotation + 180;
        }
        else if (TryDirection(rotation + 270))
        {
            return rotation + 270;
        }

        return -180;
    }

    bool TryDirection(int rotation)
    {
        Vector3 point = transform.position + (Quaternion.Euler(0, 0, rotation) * Vector3.up);
        if (!tiles.GetComponent<Tiles>().bounds.Contains(point + (0.0f * (Quaternion.Euler(0, 0, rotation) * Vector3.up))))
        {
            return false;
        }

        Collider2D collider = Physics2D.OverlapPoint(point);
        if (collider != null && collider.tag == "Tile")
        {
            return false;
        }

        return true;
    }

    void RemoveDoubleWalls()
    {
        if (CheckDoubleWall(0))
        {
            Destroy(walls[0]);
        }
        if (CheckDoubleWall(90))
        {
            Destroy(walls[1]);
        }
        if (CheckDoubleWall(180))
        {
            Destroy(walls[2]);
        }
        if (CheckDoubleWall(270))
        {
            Destroy(walls[3]);
        }
    }

    bool CheckDoubleWall(int rotation)
    {
        return Physics2D.OverlapPointAll(transform.position + (0.5f * (Quaternion.Euler(0, 0, rotation) * Vector3.up))).Length > 1;
    }
}
