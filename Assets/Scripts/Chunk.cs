using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Chunk
{
    //Chunk size
    private const int sizeX = 16;
    private const int sizeY = 16;
    private const int sizeZ = 16;
    public const int cubePerChunk = sizeX * sizeY * sizeZ;
    private Vector3[] vertices;
    private int[] triangles;
    private Vector3 origin;
    private List<Vector3> verticesList = new List<Vector3>();
    private List<int> trianglesList = new List<int>();
    public Chunk(Vector3 _origin)
    {
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
                        blocks.Count));
                }
            }
        }

        //Defining array size (bc meshes can't be created using lists)
        int vertexCount = Generation.chunkCount * blocks.Count * 8; //8 vertices per cube
        int triangleCount = Generation.chunkCount * blocks.Count * 36; //36 triangle indices per cube
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[triangleCount]; 

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
        vertices = verticesList.ToArray();
        return vertices;
    }
    public int[] TrianglesArray()
    {
        triangles = trianglesList.ToArray();
        return triangles;
    }
}
