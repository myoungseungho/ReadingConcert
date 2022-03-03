using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FrostweepGames.Plugins.GoogleCloud.SpeechRecognition;


public class ButtonControl : MonoBehaviour
{
    VoiceControl vc;


    void Start()
    {
        SphereCollider spc = gameObject.GetComponent<SphereCollider>();
    }

    //버튼과 충돌하면 어떤 기능을 한다.
    //이 함수는 상속할 것이다.
    public virtual void OnCollisionEnter(Collision collision)
    {
        //버튼을 터치했을 때
        if (collision.gameObject.CompareTag("LHANDCOLLIDER") || collision.gameObject.CompareTag("RHANDCOLLIDER"))
        {
            //토글이 꺼져있을 때
            if (vc.starttoogle == false)
            {
                //녹음 시작
                vc.StartRecord();
            }
            else
            {
                vc.EndRecord();
            }
        }
    }
}
