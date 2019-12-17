using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class AudioVisScript : MonoBehaviour
{
    AudioSource myAudio;
    public static float[] _samples = new float[512];

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
    }

    void GetSpectrumAudioSource()
    {
        myAudio.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

}
