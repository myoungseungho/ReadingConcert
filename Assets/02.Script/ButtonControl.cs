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

    //��ư�� �浹�ϸ� � ����� �Ѵ�.
    //�߻�޼���� �����ϰ� �ٵ� ����� ���ֹ���
    public abstract void OnCollisionEnter(Collision collision);
   
}
