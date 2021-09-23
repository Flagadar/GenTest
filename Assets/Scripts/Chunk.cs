using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Chunk
{
    int sizeX = 16;
    int sizeY = 128;
    int sizeZ = 16;
    private Vector3[] vertices;
    private int[] triangles;
    private List<Vector3> verticesList = new List<Vector3>();
    private List<int> trianglesList = new List<int>();
    public Chunk(Vector3 origin)
    {
        Init();
    }
    private void Init()
    {
        List<Block> blocks = new List<Block>();
        for(int x = 0; x < sizeX; x++)
        {
            int y = 0;
            int z = 0;
            blocks.Add(new Block(new Vector3(x, y, z), blocks.Count));
            Debug.Log(blocks.Count);
            foreach(int triangle in blocks[x].triangles)
            {
                Debug.Log(triangle);
            }
        }

        int vertexCount = blocks.Count * 8; //8 vertices per cube
        int triangleCount = blocks.Count * 36; //36 triangles per cube
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[triangleCount]; 

        foreach(Block cube in blocks)
        {
            verticesList.AddRange(cube.vertices);
            trianglesList.AddRange(cube.triangles);
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
