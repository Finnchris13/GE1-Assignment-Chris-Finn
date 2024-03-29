﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelData : MonoBehaviour
{

    public static readonly int ChunkWidth = 16;
    public static readonly int ChunkHeight = 128;
    public static readonly int WorldSizeInChunks = 50;

    public static int WorldSizeInVoxels
    {

        get { return WorldSizeInChunks * ChunkWidth; }

    }

    public static readonly int ViewDistanceInChunks = 5;

    public static readonly int textureAtlasSizeInBlocks = 4;
    public static float NormalizedBlockTextureSize
    {

        get { return 1f / (float)textureAtlasSizeInBlocks; }

    }

    public static readonly Vector3[] voxelVerts = new Vector3[8]
    {

        new Vector3(0.0f, 0.0f, 0.0f),
        new Vector3(1.0f, 0.0f, 0.0f),
        new Vector3(1.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 0.0f, 1.0f),
        new Vector3(1.0f, 0.0f, 1.0f),
        new Vector3(1.0f, 1.0f, 1.0f),
        new Vector3(0.0f, 1.0f, 1.0f),

    };

    public static readonly Vector3[] faceChecks = new Vector3[6]
    {

        new Vector3(0.0f, 0.0f, -1.0f),
        new Vector3(0.0f, 0.0f, 1.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, -1.0f, 0.0f),
        new Vector3(-1.0f, 0.0f, 0.0f),
        new Vector3(1.0f, 0.0f, 0.0f),

    };

    public static readonly int[,] voxelTris = new int[6,4]
    {

        // back, front, top, bottom, left, right
        

        {0, 3, 1, 2},
        {5, 6, 4, 7},
        {3, 7, 2, 6},
        {1, 5, 0, 4},
        {4, 7, 0, 3},
        {1, 2, 5, 6}

    };

    public static readonly Vector2[] voxelUvs = new Vector2[4]
    {

        new Vector2(0.0f, 0.0f),
        new Vector2(0.0f, 1.0f),
        new Vector2(1.0f, 0.0f),
        new Vector2(1.0f, 1.0f)

    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
