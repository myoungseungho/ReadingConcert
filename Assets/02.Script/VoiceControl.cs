using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostweepGames.Plugins.GoogleCloud.SpeechRecognition;

public class VoiceControl : MonoBehaviour
{
    //�ڷ��� ����
    GCSpeechRecognition gcspeech;
    public GameObject Button;
    SphereCollider buttoncollider;

    //��������Ʈ ����
    //��ư�� Ŭ������ �� gcspeech�� startrecord() �Լ��� ȣ���ϰ� �ʹ�.
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
