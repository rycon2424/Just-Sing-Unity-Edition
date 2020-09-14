using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchVisualizer : MonoBehaviour
{
    [SerializeField]
    private GameObject _testVisualizer;

    [SerializeField]
    private Vector2 _startingPos;

    [SerializeField]
    private AudioSource _audioSource;

    private AudioClip _audioClip;

    void Start()
    {
        _audioClip = _audioSource.clip;
    }

    void Update()
    {
        if (true) //audio daadwerkelijk geluid maakt
        {
            DrawVocals();
        }
    }

    private void DrawVocals()
    {
        float[] spectrum = new float[64];
        _audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        float average = 0;
        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            //average += Mathf.Log(spectrum[i - 1]);
            average += spectrum[i - 1];
        }
        average /= spectrum.Length;
        float pos = 5000f;
        pos *= average;

        pos = Mathf.Round(pos / 2) * 2;

        if (pos != -Mathf.Infinity)
        {
            _testVisualizer.transform.position = new Vector3(_startingPos.x, _startingPos.y + pos, 0);
        }
    }
}
