using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    public AudioSource machine_bad;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Fire");
            Debug.Log("this is a test");
            machine_bad.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetTrigger("Wait");
        machine_bad.Play();
    }
}
