using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;

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
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetTrigger("Wait");
    }
}
