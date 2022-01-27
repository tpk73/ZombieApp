using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject settingPage;
    public GameObject leaderboardPage;
    public GameObject mainHUD;

    private void Start()
    {
        settingPage.SetActive(false);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("ZombieRun");
    }

    public void SettingPage()
    {
        settingPage.SetActive(true);
        mainHUD.SetActive(false);
    }

    public void GoBackToHome()
    {
        settingPage.SetActive(false);
        mainHUD.SetActive(true);
    }
}
