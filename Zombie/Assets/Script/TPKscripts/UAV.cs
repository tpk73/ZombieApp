using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UAV : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //PowerUpController.powerUpController.uavCam.enabled = true;
            Destroy(gameObject);
        }
    }
}
