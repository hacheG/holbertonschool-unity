using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        Scene escena = SceneManager.GetActiveScene();
        print(string.Format("name: {0} - index: {1}", escena.name, escena.buildIndex));
        if (escena.buildIndex == 3)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene(escena.buildIndex + 1);
        }
    }
}
