using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertToggle;
    public Button backBtn;
    public Button applyBtn;
    private static string prevscene;
    private int prevtoggle;
    public static int inversionState;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        prevscene = PlayerPrefs.GetString("PrevScene");
        prevtoggle = PlayerPrefs.GetInt("InvertY");
    }

    void Update()
    {
        backBtn.onClick.AddListener(Back);
        applyBtn.onClick.AddListener(Apply);
    }

    /// <summary>
    ///Toggle triggered do something.
    /// </summary>
    public void eventTriggerInvertY()
    {
        bool isOn = invertToggle.GetComponent<Toggle>().isOn;
        if (isOn)
        {
            inversionState = 1;
        }
        else
        {
            inversionState = 0;
        }
        SetInt();
        // Debug.Log("playerprefs(inverty) set to: " + PlayerPrefs.GetInt("InvertY"));
    }
    /// <summary>
    /// Set y-inversion toggle state
    /// </summary>
    public static void SetInt()
    {
        PlayerPrefs.SetInt("InvertY", inversionState);
    }
    /// <summary>
    /// Navigate to previous scene
    /// </summary>
    public void Back()
    {
        PlayerPrefs.SetInt("InvertY", prevtoggle);
        SceneManager.LoadScene(prevscene);
    }
    /// <summary>
    /// save changes and return to previous scene
    /// </summary>
    public void Apply()
    {
        // eventTriggerInvertY();
        PlayerPrefs.Save();
        SceneManager.LoadScene(prevscene);
    }
}
