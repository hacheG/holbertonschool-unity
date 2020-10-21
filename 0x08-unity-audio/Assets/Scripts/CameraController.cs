using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public GameObject go;
    Vector3 offset;
    public float distance = 4.0f;
    public float height = 1.0f;
    public float damping = 5.0f;
    public float rotationDamping = 10.0f;
    public float rotateSpeed = 5.0f;

    private float xAxis = 0f;
    private float yAxis = 2.5f;
    public bool isInverted;
    public



    // Start is called before the first frame update
    void Start()
    {
        offset = go.transform.position - transform.position;

        if (PlayerPrefs.GetInt("InvertY") == 0)
        {
            isInverted = false;
        }
        else
        {
            isInverted = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 wantedPosition;
        Quaternion wantedRotation;
        xAxis += Input.GetAxis("Mouse X");
        yAxis += Input.GetAxis("Mouse Y") * (isInverted ? -1 : 1);

        yAxis = Mathf.Clamp(yAxis, -50.0f, 50.0f);

        wantedPosition = target.TransformPoint(0, height, distance);
        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

        wantedRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
    }

    // Called after all Update functions called
    private void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;

        go.transform.Rotate(0, horizontal, 0);
        float desiredAngle = go.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(yAxis, desiredAngle, 0);
        transform.position = go.transform.position - (rotation * offset);

        transform.LookAt(target);
    }

}
