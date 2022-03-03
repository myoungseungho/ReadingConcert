using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FrostweepGames.Plugins.GoogleCloud.SpeechRecognition;

public class VoiceControl : MonoBehaviour
{
    //�ڷ��� ����
    GCSpeechRecognition gcspeech;

    //���� ��ư ���
    public bool starttoogle = true;
    public bool stoptoogle = false;

    //�ν� �Ǿ��� �� �̹���
    public Image stateimage;


    //�ѱ� ��� ���
    public Text resulttext;


    // Start is called before the first frame update
    void Start()
    {
        gcspeech.RecordFailedEvent += RecordFailedEventHandler;
        gcspeech.RecognizeSuccessEvent += RecognizeSuccessEventHandler;
    }


    private void OnDestroy()
    {
        gcspeech.RecordFailedEvent -= RecordFailedEventHandler;
        gcspeech.RecognizeSuccessEvent -= RecognizeSuccessEventHandler;
    }

    public void StartRecord()
    {
        //������ �ѳ��´�.
        starttoogle = false;
        stoptoogle = true;
        resulttext.text = string.Empty;
        gcspeech.StartRecord(true);
    }

    public void EndRecord()
    {
        stoptoogle = false;
        starttoogle = true;
        gcspeech.StopRecord();
    }

    private void RecordFailedEventHandler()
    {
        stateimage.color = Color.yellow;
        resulttext.text = "<color=red>Start record Failed. Please check microphone device and try again.</color>";

        stoptoogle = false;
        starttoogle = true;
    }

    private void RecognizeSuccessEventHandler(RecognitionResponse recognitionResponse)
    {
        resulttext.text = "Recognize Success.";
        InsertRecognitionResponseInfo(recognitionResponse);
    }
    private void InsertRecognitionResponseInfo(RecognitionResponse recognitionResponse)
    {
        if (recognitionResponse == null || recognitionResponse.results.Length == 0)
        {
            resulttext.text = "\nWords not detected.";
            return;
        }

        resulttext.text += "\n" + recognitionResponse.results[0].alternatives[0].transcript;

        var words = recognitionResponse.results[0].alternatives[0].words;

    }
}


