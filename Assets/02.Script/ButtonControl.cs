using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FrostweepGames.Plugins.GoogleCloud.SpeechRecognition;


public class ButtonControl : MonoBehaviour
{
    //���, �θ� Ŭ���������� ��밡���� �ʵ�
    protected GCSpeechRecognition gcspeech;

    //�״� ����
    bool toogle = false;
    Text resulttext;

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
            //toogle�� false�� ��
            if (!toogle)
            {
                //������ �ѳ��´�.
                gcspeech.StartRecord(false);
                toogle = true;
            }
            else
            {
                //������ �����´�.
                gcspeech.StopRecord();
                toogle = false;
            }

        }
    }
}
