using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoBallAudio : MonoBehaviour
{

    public int _band;
    public float _startScale, _scaleMultiplier;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            transform.localScale = new Vector3((AudioVisScript._bandBuffer[_band] * _scaleMultiplier) + _startScale, AudioVisScript._bandBuffer[_band]  + 2, (AudioVisScript._bandBuffer[_band] * _scaleMultiplier) + _startScale);
    }
}
