using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // public enum Action { RESUME, RESTART, OPTIONS, MAINMENU }
    // public Action p_action;
    public Button resumeBtn;
    public Button restartBtn;
    public Button optionsBtn;
    public Button mainMenuBtn;
    public GameObject pauseCanvas;
    public new Camera camera;
    private int activeScene;
    private static string prevscene;
    /// <summary>
    /// assign pause GameObject
    /// </summary>
    void Awake()
    {
        // pause = GetComponent<Canvas>();
        // camera = camera.GetComponent<CameraController>();
        activeScene = SceneManager.GetActiveScene().buildIndex;
        prevscene = PlayerPrefs.GetString("PrevScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        // switch (p_action)
        // {
        //     case Action.RESUME:
        //         this.GetComponent<Button>().onClick.AddListener(Resume);
        //         return;
        //     case Action.RESTART:
        //         this.GetComponent<Button>().onClick.AddListener(Restart);
        //         return;
        //     case Action.OPTIONS:
        //         this.GetComponent<Button>().onClick.AddListener(Options);
        //         return;
        //     case Action.MAINMENU:
        //         this.GetComponent<Button>().onClick.AddListener(MainMenu);
        //         return;
        // }
    }
    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetString("PrevScene", SceneManager.GetActiveScene().name);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseCanvas.activeInHierarchy == false)
            {
                Pause();
            }
            else if (pauseCanvas.activeInHierarchy == true)
            {
                Resume();
            }
        }
    }
    /// <summary>
    /// Pauses gameplay and timer
    /// </summary>
    public void Pause()
    {
        camera.GetComponent<CameraController>().enabled = false;
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
        resumeBtn.onClick.AddListener(Resume);
        restartBtn.onClick.AddListener(Restart);
        optionsBtn.onClick.AddListener(Options);
        mainMenuBtn.onClick.AddListener(MainMenu);
    }
    /// <summary>
    /// Resumes gameplay and timer
    /// </summary>
    public void Resume()
    {
        camera.GetComponent<CameraController>().enabled = true;
        Time.timeScale = 1;
        // Debug.Log("playerprefs(inverty) set to: " + PlayerPrefs.GetInt("InvertY"));
        pauseCanvas.SetActive(false);
    }
    /// <summary>
    /// Reloads level scene that player is currently in
    /// </summary>
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(activeScene);
    }
    /// <summary>
    /// Shows options menu
    /// </summary>
    public void Options()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Options");
    }

    /// <summary>
    /// Loads Main Menu level selection scene
    /// </summary>
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
