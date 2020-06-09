using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public GameObject player;
    
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            player.GetComponent<Timer>().enabled = true;
            //Debug.Log("exit");
        }
    }
}
