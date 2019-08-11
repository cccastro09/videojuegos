using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMain : MonoBehaviour
{
    public float speed;
    public bool movingRight = true;
    // public GameObject tronco;
    //public GameObject tronco2;
    public AudioSource bad;

    public int nvidas = 3;

    // Update is called once per frame
    void Update()
    {

        if (movingRight)
        {
            transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.Translate(1 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Limit"))
            {

               


                if (movingRight)
                {
                    movingRight = false;
                }
                else
                {
                    movingRight = true;
                }



            }


        }

        {
            if (collision.gameObject.tag == "Player")
            {
                //  bad.Play();
                bad.Play();

            }
        }

    }
   public void restar()
    {
        nvidas -= 1;
        Debug.Log("vida restada");
    }
}
