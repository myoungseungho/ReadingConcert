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

    //��ư�� �浹�ϸ� � ����� �Ѵ�.
    //�� �Լ��� ����� ���̴�.
    public virtual void OnCollisionEnter(Collision collision)
    {
        //��ư�� ��ġ���� ��
        if (collision.gameObject.CompareTag("LHANDCOLLIDER") || collision.gameObject.CompareTag("RHANDCOLLIDER"))
        {
            //����� �������� ��
            if (vc.starttoogle == false)
            {
                //���� ����
                vc.StartRecord();
            }
            else
            {
                vc.EndRecord();
            }
        }
    }
}
