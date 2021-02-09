using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void mute()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            if (audio.mute)
                audio.mute = false;
            else
                audio.mute = true;

        Debug.Log("Mutiado");
    }
}
