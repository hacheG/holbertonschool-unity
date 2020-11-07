using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SocialNetwork : MonoBehaviour
{

    public string gitHub = "https://github.com/hacheG";
    public string face = "https://www.facebook.com/hugo.trujillo.hache/";
    public string twiter = "https://twitter.com/HugoATrujillo";
    public string insta = "https://www.instagram.com/hachetrescomacatorce/";

    // Start is called before the first frame update
    public void OpenGit()
    {
        Application.OpenURL(gitHub);
    }

    public void OpenFace()
    {
        Application.OpenURL(face);
    }

    public void OpenTwiter()
    {
        Application.OpenURL(twiter);
    }

    public void OpenInsta()
    {
        Application.OpenURL(insta);
    }

}
