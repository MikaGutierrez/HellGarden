using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ForAnimation : MonoBehaviour
{
    public ParticleSystem particle;

    public void TurnOnParticle()
    {
        particle.Play();
    }
    public void TurnOffParticle()
    {
        particle.Stop();
    }
}
