using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostweepGames.Plugins.GoogleCloud.SpeechRecognition.Examples;

public class RecordButton : ButtonControl
{


    GCSR_Example gcsrexam;
    public GameObject MainCamera;

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
            }else
            {
                Debug.Log("Stoprecord �޼��� ž��");
                gcsrexam.StopRecordButtonOnClickHandler();
                isrecord = false;
            }

        }
       
    }

}



