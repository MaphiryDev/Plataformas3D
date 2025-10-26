using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{

    [SerializeField] private AudioSource sfxSource, musicSource;

    [SerializeField] private AudioClip musicGame, musicClick;

    [SerializeField] private Slider sliderMusic, sliderSFX;

    public static MusicController instance;

    private void Awake()
    {
        instance = this; 
    }

    public void PlayEffect()
    {
        sfxSource.PlayOneShot(musicClick);
    }

     void Start()
    {
        musicSource.clip = musicGame;
        musicSource.Play();
    }

    public void VolumeMusicUpdate()
    {
        musicSource.volume = sliderMusic.value;
    }

    public void SFXVolumeUpdate()
    {
        sfxSource.volume = sliderSFX.value; 
    }

}
