using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualiserProperties : MonoBehaviour
{
    [HideInInspector]
    public ParticleSystem particleSystem;

    [HideInInspector]
    public Material particleMaterial;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleMaterial = particleSystem.GetComponent<Renderer>().material;
    }

    /// <summary>
    /// Starts or stops the stream of particles. Call this to start or stop particles from appearing when no audio is played.
    /// </summary>
    public void ToggleEmission()
    {
        var em = particleSystem.emission;
        em.enabled = !em.enabled;
    }

    /// <summary>
    /// Sets material to a color.
    /// </summary>
    public void SetParticleColor(Color newColor)
    {
        particleMaterial.color = newColor;
        new Color();
    }
}
