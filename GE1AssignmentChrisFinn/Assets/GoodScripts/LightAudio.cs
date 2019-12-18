using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Light))]
public class LightAudio : MonoBehaviour
{
    public int _band;
    public float _minIntensity, _maxIntensity;
    Light _light;

    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        _light.intensity = (AudioVisScript._bandBuffer[_band] * (_maxIntensity - _minIntensity)) + _minIntensity;
    }
}
