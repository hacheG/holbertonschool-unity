using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// start timer once Player exits TimerTrigger's collider
/// </summary>
public class TimerTrigger : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerExit(Collider other)
    {
        Player.GetComponent<Timer>().enabled = true;
    }
}
