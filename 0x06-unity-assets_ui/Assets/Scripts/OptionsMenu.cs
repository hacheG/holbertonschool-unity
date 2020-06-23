using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    private string prevscene;
    public  PauseMenu varTest;
    
    //public string nameScene;
    
    // Start is called before the first frame update
    void Start()
    {
        //prevscene = PlayerPrefs.GetString("PrevScene");
         
    }

    // Update is called once per frame
    void Update()
    {
        //var varTest = FindObjectsOfType<PauseMenu>();
    }

    public void Back()
    {

        //Debug.Log( varTest.nameScene);
        //varTest.NombreDeEscenas(nameScene);
        SceneManager.LoadScene("MainMenu");
        //SceneManager.LoadScene( );

        //nameScene = varTest.NombreDeEscenas(nameScene);
        //nameScene = varTest.nameScene;

        //Time.timeScale = 1;
        //SceneManager.LoadScene(nameScene);
        //SceneManager.LoadScene(prevscene);
    }
}
