using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStartGame : MonoBehaviour
{
    public ParticleSystem myParticleSystem;

    public void OnClick()
    {
        myParticleSystem.Play();
    }
}
