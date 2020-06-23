using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    float escala = 0;
    public GameObject pauseScene;
    public string nameScene;
    //Scene escenaActual;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
        
    }
    
    public void NombreDeEscenas(string nameScene)
    {
        //Scene scene = SceneManager.GetActiveScene();
        if (nameScene == "level01")
        {
            nameScene = "Level01";
            //return nameScene;

        }
        if (nameScene == "level02")
        {
            nameScene = "Level02";
            //return nameScene;

        }
        if (nameScene == "level03")
        {
            nameScene = "Level03";
            //return nameScene;

        }
        //return nameScene;
        print(nameScene);
    }
    

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escala = 0;
            Debug.Log("click escape");
            pauseScene.SetActive(true);
            Time.timeScale = escala;
        }

    }

    public void Resume()
    {
        escala = 1;
        Debug.Log("click resume");
        pauseScene.SetActive(false);
        Time.timeScale = escala;
    }

    public void Restart()
    {
        Scene escenaActual = SceneManager.GetActiveScene();
        //print(escenaActual.name);
        escala = 1;
        SceneManager.LoadScene(escenaActual.name);
        Time.timeScale = escala;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void MyBack()
    {
        var found = FindObjectsOfType<GameObject>();
        print(found.Length);
    }
}
