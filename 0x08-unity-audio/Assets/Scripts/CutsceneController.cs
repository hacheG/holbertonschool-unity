using UnityEngine;
using System.Collections;
public class CutsceneController : MonoBehaviour
{
    private Animator intro01;
    // public GameObject pc;
    // public Camera mc;
    // public GameObject pCon;
    // public GameObject timerCanvas;
    public GameObject[] sceneStart;
    // public CutsceneController csCon;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(string.Format("Start time = {0}", Time.time));
        intro01 = GetComponent<Animator>();
        // mc = GetComponent<Camera>();
        // timerCanvas = GetComponent<GameObject>();
        // csCon = GetComponent<CutsceneController>();

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(string.Format("Time before call transitions = {0}", Time.time));
        if (intro01.GetCurrentAnimatorStateInfo(0).IsName("Intro01") && intro01.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            StartCoroutine(transitions());
        }
    }

    IEnumerator transitions()
    {
        foreach (GameObject go in sceneStart)
        {
            // Debug.Log(string.Format("Object = {0} and current time = {1}", go.name, Time.time));
            if (go.activeInHierarchy == false)
            {
                go.SetActive(true);
            }
            if (go.GetComponent<PlayerController>() != null)
            {
                go.GetComponent<PlayerController>().enabled = true;
            }
            else
            {
                continue;
            }
        }
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
    }
}
