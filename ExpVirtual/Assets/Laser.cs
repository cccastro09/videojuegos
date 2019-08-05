﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float SpeedLaser = 5.0f;
    private bool right = false;
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        if(Player.right)
        {
            right = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        boss = GameObject.Find("MainBoss");
        if (right)
        {
            transform.Translate(Vector3.right * SpeedLaser * Time.deltaTime);
        }else
        {
            transform.Translate(Vector3.left * SpeedLaser * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Alien")
        {
            Debug.Log("Impacto");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "boss")
        {
            Debug.Log("ImpactoBoss");
            //Destroy(collision.gameObject);
            // Destroy(gameObject);
           // boss.GetComponent<BossMain>().restar();
            if (boss.GetComponent<BossMain>().nvidas == 0)
            {
                Destroy(boss);
            }
            else
            {
                boss.GetComponent<BossMain>().restar();
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);

    }
}
