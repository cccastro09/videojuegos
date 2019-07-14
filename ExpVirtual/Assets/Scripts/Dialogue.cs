using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text lineDialogue;
    public Button go;
    public GameObject panelDialogue;
    public string line;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        go.onClick.AddListener(delegate { Hide();});
        lineDialogue.text = line;
        panelDialogue.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Hide()
    {
        Time.timeScale = 1f;
        panelDialogue.SetActive(false);
        Destroy(this);
    }
}
