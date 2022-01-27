using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float currHealth;
    public float maxHealth = 100f;
    public float damage;
    public Camera uavCam;

    public int pts = 0;
    public Text score;
    public Text inGameScore;
    public Text totalPts;

    public static Player player;
    public HealthBar healthBar;
    public GameObject deathScreen;
    public GameObject HUD;

    public AudioSource playerHit;
    public AudioSource itemPickUp;

    

    bool isAlive;

    void Start()
    {
        uavCam.enabled = false;
        isAlive = true;
        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        StartCoroutine(PlayerPts());
        totalPts.text = PlayerPrefs.GetInt("HIGHSCORE", 0).ToString();
    }
    private void FixedUpdate()
    {
         damage = UnityEngine.Random.Range(15f, 25f);
    }

    void Update()
    {
        GameOver();
        PlayerPts();
    }


    // insert leader board for game over here
    void GameOver()
    {
        if(currHealth <= 0)
        {
            isAlive = false;
            HUD.SetActive(false);
            deathScreen.SetActive(true);
            
        }
       
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            TakeDamage(damage);
            Destroy(collision.gameObject);
            playerHit.Play();
            pts += 2;
        }
        else if(collision.gameObject.tag == "MedKit")
        {
            itemPickUp.Play();
            if (currHealth < maxHealth)
            {
                UpdateHealth(25);

                if (currHealth > maxHealth)
                {
                    UpdateHealth(0);
                }
            }
            Debug.Log(currHealth);
            Destroy(collision.gameObject);
            pts += 1;
        }
        else if(collision.gameObject.tag == "UAV")
        {
            itemPickUp.Play();
            uavCam.enabled = true;
            Destroy(collision.gameObject);
            pts += 3;
        }
    }
    private void UAV()
    {
        uavCam.enabled = true;
    }

    private void UpdateHealth(float health)
    {
        if (currHealth < maxHealth)
        {
            currHealth += 25;

            if (currHealth > maxHealth)
            {
                currHealth = maxHealth;
            }
        }

        healthBar.SetHealth(currHealth);
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;
        healthBar.SetHealth(currHealth);
    }

    public IEnumerator PlayerPts()
    {
        yield return new WaitForSeconds(3f);

        while (isAlive == true)
        {
            pts += 1;
            inGameScore.text = pts.ToString();
            yield return new WaitForSeconds(1f);
            Debug.Log(pts);  
        }

        score.text = pts.ToString();
        
        totalPts.text = pts.ToString();
        totalPts.text = PlayerPrefs.GetInt("HIGHSCORE", 0).ToString();
        
        if (pts > PlayerPrefs.GetInt("HIGHSCORE", 0))
        {
            PlayerPrefs.SetInt("HIGHSCORE", pts);
            totalPts.text = pts.ToString();
        }
    }
}
   


