using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public GameObject player;
    public Text timerText;
    public GameObject winCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            player.GetComponent<Timer>().enabled = false;
            timerText.color = Color.green;
            timerText.fontSize = 60;
            winCanvas.SetActive(true);
            Debug.Log("enter");
        }
    }
}