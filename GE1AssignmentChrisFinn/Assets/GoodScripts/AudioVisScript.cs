﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVisScript : MonoBehaviour
{
    AudioSource myAudio;
    public static float[] _samples = new float[512];
    public static float[] _freqBands = new float[8];
    public static float[] _bandBuffer = new float[8];

    public float decreaseFloat;
    public float freqDecreaseFloat;

    float[] _bufferDecrease = new float[8];

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
    }

    void BandBuffer()
    {

        for(int g =0; g < 8; g++)
        {
            if (_freqBands [g] > _bandBuffer[g])
            {
                _bandBuffer[g] = _freqBands[g];
                _bufferDecrease[g] = decreaseFloat;
            }

            if (_freqBands[g] < _bandBuffer[g])
            {
                _bandBuffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= freqDecreaseFloat;
            }
        }

    }

    void GetSpectrumAudioSource()
    {

        myAudio.GetSpectrumData(_samples, 0, FFTWindow.Blackman);

    }

    void MakeFrequencyBands()
    {

        int count = 0;

        for (int i = 0; i < 8; i++)
        {

            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                    count++;
            }

            average /= count;

            _freqBands[i] = average * 10;

        }

    }

}
