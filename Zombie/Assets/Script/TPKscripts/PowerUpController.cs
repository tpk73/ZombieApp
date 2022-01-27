using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public static PowerUpController powerUpController;

    public Transform[] PowerUpPts;
    public GameObject uavPrefab;
    public GameObject medkitPrefab;
    //public Camera uavCam;
    int choosePowerUp;
    int randomPowerUpPts;
    int uavCount = 0;
    bool powerupAllowed;

     void Start()
    {
        //uavCam.enabled = false;
        powerupAllowed = true;
        InvokeRepeating("SpawnPowerUp", 0f, 5f);
    }

    void SpawnPowerUp()
    {
        if (powerupAllowed)
        {
            choosePowerUp = Random.Range(0, 10);
            randomPowerUpPts = Random.Range(0, PowerUpPts.Length);

            if(choosePowerUp < 9)
            {
                Instantiate(medkitPrefab, PowerUpPts[randomPowerUpPts].position, Quaternion.identity);
            }
            else
            {
                if (uavCount == 0)
                {
                    Instantiate(uavPrefab, PowerUpPts[randomPowerUpPts].position, Quaternion.identity);
                    uavCount++;
                } else
                {
                    Instantiate(medkitPrefab, PowerUpPts[randomPowerUpPts].position, Quaternion.identity);
                } 
            } 
        }
    }
}
