using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landing : MonoBehaviour
{
    public AudioSource m_Audio;
    public CharacterController controller;
    [Header("Landing audioclips")]
    public AudioClip[] grassLanding;
    public AudioClip[] rockLanding;

    float audioStepLengthLand = 0.65f;
    private bool step = true;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInParent<CharacterController>();
        m_Audio = GetComponent<AudioSource>();
    }

    IEnumerator WaitForLanding(float animClipLength)
    {
        yield return new WaitForSeconds(animClipLength);
    }

    void LandOnGrass()
    {
        m_Audio.clip = grassLanding[Random.Range(0, grassLanding.Length)];
        m_Audio.PlayOneShot(m_Audio.clip);
        StartCoroutine(WaitForLanding(audioStepLengthLand));
    }
    void LandOnRock()
    {
        m_Audio.clip = rockLanding[Random.Range(0, rockLanding.Length)];
        m_Audio.PlayOneShot(m_Audio.clip);
        StartCoroutine(WaitForLanding(audioStepLengthLand));
    }

    // Update is called once per frame
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (controller.isGrounded &&
            hit.gameObject.tag == "Untagged" &&
            step == true)
        {
            LandOnRock();
            Debug.Log("LandOnRock");
        }
        else if (
            controller.isGrounded &&
            controller.velocity.magnitude < 7 &&
            controller.velocity.magnitude > 5 &&
            hit.gameObject.tag == "Grass" &&
            step == true)
        {
            LandOnGrass();
            Debug.Log("LandOnGrass");
        }
    }


}
