using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject spawnTilePrefab;
    public GameObject endTilePrefab;

    public Bounds bounds { get; set; }
    private Vector3 startPos = new Vector3(0, -4.0f, 0);
    private GameObject startTile;

    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {

    }

    public void NewTiles(Vector3 size)
    {
        bounds = new Bounds(Vector3.zero, size);

        if (size.y % 1 == 0.5f)
        {
            startPos = new Vector3(0, -1 * (size.y - 0.5f) / 2, 0);
        }
        else
        {
            startPos = new Vector3(0, -1 * (size.y - 1) / 2, 0);
        }

        if (size.x % 2 == 0)
        {
            startPos += 0.5f * Vector3.right;
        }

        Instantiate(spawnTilePrefab, startPos + Vector3.down, Quaternion.Euler(0, 0, 0), transform);
        //Instantiate(endTilePrefab, (-1 * startPos) + Vector3.up, Quaternion.Euler(0, 0, 0), transform);
        (Vector3 endPos, Quaternion endRot) = EndTilePosAndRot(startPos);
        Instantiate(endTilePrefab, endPos, endRot, transform);

        startTile = Instantiate(tilePrefab, startPos, Quaternion.Euler(Vector3.zero), transform);
        Destroy(startTile.GetComponent<Tile>().walls[2]);
        startTile.GetComponent<Tile>().SetTile(gameObject, tilePrefab, null);
    }

    (Vector3, Quaternion) EndTilePosAndRot(Vector3 startPos)
    {
        Vector3 endPos;
        Quaternion rotation;
        int side = Random.Range(-1, 2);

        if(side == 0)
        {
            endPos = (Random.Range(0, (int)bounds.size.x) - bounds.extents.x + 0.5f) * Vector3.right + (-1 * startPos) + Vector3.up;
            rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            endPos = (Random.Range(0, (int)bounds.size.y) - bounds.extents.y + 0.5f) * Vector3.up + side * (bounds.extents.y + 0.5f) * Vector3.right;
            rotation = Quaternion.Euler(0, 0, side * -90f);
        }

        return (endPos, rotation);

    }

    public void DestroyTiles()
    {
        foreach (Tile tile in FindObjectsOfType<Tile>())
        {
            DestroyImmediate(tile.gameObject);
        }

        foreach (SpawnTile tile in FindObjectsOfType<SpawnTile>())
        {
            DestroyImmediate(tile.gameObject);
        }

        foreach (EndTile tile in FindObjectsOfType<EndTile>())
        {
            DestroyImmediate(tile.gameObject);
        }
    }

    public void ScaleTiles(float scale)
    {
        foreach (Tile tile in FindObjectsOfType<Tile>())
        {
            tile.gameObject.transform.localScale = scale * Vector3.one;
        }

        foreach (SpawnTile tile in FindObjectsOfType<SpawnTile>())
        {
            tile.gameObject.transform.localScale = scale * Vector3.one;
        }

        foreach (EndTile tile in FindObjectsOfType<EndTile>())
        {
            tile.gameObject.transform.localScale = scale * Vector3.one;
        }
    }

    public void ScaleWalls(float scale)
    {
        foreach (LineRenderer wall in FindObjectsOfType<LineRenderer>())
        {
            wall.widthMultiplier = 0.1f * scale;
        }
    }
}