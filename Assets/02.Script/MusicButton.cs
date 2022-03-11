using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : ButtonControl
{

    public bool ismusic = false;
    public bool ingmusic = false;
    AudioSource audioSource;


    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

    }
    public override void OnTriggerEnter(Collider other)
    {
        
            if (ismusic == false)
            {
                MusicStart();
            }
            else
            {
                MusicPause();
            }
        
    }

    private void Update()
    {



        if (Input.GetKeyDown(KeyCode.H))
        {
            if (ismusic == false)
            {
                MusicStart();
            }
            else
            {
                MusicPause();
            }
        }
    }


    public void MusicStart()
    {
        Debug.Log("오디오 시작");
        ingmusic = true;
        ismusic = true;
        audioSource.Play();
    }

    public void MusicPause()
    {
        Debug.Log("오디오 일시 정지");
        ingmusic = true;
        ismusic = false;
        audioSource.Pause();
    }
}
