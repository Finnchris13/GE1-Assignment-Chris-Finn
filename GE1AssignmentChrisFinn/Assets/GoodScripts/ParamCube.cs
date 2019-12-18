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
        _scaleMultiplier = 3f;
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

        if(_band == 4 && gameObject.tag == "BoxBlocks")
        {
            _scaleMultiplier = 2f;
        }

        if((_band == 5 && gameObject.tag == "BoxBlocks"))
        {
            _scaleMultiplier = 2f;
        }

        if (_band == 6 && gameObject.tag == "BoxBlocks")
        {
            _scaleMultiplier = 2.5f;
        }

    }
}
