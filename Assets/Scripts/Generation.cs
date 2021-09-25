using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Generation : MonoBehaviour
{
    public static int chunkCount = 2;
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        Chunk chunk = new Chunk(new Vector3(0, 0, 0));
        Chunk chunk1 = new Chunk(new Vector3(16, 0, 0));

        mesh.Clear();
        mesh.vertices = chunk.VerticesArray();
        mesh.triangles = chunk.TrianglesArray();
        mesh.Optimize();
        mesh.RecalculateNormals();
    }
}
