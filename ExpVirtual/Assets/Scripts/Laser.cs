using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float SpeedLaser = 5.0f;
    private bool right = false;
    public GameObject boss,t1,t2,collideEnemy;



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
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "boss")
        {
            Debug.Log("ImpactoBoss");
            Destroy(this.gameObject);
            if (boss.GetComponent<BossMain>().nvidas == 0)

            {
                Destroy(boss);
                t1 = GameObject.Find("limitboss");
                t2 = GameObject.Find("limitboss2");
                collideEnemy = GameObject.Find("collideEnemy(10)");
                Destroy(t1);
                Destroy(t2);
                Destroy(collideEnemy);

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
