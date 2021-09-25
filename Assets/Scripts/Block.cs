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

		int index = (blockCount * 8) + ((Generation.chunkCount - 1) * Chunk.cubePerChunk);

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
