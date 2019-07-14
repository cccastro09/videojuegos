using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fin : MonoBehaviour
{
    public Text puntaje;
    public GameObject panel;
    public Text score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score.text = puntaje.text;
        panel.SetActive(true);
        Debug.Log("fin");
        this.GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
