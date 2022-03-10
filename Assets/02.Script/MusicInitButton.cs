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

    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LHANDCOLLIDER") || collision.gameObject.CompareTag("RHANDCOLLIDER"))
        {

            Debug.Log("����� ����");
            audioSource.Stop();
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
        Debug.Log("����� ����");
        audioSource.Stop();
        musicButton.ingmusic = false;
        musicButton.ismusic = false;
    }

}
