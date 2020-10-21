using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float time = 0.0f;

    public GameObject winCanvas;
    public Text finalTime;
    public GameObject _camera;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        string seconds = (time % 60).ToString("00.00");
        string minutes = Mathf.Floor((time % 3600) / 60).ToString();
        TimerText.text = minutes + ":" + seconds;
    }
    /// <summary>
    /// Display player's finish time in WinCanvas
    /// </summary>
    public void Win()
    {
        TimerText.enabled = false;
        _camera.GetComponent<CameraController>().enabled = false;
        Time.timeScale = 0;
        finalTime.text = TimerText.text;
        winCanvas.SetActive(true);
    }
}
