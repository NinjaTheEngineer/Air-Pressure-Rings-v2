using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesController: MonoBehaviour
{
    public ParticleSystem bubblesPopParticles;
    public ParticleSystem bubblesParticles;
    public BoxCollider boxCollider;
    private bool isActivated = false;
    
    
    private void Start()
    {
        var particlesEmission = bubblesParticles.emission;
        particlesEmission.rateOverTime = 0.0f;
        var popEmission = bubblesPopParticles.emission;
        popEmission.rateOverTime = 0.0f;
        boxCollider.enabled = false;
    }
    public void ActivateBubbles()
    {
        isActivated = true;
        var particlesEmission = bubblesParticles.emission;
        particlesEmission.rateOverTime = 15.0f;
        var popEmission = bubblesPopParticles.emission;
        popEmission.rateOverTime = 5.0f;
        boxCollider.enabled = true;
    }
    public void DeactivateBubbles()
    {
        isActivated = false;
        var particlesEmission = bubblesParticles.emission;
        particlesEmission.rateOverTime = 0.0f;
        var popEmission = bubblesPopParticles.emission;
        popEmission.rateOverTime = 0.0f;
        boxCollider.enabled = false;
    }
    private bool IsActive()
    {
        return isActivated;
    }
}
