using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultClick : MonoBehaviour
{
    //sound variable
    public AudioSource sound;

    public void PlayClick()
    {
        sound.Play();
    }
}
