using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FrostweepGames.Plugins.GoogleCloud.SpeechRecognition;

public class VoiceControl : MonoBehaviour
{
    //자료형 선언
    GCSpeechRecognition gcspeech;

    //녹음 버튼 토글
    public bool starttoogle = true;
    public bool stoptoogle = false;

    //인식 되었을 때 이미지
    public Image stateimage;


    //한글 결과 토글
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
        //녹음을 켜놓는다.
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


