using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    public AudioSource machine_bad;
    public Transform target;
    public float speed;

    private Vector3 start, end;
    
    private void Start()
    {
        anim = this.GetComponent<Animator>();
        if(target != null)
        {
            target.parent = null;
            start = transform.position;
            end = target.position;
        }
        
    }

    private void FixedUpdate()
    {
        if(target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        }
        if(transform.position == target.position)
        {
            target.position = (target.position == start) ? end : start;
        }
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
        //machine_bad.Play();
    }

    
}
