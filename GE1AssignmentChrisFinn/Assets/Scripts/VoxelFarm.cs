using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelFarm : MonoBehaviour
{

    private GameObject currentBlockType;
    public GameObject[] blockTypes;

    public float amp = 10f;
    public float freq = 10f;

    private Vector3 myPos;

    // Start is called before the first frame update
    void Start()
    {

        myPos = this.transform.position;

        generateTerrain();



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateTerrain()
    {

        

        int cols = 100;
        int rows = 100;

        for (int x = 0; x < cols; x++)
        {

            for (int z = 0; z < rows; z++)
            {

                float y = Mathf.PerlinNoise((myPos.x + x) / freq, (myPos.z + z) / freq) * amp;

                y = Mathf.Floor(y);

                if (y > amp / 2) currentBlockType = blockTypes[1];
                else currentBlockType = blockTypes[0];

                GameObject newBlock = GameObject.Instantiate(currentBlockType);

                newBlock.transform.position = new Vector3(myPos.x + x, y, myPos.z + z);

            }

        }

    }

}
