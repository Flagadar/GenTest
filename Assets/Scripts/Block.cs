using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class Block : MonoBehaviour
{
    public Vector3[] vertices;
    private int[] faceFront, faceTop, faceRight, faceLeft, faceBack, faceBottom;
	public Vector3 blockOrigin;
	private List<Vector3> blocksPositionList = new List<Vector3>();

	enum BlockID
	{
		AIR,
		GRASS
	}

	public Block Init(Vector3 _blockOrigin, List<Vector3> _blocksPositionList)
	{
		blockOrigin = _blockOrigin;
		blocksPositionList = _blocksPositionList;
		return this;
	}

    void Start()
    {
		Mesh mesh = GetComponent<MeshFilter>().mesh;

        vertices = new Vector3[] {
            new Vector3 (blockOrigin.x, blockOrigin.y, blockOrigin.z),
			new Vector3 (blockOrigin.x + 1, blockOrigin.y, blockOrigin.z),
			new Vector3 (blockOrigin.x + 1, blockOrigin.y + 1, blockOrigin.z),
			new Vector3 (blockOrigin.x, blockOrigin.y + 1, blockOrigin.z),
			new Vector3 (blockOrigin.x, blockOrigin.y + 1, blockOrigin.z + 1),
			new Vector3 (blockOrigin.x + 1, blockOrigin.y + 1, blockOrigin.z + 1),
			new Vector3 (blockOrigin.x + 1, blockOrigin.y, blockOrigin.z + 1),
			new Vector3 (blockOrigin.x, blockOrigin.y, blockOrigin.z + 1),
        };

		faceFront = new int[] {
			0, 2, 1,
			0, 3, 2
		};

		faceTop = new int[] {
			2, 3, 4,
			2, 4, 5
		};

		faceRight = new int[] {
			1, 2, 5,
			1, 5, 6
		};

		faceLeft = new int[] {
			0, 7, 4,
			0, 4, 3
		};

		faceBack = new int[] {
			5, 4, 7,
			5, 7, 6
		};

		faceBottom = new int[] {
			0, 6, 7,
			0, 1, 6
		};

		mesh.Clear();
		GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/Wireframe");
		mesh.vertices = vertices;
		mesh.triangles = MeshTriangles();
		mesh.Optimize();
		mesh.RecalculateNormals();
    }

	int[] MeshTriangles()
	{
		List<int> triangleList = new List<int>();

		triangleList.AddRange(faceTop);
		triangleList.AddRange(faceFront);
		triangleList.AddRange(faceRight);
		triangleList.AddRange(faceLeft);
		triangleList.AddRange(faceBack);
		triangleList.AddRange(faceBottom);


		int[] triangleArray = new int[triangleList.Count];
		triangleArray = triangleList.ToArray();

		return triangleArray;
	}
}
