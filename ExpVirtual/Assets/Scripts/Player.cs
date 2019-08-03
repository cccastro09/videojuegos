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
    public GameObject laser;
    public float offsetX = 0f;
    public float offsetY = 0f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float walkingSpeed;
    public float jumpSpeed;
    private int nvidas = 5;

    public Text puntaje;
    public GameObject panel;
    public Text score;

    public AudioSource jump;

    private void Awake()
    {
        trans = this.transform;
        body = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        
    }

    void Start()
    {
        ActualizaVida(nvidas);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { // y-axis movement
            body.velocity += jumpSpeed * Vector2.up;
            anim.SetBool("isJump", true);
            jump.Play();
            
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
        if(nvidas <= 0)
        {
            score.text = puntaje.text;
            panel.SetActive(true);
            Debug.Log("fin del juego");
            Time.timeScale = 0f;

        }

    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (body.velocity.x < 0.01)
            {
                anim.SetTrigger("Stand");
                //Shooting();
            }
            else
            {
                anim.SetTrigger("Shoot");
                Shooting();
            }


        }
    }

    private void Shooting()
    {
        GameObject ls = Instantiate(laser, transform.position, Quaternion.identity);
        ls.transform.position += new Vector3(offsetX, offsetY, 0);
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
        for (int i = 0; i < 5; i++)
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
