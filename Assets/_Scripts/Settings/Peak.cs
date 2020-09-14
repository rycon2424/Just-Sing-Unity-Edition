using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;
using System.Collections.Generic;

class Peak
{
    public float amplitude;
    public int index;

    public Peak()
    {
        amplitude = 0f;
        index = -1;
    }

    public Peak(float _frequency, int _index)
    {
        amplitude = _frequency;
        index = _index;
    }
}

class AmpComparer : IComparer<Peak>
{
    public int Compare(Peak a, Peak b)
    {
        return 0 - a.amplitude.CompareTo(b.amplitude);
    }
}

class IndexComparer : IComparer<Peak>
{
    public int Compare(Peak a, Peak b)
    {
        return a.index.CompareTo(b.index);
    }
}
