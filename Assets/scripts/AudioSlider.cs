using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSlider : MonoBehaviour
{
    public AudioSource MusicControl;
    private float musicVol = 1f;
    void Start()
    {
        MusicControl.Play();
    }

    void Update()
    {
        MusicControl.volume = musicVol;
    }

    public void updateVol(float volume)
    {
        musicVol = volume;
}
}