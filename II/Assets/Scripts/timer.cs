using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    bool stopped;
    float time;
    int ms, seconds, minutes;
    TMP_Text stopWatchText;

    // Start is called before the first frame update
    void Start(){
        stopped = false;
        stopWatchText = GetComponent<TMP_Text>();
        time = 0;
    }

    // Update is called once per frame
    void Update(){
        timerCalc();
    }

    void timerCalc(){
        if (!stopped){
            string fmt = "00";
            time += Time.deltaTime;
            ms = (int) ((time * 100) % 100);
            seconds = (int) (time % 60);
            minutes = (int) (time / 60);
            stopWatchText.text = "<mspace=0.55em>" + minutes + "</mspace>:<mspace=0.55em>" + seconds.ToString(fmt) + "</mspace>.<mspace=0.55em>" + ms.ToString(fmt);
        }
    }

    public float win(){
        stopped = true;
        stopWatchText.enabled = false;
        return time;
    }
}
