using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostweepGames.Plugins.GoogleCloud.SpeechRecognition;

public class VoiceControl : MonoBehaviour
{
    //자료형 선언
    GCSpeechRecognition gcspeech;
    public GameObject Button;
    SphereCollider buttoncollider;

    //델리게이트 선언
    //버튼을 클릭했을 때 gcspeech의 startrecord() 함수를 호출하고 싶다.
    delegate void ButtonClick();
    
    
    // Start is called before the first frame update
    void Start()
    {
       buttoncollider = Button.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
