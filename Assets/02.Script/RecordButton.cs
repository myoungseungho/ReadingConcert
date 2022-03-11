using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FrostweepGames.Plugins.GoogleCloud.SpeechRecognition.Examples;

public class RecordButton : ButtonControl
{


    GCSR_Example gcsrexam;
    public GameObject MainCamera;
    public Text resulttext;
    bool isrecord = false;
    MusicButton musicButton;


    private void OnEnable()
    {
        GCSR_Example.imagechangemoment += ChangeImage;
        GCSR_Example.textchangemoment += ChangeText;

    }

    private void OnDisable()
    {
        GCSR_Example.imagechangemoment -= ChangeImage;
        GCSR_Example.textchangemoment += ChangeText;

    }

    void ChangeImage()
    {
        gameObject.GetComponent<Renderer>().material.color = gcsrexam._speechRecognitionState.color;
    }

    void ChangeText()
    {
        resulttext.text = gcsrexam._resultText.text;
        if (isrecord == false)
        {
            //여기서 생겨난 글을 저장함
            PlayerPrefs.SetString("Resulttext", resulttext.text);
        }
    }

    //녹음버튼 관련
    //터치하면 
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("HANDCOLLIDER")))
        {
            Debug.Log("충돌찍히나?");
            if (isrecord == false)
            {
                Debug.Log("Startrecord 메서드 탑승");
                if (musicButton.ismusic == true)
                {
                    musicButton.MusicPause();
                }


                gcsrexam.StartRecordButtonOnClickHandler();
                isrecord = true;

            }
            else
            {
                Debug.Log("Stoprecord 메서드 탑승");
                gcsrexam.StopRecordButtonOnClickHandler();
                isrecord = false;
                Invoke("TransferText", 2f);
                if (musicButton.ingmusic == true)
                {
                    musicButton.MusicStart();
                }


            }
        }

    }

    void Start()
    {
        gcsrexam = MainCamera.GetComponent<GCSR_Example>();
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        musicButton = GameObject.Find("MusicStartPauseButton").GetComponent<MusicButton>();
        resulttext.text = PlayerPrefs.GetString("Resulttext");

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))/*collision.collider.CompareTag("LHANDCOLLIDER") || collision.collider.CompareTag("RHANDCOLLIDER")*/
        {
            if (isrecord == false)
            {
                Debug.Log("Startrecord 메서드 탑승");
                if (musicButton.ismusic == true)
                {
                    musicButton.MusicPause();
                }


                gcsrexam.StartRecordButtonOnClickHandler();
                isrecord = true;

            }
            else
            {
                Debug.Log("Stoprecord 메서드 탑승");
                gcsrexam.StopRecordButtonOnClickHandler();
                isrecord = false;
                Invoke("TransferText", 2f);
                if (musicButton.ingmusic == true)
                {
                    musicButton.MusicStart();
                }


            }
        }
    }
}



