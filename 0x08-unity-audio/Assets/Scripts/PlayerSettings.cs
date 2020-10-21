using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // set default PlayerPrefs at game start
        PlayerPrefs.SetInt("InvertY", 0);
        PlayerPrefs.SetString("PrevScene", "MainMenu");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
