using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public AdManager adManager;
    //public Text timer;
    //public Text ptsText;
    //public Text gameOverPrompt;

    public void Setup()
    {
        gameObject.SetActive(true);
        //ptsText.text = score.ToString() + " Points";
    }


    public void RestartButton()
    {
        //adman do it
        //adManager.ShowInterstitialAd();
        SceneManager.LoadScene("ZombieRun");

    }
    public void HomeButton()
    {
        //adman do it
        adManager.ShowInterstitialAd();
        SceneManager.LoadScene("MainMenu");
    }
}
