using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class DesencadenarAnim : MonoBehaviour
{
    public Animator stickerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stickerAnimator.SetTrigger("Play");
    }
}
