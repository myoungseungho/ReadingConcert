using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInitButton : ButtonControl
{
    AudioSource audioSource;
    MusicButton musicButton;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("MusicStartPauseButton").GetComponent<AudioSource>();
        musicButton = GameObject.Find("MusicStartPauseButton").GetComponent<MusicButton>();
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("HANDCOLLIDER")))
        {
            MusicStop();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            MusicStop();
        }
    }

    public void MusicStop()
    {
        Debug.Log("오디오 정지");
        audioSource.Stop();
        musicButton.ingmusic = false;
        musicButton.ismusic = false;
    }

}
