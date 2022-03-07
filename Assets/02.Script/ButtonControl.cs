using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FrostweepGames.Plugins.GoogleCloud.SpeechRecognition;


public abstract class ButtonControl : MonoBehaviour
{


    void Start()
    {
       SphereCollider spc = gameObject.GetComponent<SphereCollider>();
    }

    //버튼과 충돌하면 어떤 기능을 한다.
    //추상메서드로 선언하고 바디 기능은 없애버림
    public abstract void OnCollisionEnter(Collision collision);
   
}
