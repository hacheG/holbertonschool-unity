using UnityEngine;
using System.Collections;

public class footsteps : MonoBehaviour
{
    public AudioSource m_Audio;
    public CharacterController controller;
    [Header("Footstep audioclips")]
    public AudioClip[] grassRunning;
    public AudioClip[] rockRunning;

    private bool step = true;
    float audioStepLengthRun = 0.25f;

    void Start()
    {
        controller = GetComponentInParent<CharacterController>();
        m_Audio = GetComponent<AudioSource>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (controller.isGrounded &&
        controller.velocity.magnitude < 7 &&
        controller.velocity.magnitude > 5 &&
        hit.gameObject.tag == "Untagged" &&
        step == true)
        {
            RunOnRock();
        }
        else if (
            controller.isGrounded &&
            controller.velocity.magnitude > 8 &&
            hit.gameObject.tag == "Grass" &&
            step == true)
        {
            RunOnGrass();
        }

    }

    IEnumerator WaitForFootSteps(float stepsLength)
    {
        step = false;
        yield return new WaitForSeconds(stepsLength);
        step = true;
    }
    void RunOnRock()
    {
        m_Audio.clip = rockRunning[Random.Range(0, rockRunning.Length)];
        m_Audio.Play();
        StartCoroutine(WaitForFootSteps(audioStepLengthRun));
    }
    void RunOnGrass()
    {
        m_Audio.clip = grassRunning[Random.Range(0, grassRunning.Length)];
        m_Audio.Play();
        StartCoroutine(WaitForFootSteps(audioStepLengthRun));
    }


}