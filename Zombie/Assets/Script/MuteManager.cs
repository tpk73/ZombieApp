using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteManager : MonoBehaviour
{
    private bool isMuted;
    public GameObject checkmark;

    // Start is called before the first frame update
    void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED") == 1;
        AudioListener.pause = isMuted;
    }

    public void MutePressed()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
        if (isMuted)
        {
            checkmark.SetActive(false);
        }
        else
        {
            checkmark.SetActive(true);
        }
    }

}
