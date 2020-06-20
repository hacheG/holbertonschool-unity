using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private GameObject cube1;
    public float dt, ts;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {
        /*cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube1.transform.position = new Vector3(0, 1, 0);
        cube1.GetComponent<Renderer>().material.color = Color.blue;*/
    }
    // Update is called once per frame
    void Update()
    {
        dt = Time.deltaTime;
        Debug.Log(Time.timeScale*2);
        //transform.Translate(0, 1, 0);
    }
}
