using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Generation : MonoBehaviour
{
    public static int chunkCount;

    List<Chunk> chunksList = new List<Chunk>();

    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        chunksList.Add(new Chunk(new Vector3(0, 0, 0), chunksList.Count));
        chunksList.Add(new Chunk(new Vector3(16, 0, 0), chunksList.Count));
        chunksList.Add(new Chunk(new Vector3(0, 0, 16), chunksList.Count));
        chunksList.Add(new Chunk(new Vector3(-16, 0, 0), chunksList.Count));
        chunksList.Add(new Chunk(new Vector3(0, 0, -16), chunksList.Count));

        chunkCount = chunksList.Count;

        mesh.Clear();
        mesh.vertices = TotalVertices(chunksList);
        mesh.triangles = TotalTriangles(chunksList);
        mesh.Optimize();
        mesh.RecalculateNormals();
    }

    Vector3[] TotalVertices(List<Chunk> _chunks)
    {
        Vector3[] totalVertices;
        List<Vector3> verticesList = new List<Vector3>();

        foreach(Chunk chunk in _chunks)
        {
            verticesList.AddRange(chunk.VerticesArray());
        }

        totalVertices = new Vector3[verticesList.Count];
        totalVertices = verticesList.ToArray();

        return totalVertices;
    }

    int[] TotalTriangles(List<Chunk> _chunks)
    {
        int[] totalTriangles;
        List<int> trianglesList = new List<int>();

        foreach(Chunk chunk in _chunks)
        {
            trianglesList.AddRange(chunk.TrianglesArray());
        }

        totalTriangles = new int[trianglesList.Count];
        totalTriangles = trianglesList.ToArray();

        return totalTriangles;
    }
}
