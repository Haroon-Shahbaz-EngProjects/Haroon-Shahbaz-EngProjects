using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource levelMusic;
    public AudioSource deathSong;

    public bool LevelSong = true;
    public bool DeathSong = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LevelMusic()
    {
        LevelSong = true;
        DeathSong = false;
        levelMusic.Play();
    }

    public void DeathSound()
    {
        if (levelMusic.isPlaying)
            LevelSong = false;
        {
            levelMusic.Stop();
        }
        if (!deathSong.isPlaying && DeathSong == false)
        {
            deathSong.Play();
            DeathSong = true;
        }
    }



}
