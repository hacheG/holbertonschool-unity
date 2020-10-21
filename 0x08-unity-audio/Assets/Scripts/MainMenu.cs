using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Adds functionality to UI in MainMenu
/// </summary>
public class MainMenu : MonoBehaviour
{
    public enum Action
    {
        MAINMENU,
        RESUME,
        OPTIONS,
        EXIT,
        LEVEL01,
        LEVEL02,
        LEVEL03,
        PAUSE,
        RESTART
    }
    public Action m_action;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        switch (m_action)
        {
            case Action.LEVEL01:
                this.GetComponent<Button>().onClick.AddListener(delegate { LevelSelect("Level01"); });
                return;
            case Action.LEVEL02:
                this.GetComponent<Button>().onClick.AddListener(delegate { LevelSelect("Level02"); });
                return;
            case Action.LEVEL03:
                this.GetComponent<Button>().onClick.AddListener(delegate { LevelSelect("Level03"); });
                return;
            case Action.OPTIONS:
                this.GetComponent<Button>().onClick.AddListener(Options);
                return;
            case Action.EXIT:
                this.GetComponent<Button>().onClick.AddListener(Exit);
                return;
        }

    }
    /// <summary>
    /// Selects different level of game
    /// </summary>
    /// <param name="level">Name of scene, to be input in Unity Editor</param>
    public void LevelSelect(string level)
    {
        SceneManager.LoadScene(level);
    }

    /// <summary>
    /// Shows options menu
    /// </summary>
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    /// <summary>
    /// Exits game
    /// </summary>
    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        PlayerPrefs.SetString("PrevScene", SceneManager.GetActiveScene().name);
        //   Debug.Log("Previous scene now set to " + PlayerPrefs.GetString("PrevScene"));
    }
}