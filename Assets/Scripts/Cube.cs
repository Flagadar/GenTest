using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Block
{
    public Vector3[] vertices;
    public int[] triangles;
    public Block(Vector3 blockOrigin, int blockCount)
    {
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

		int index = blockCount * 8;
		if(blockCount <= 1)
		{
			triangles = new int[] {
            0, 2, 1, //face front
			0, 3, 2,
			2, 3, 4, //face top
			2, 4, 5,
			1, 2, 5, //face right
			1, 5, 6,
			0, 7, 4, //face left
			0, 4, 3,
			5, 4, 7, //face back
			5, 7, 6,
			0, 6, 7, //face bottom
			0, 1, 6
        	};
		}
		else if(blockCount == 2)
		{
			triangles = new int[] {
            8, 10, 9, //face front
			8, 11, 10,
			10, 11, 12, //face top
			10, 12, 13,
			9, 10, 13, //face right
			9, 13, 14,
			8, 15, 12, //face left
			8, 12, 11,
			13, 12, 15, //face back
			13, 15, 14,
			8, 14, 15, //face bottom
			8, 9, 14
        	};
		}
		else
		{
			triangles = new int[] {
            index + 0, index + 2, index + 1, //face front
			index + 0, index + 3, index + 2,
			index + 2, index + 3, index + 4, //face top
			index + 2, index + 4, index + 5,
			index + 1, index + 2, index + 5, //face right
			index + 1, index + 5, index + 6,
			index + 0, index + 7, index + 4, //face left
			index + 0, index + 4, index + 3,
			index + 5, index + 4, index + 7, //face back
			index + 5, index + 7, index + 6,
			index + 0, index + 6, index + 7, //face bottom
			index + 0, index + 1, index + 6
        };
		}
    }
}
