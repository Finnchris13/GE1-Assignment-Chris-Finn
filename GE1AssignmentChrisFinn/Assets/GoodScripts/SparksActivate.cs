using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparksActivate : MonoBehaviour
{

    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (isActive)
            gameObject.SetActive(true);

        if (!isActive)
        {
            gameObject.SetActive(false);
        }

    }
}
