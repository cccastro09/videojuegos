using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float SpeedLaser = 5.0f;
    private bool right = false;

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
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
