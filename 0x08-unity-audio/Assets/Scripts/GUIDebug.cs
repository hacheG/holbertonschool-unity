using UnityEngine;
using System.Collections;

public class GUIDebug : MonoBehaviour
{

    private AnimationState _animState;


    // Get the id of all state for this object
    int runId = Animator.StringToHash("Run");
    int jumpId = Animator.StringToHash("Jump");

    Animator _animator;
    AnimatorStateInfo animStateInfo;

    void Start()
    {
        animStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
    }


    void OnGUI()
    {
        GUI.TextArea(new Rect(25, 25, 100, 30), animStateInfo.fullPathHash.ToString());


    }

}
