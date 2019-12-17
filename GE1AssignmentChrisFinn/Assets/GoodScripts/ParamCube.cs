using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{

    public int _band;
    public float _startScale, _scaleMultiplier;

    public bool useBuffer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioVisScript._bandBuffer[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
        }
        else if (!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioVisScript._freqBands[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
        }
    }
}
