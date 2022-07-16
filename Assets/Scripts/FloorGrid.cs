using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGrid : MonoBehaviour
{

    public int xSize = 6;
    public int zSize = 6;

    GameObject[,] grid;

    public float spacing = 10;

    public GameObject floorCube;

    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[xSize, zSize];
        SpawnGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnGrid()
    {
        Vector3 bottomLeftPos = transform.position + new Vector3(-spacing * (xSize-1) * 0.5f, 0, -spacing * (zSize-1) * 0.5f);


        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < zSize; j++)
            {
                Vector3 pos = bottomLeftPos + new Vector3(i * spacing, 0, j * spacing);
                var copy = Instantiate(floorCube, pos, Quaternion.identity, transform);
                copy.name += $"({i},{j})";
                grid[i, j] = copy;
            }
        }
    }
}
