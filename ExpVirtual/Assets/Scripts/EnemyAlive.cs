using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlive : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public bool movingRight = true;
    public AudioSource bad;
   
    // Update is called once per frame
    void Update()
    {


        if (movingRight)
        {
            transform.Translate(1 * Time.deltaTime * speed, 0,0);
            transform.localScale = new Vector2(0.28529f, 0.28529f);
        }
        else
        {
            transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-0.28529f, 0.28529f);
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
                bad.Play();

            }
        }

    }
}
