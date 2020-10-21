using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Stops timer and displays finishing time in large green text
/// </summary>
public class WinTrigger : MonoBehaviour
{
    public Text TimerText;
    public GameObject Player;
    public Timer timer;

    private void OnTriggerEnter(Collider other)
    {
        Player.GetComponent<Timer>().enabled = false;
        TimerText.fontSize = 36;
        TimerText.color = Color.green;
        timer.Win();
    }
}
