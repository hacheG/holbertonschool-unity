using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    public Button menuBtn;
    public Button nextBtn;
    // Start is called before the first frame update
    void Start()
    {
        menuBtn.onClick.AddListener(MainMenu);
        nextBtn.onClick.AddListener(Next);
    }
    /// <summary>
    /// Navigate back to Main menu
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    /// <summary>
    /// Navigate to next level
    /// </summary>
    public void Next()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
