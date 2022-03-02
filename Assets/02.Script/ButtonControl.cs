using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FrostweepGames.Plugins.GoogleCloud.SpeechRecognition;


public class ButtonControl : MonoBehaviour
{
    //상속, 부모 클래스에서만 사용가능한 필드
    protected GCSpeechRecognition gcspeech;

    //켰다 껐다
    bool toogle = false;
    Text resulttext;

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
            //toogle이 false일 때
            if (!toogle)
            {
                //녹음을 켜놓는다.
                gcspeech.StartRecord(false);
                toogle = true;
            }
            else
            {
                //녹음을 꺼놓는다.
                gcspeech.StopRecord();
                toogle = false;
            }

        }
    }
}
