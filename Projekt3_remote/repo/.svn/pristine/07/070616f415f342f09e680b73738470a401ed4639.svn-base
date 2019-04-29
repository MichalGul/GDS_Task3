using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    public AudioClip MusicClip;
    public AudioSource MusicSource;
    private bool playing;

    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = MusicClip;
        MusicSource.Play();
        playing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (playing)
            {
                MusicSource.Stop();
                playing = false;
            }
            else
            {
                MusicSource.Play();
                playing = true;


            }
        }
    }
}
