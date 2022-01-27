using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public static CountDown countDown;
    public int countDownTime;
    public Text countDisplay;
    public AudioSource countdownAudio;
    public AudioSource startAudio;

    //public AudioClip countdownAudio;

    public void Start()
    {
        //Time.timeScale = 1f;
        StartCoroutine(countDownToStart());
        countdownAudio = GetComponent<AudioSource>();
        //startAudio = GetComponent<AudioSource>();
    }
    public IEnumerator countDownToStart()
    {
       
        while (countDownTime > 0)
        {
            countDisplay.text = countDownTime.ToString();

            yield return new WaitForSeconds(1f);

            countDownTime--;

            PlayAudio();
           
        }

      

        countDisplay.text = "SURVIVE";
        StartAudio();

        Timer.timer.beginTimer();
        //GameController.gameController.BeginGame();

        yield return new WaitForSeconds(1f);

        countDisplay.gameObject.SetActive(false);
    }

    public void PlayAudio()
    {
        countdownAudio.Play();
    }
    public void StartAudio()
    {
        startAudio.Play();
    }
}
