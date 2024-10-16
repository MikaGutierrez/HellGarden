using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ForAnimation : MonoBehaviour
{
    public ParticleSystem particle;
    public static bool TheUltimateBool;
    public void TurnOnParticle()
    {
        particle.Play();
    }
    public void TurnOffParticle()
    {
        particle.Stop();
    }
    public void TurnOffTheBool()
    {
        TheUltimateBool = false;
    }
    public void TurnOnTheBool()
    {
        TheUltimateBool = true;
    }
}
