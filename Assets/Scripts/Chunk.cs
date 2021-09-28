using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    //Chunk size
    private const int sizeX = 16;
    private const int sizeY = 2;
    private const int sizeZ = 16;

    private List<GameObject> blocks = new List<GameObject>();

    public List<Vector3> blocksPosition = new List<Vector3>();

    void Start()
    {
        Init();
    }

    private void Init()
    {
        //Create the blocks
        int i = 0;
        for(int y = 0; y < sizeY; y++)
        {
            for(int z = 0; z < sizeZ; z++)
            {
                for(int x = 0; x < sizeX; x++)
                {
                    blocksPosition.Add(new Vector3(x, y, z));

                    blocks.Add(new GameObject("Block " + i));
                    blocks[i].AddComponent<Block>().Init(blocksPosition[i], blocksPosition);
                    i++;
                }
            }
        }
    }
}
