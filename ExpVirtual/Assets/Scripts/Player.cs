using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Transform trans;
    public Rigidbody2D body;
    public Animator anim;
    public GameObject[] vidas;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float walkingSpeed;
    public float jumpSpeed;
    private int nvidas = 3;

    private void Awake()
    {
        trans = this.transform;
        body = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        
    }

    void Start()
    {
        /*foreach(GameObject r in vidas)
        {
            r.SetActive(true);
        }*/
        ActualizaVida(nvidas);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { // y-axis movement
            body.velocity += jumpSpeed * Vector2.up;
            anim.SetBool("isJump", true);
            
        }

        if (body.velocity.y < 0.01)
        {
            anim.SetBool("isJump", false);
            body.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }else if(body.velocity.y > 0.01 && !Input.GetKeyDown(KeyCode.Space))
        {
            body.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        { // x-axis movement
            var v = body.velocity;
            var speed = 0f;
            if (Input.GetKey(KeyCode.A))
            {
                speed += -walkingSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                speed += walkingSpeed;
            }
            v.x = speed;
            body.velocity = v;
            { // Rotation around y-axis
                if (speed > 0.01)
                {
                    trans.rotation = Quaternion.Euler(0, 0, 0);
                    
                }
                else if (speed < -0.01)
                {
                    trans.rotation = Quaternion.Euler(0, 180, 0);
                    
                }
            }
            anim.SetFloat("Speed", Mathf.Abs(speed));
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Evil")
        {
            anim.SetBool("isDead", true);
            StartCoroutine(Esperar());
            
        }else if(collision.gameObject.tag == "Enemy")
        {
            anim.SetBool("isDead", true);
            StartCoroutine(Esperar());
            nvidas -= 1;
            ActualizaVida(nvidas);
        }
       
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(1.0f);
        anim.SetBool("isDead", false);
    }

    private void ActualizaVida(int n)
    {
        for (int i = 0; i < 3; i++)
        {
            if(i < n)
            {
                vidas[i].SetActive(true);
            }else
            {
                vidas[i].SetActive(false);
            }
            
        }
        
    }

}
