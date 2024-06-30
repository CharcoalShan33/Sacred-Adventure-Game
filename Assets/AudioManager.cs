using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource[] SFX, background;

    public static AudioManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null && instance != this  )
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(int sound)
    {
        StopSounds();
        if (sound < SFX.Length)
        {
            SFX[sound].Play();
        }
    }
    public void PlayBGM( int music)
    {
        StopTheMusic();
        if (music < background.Length)
        {
           background[music].Play();
        }


    }

    private void StopSounds()
    {
        foreach (AudioSource audio in SFX)
        {
            audio.Stop();
        }

        
    }

    private void StopTheMusic()
    {
        foreach (AudioSource music in background)
        {
            music.Stop();
        }
    }
}
