using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public static ZombieController zombieController;

    Rigidbody rb;
    private GameObject target;
    public float moveSpeed;
    //public float zombieStrength;
    //public float damage;
    Vector3 dirToTarget;
    public static bool spawnAllowed;

    void Start()
    {
        target = GameObject.FindWithTag("Player");
        Debug.Log("FoundPlayer");
        rb = GetComponent<Rigidbody>();
        moveSpeed = UnityEngine.Random.Range(5f, 8.5f);
        //zombieStrength = UnityEngine.Random.Range(15f, 25f);
        //damage = zombieStrength;
        //Debug.Log(damage);
    }

    void Update()
    {
        MoveZombie();
    }

    private void MoveZombie()
    {
        if (target != null)
        {
            // move
            dirToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector3(dirToTarget.x * moveSpeed,0, dirToTarget.z * moveSpeed);
            // rot
            transform.LookAt(target.transform);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
