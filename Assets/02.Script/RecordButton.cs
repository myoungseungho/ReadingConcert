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
    //������ư ����
    public override void OnCollisionEnter(Collision collision)
    {

    }



    void Start()
    {
        gcsrexam = MainCamera.GetComponent<GCSR_Example>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))/*collision.collider.CompareTag("LHANDCOLLIDER") || collision.collider.CompareTag("RHANDCOLLIDER")*/
        {
            if (isrecord == false)
            {
                Debug.Log("Startrecord �޼��� ž��");
                gcsrexam.StartRecordButtonOnClickHandler();
                isrecord = true;
                Invoke("TransferText", 1f);
            }else
            {
                Debug.Log("Stoprecord �޼��� ž��");
                gcsrexam.StopRecordButtonOnClickHandler();
                isrecord = false;
                Invoke("TransferText", 1f);
            }
        }
    }



       

    void TransferText()
    {
        resulttext.text = gcsrexam._resultText.text;
    }

}



