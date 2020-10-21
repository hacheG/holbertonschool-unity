using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    public AudioSource buttonSource;
    public AudioClip buttonRolloverClip;
    public AudioClip buttonClickClip;


    public void HoverSound()
    {
        buttonSource.PlayOneShot(buttonRolloverClip);
    }

    public void ClickSound()
    {
        buttonSource.PlayOneShot(buttonClickClip);
    }
}