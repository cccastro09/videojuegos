using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMain : MonoBehaviour
{
    public float speed;
    public bool movingRight = true;
    // public GameObject tronco;
    //public GameObject tronco2;
    public AudioSource bad;
    public Animator anim;
    public Slider health;

    public GameObject slider;

    public int nvidas;

    public void Awake()
    {
        anim = this.GetComponent<Animator>();
        nvidas = 8;

    }

    // Update is called once per frame
    void Update()
    {
        health.value = nvidas;
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

        {
            if (collision.gameObject.tag == "Laser")
            {
                //  bad.Play();
                anim.SetBool("isDead", true);
                StartCoroutine(Esperar());

            }
        }

    }
   public void restar()
    {
        nvidas = nvidas - 1;
        Debug.Log("vida restada" + nvidas);
    }

    public void hideSlider()
    {
        slider.SetActive(false);
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("isDead", false);
    }
}
