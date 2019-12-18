using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRotation : MonoBehaviour
{
    public GameObject[] starBlocks;
    public float rotationSpeed;

    public bool starRotating;

    // Start is called before the first frame update
    void Start()
    {
        starRotating = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (starRotating)
            turnStars();
    }


    public void turnStars()
    {

        starBlocks = GameObject.FindGameObjectsWithTag("Stars");

        foreach (GameObject stars in starBlocks)
        {
            stars.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

    }
}
