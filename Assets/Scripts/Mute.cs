using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    AudioSource audio;
    [SerializeField] Image boton;
    [SerializeField] Sprite unmuted;
    [SerializeField] Sprite muted;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        boton.sprite = unmuted;
    }

    public void mute()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        if (audio.mute)
        {
            audio.mute = false;
            boton.sprite = unmuted;
        }
        else
        {
            audio.mute = true;
            boton.sprite = muted;
        }

        Debug.Log("Mutiado");
    }
}
