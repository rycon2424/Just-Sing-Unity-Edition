using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour
{
    public List<string> deviceNames = new List<string>();
    private AudioSource audioS;
    public Text[] debug;

    void Start()
    {
        foreach (var device in Microphone.devices)
        {
            deviceNames.Add(device);
        }

        audioS = GetComponent<AudioSource>();
        audioS.clip = Microphone.Start(deviceNames[0], true, 10, 44100);
        audioS.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
        audioS.Play();
    }
    
    void Update()
    {
        float[] spectrum = new float[64];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            Debug.DrawLine(new Vector3(1+i, Mathf.Log(spectrum[i - 1]), 0), new Vector3(1+i, Mathf.Log(spectrum[i]), 3), Color.white);
        }

    }

}
