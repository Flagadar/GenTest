using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Chunk
{
    //Chunk size
    private const int sizeX = 16;
    private const int sizeY = 1;
    private const int sizeZ = 16;
    public const int blocksPerChunk = sizeX * sizeY * sizeZ;

    public static int verticesPerChunk = blocksPerChunk * 8;

    private Vector3 origin;
    private int chunkIndex;
    private List<Vector3> verticesList = new List<Vector3>();
    private List<int> trianglesList = new List<int>();

    public Chunk(Vector3 _origin, int _chunkIndex)
    {
        chunkIndex = _chunkIndex;
        origin = _origin;
        Init();
    }

    private void Init()
    {
        //Create the blocks
        List<Block> blocks = new List<Block>();
        for(int y = 0; y < sizeY; y++)
        {
            for(int z = 0; z < sizeZ; z++)
            {
                for(int x = 0; x < sizeX; x++)
                {
                    blocks.Add(new Block(new Vector3(
                        origin.x + x, origin.y + y, origin.z + z), 
                        blocks.Count, chunkIndex));
                }
            }
        }

        /* Adding vertices and triangles in lists
           Then convert lists into arrays in the last 2 functions */
        foreach(Block block in blocks)
        {
            verticesList.AddRange(block.vertices);
            trianglesList.AddRange(block.triangles);
        }
    }

    public Vector3[] VerticesArray()
    {
        Vector3[] vertices = new Vector3[verticesList.Count];
        vertices = verticesList.ToArray();
        return vertices;
    }
    
    public int[] TrianglesArray()
    {
        int[] triangles = new int[trianglesList.Count];
        triangles = trianglesList.ToArray();
        return triangles;
    }
}
