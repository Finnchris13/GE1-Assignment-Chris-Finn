using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAudioCubes : MonoBehaviour
{

    public GameObject _cubePrefab;
    GameObject[] _sampleCube = new GameObject[16];
    public float _maxScale;

    // Start is called before the first frame update
    void Start()
    {
        
        for (int i =0; i < 16; i++)
        {
            GameObject _instanceCube = (GameObject)Instantiate(_cubePrefab);
            _instanceCube.transform.position = this.transform.position;
            _instanceCube.transform.parent = this.transform;
            _instanceCube.name = "AudioCube" + i;
            this.transform.eulerAngles = new Vector3(0, 22.5f * i, 0);
            _instanceCube.transform.position = Vector3.forward / 1000;
            _sampleCube[i] = _instanceCube;
        }

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 16; i++)
        {
            if( _sampleCube != null)
            {
                _sampleCube[i].transform.localScale = new Vector3(1, (AudioVisScript._samples[i] * _maxScale) + 2, 1);
            }
        }
    }
}
