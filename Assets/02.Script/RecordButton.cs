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
            //���⼭ ���ܳ� ���� ������
            PlayerPrefs.SetString("Resulttext", resulttext.text);
        }
    }

    //������ư ����
    //��ġ�ϸ� 
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("HANDCOLLIDER")))
        {
            Debug.Log("�浹������?");
            if (isrecord == false)
            {
                Debug.Log("Startrecord �޼��� ž��");
                if (musicButton.ismusic == true)
                {
                    musicButton.MusicPause();
                }


                gcsrexam.StartRecordButtonOnClickHandler();
                isrecord = true;

            }
            else
            {
                Debug.Log("Stoprecord �޼��� ž��");
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
                Debug.Log("Startrecord �޼��� ž��");
                if (musicButton.ismusic == true)
                {
                    musicButton.MusicPause();
                }


                gcsrexam.StartRecordButtonOnClickHandler();
                isrecord = true;

            }
            else
            {
                Debug.Log("Stoprecord �޼��� ž��");
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



