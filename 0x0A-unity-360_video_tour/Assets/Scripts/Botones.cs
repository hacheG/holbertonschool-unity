using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
    GameObject LivingRoom;
    GameObject MezzanineRoom;
    GameObject CubeRoom;
    GameObject CantinaRoom;

    // Start is called before the first frame update
    void Start()
    {
        LivingRoom = GameObject.FindGameObjectWithTag("LivingRoom");
        MezzanineRoom = GameObject.FindGameObjectWithTag("MezzanineRoom");
        CubeRoom = GameObject.FindGameObjectWithTag("CubeRoom");
        CantinaRoom = GameObject.FindGameObjectWithTag("CantinaRoom");
    }

    // Update is called once per frame
    void Update()
    {
        //GoLivingRoom();
        //Debug.Log("si entra a GoLivingRoom");
        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //LivingRoom.SetActive(true);
            CubeRoom.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            //LivingRoom.SetActive(true);
            CubeRoom.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //LivingRoom.SetActive(true);
            MezzanineRoom.SetActive(true);
        }*/
    }

    public void GoLivingRoom()
    {
        Debug.Log("si entra a GoLivingRoom");
        LivingRoom.SetActive(true);
        CubeRoom.SetActive(false);
        //MezzanineRoom.SetActive(true);

    }

    public void GoCubeRoom()
    {
        Debug.Log("si entra a GoCubeRoom");
        LivingRoom.SetActive(false);
        CubeRoom.SetActive(true);
        //MezzanineRoom.SetActive(true);

    }

    public void GoCubeRoomFromMezzanine()
    {
        Debug.Log("si entra a GoCubeRoomFromMezzanine");
        //LivingRoom.SetActive(false);
        CubeRoom.SetActive(true);
        MezzanineRoom.SetActive(false);

    }

    public void ToMezzanineFromCube()
    {
        Debug.Log("si entra a GoCubeRoomFromMezzanine");
        //LivingRoom.SetActive(false);
        CubeRoom.SetActive(false);
        MezzanineRoom.SetActive(true);

    }

    public void ToCantinaFromCube()
    {
        Debug.Log("si entra a GoCubeRoomFromMezzanine");
        //LivingRoom.SetActive(false);
        CubeRoom.SetActive(false);
        CantinaRoom.SetActive(true);

    }

    public void ToCubeFromCantina()
    {
        Debug.Log("si entra a cubeFromCantina");
        //LivingRoom.SetActive(false);
        CubeRoom.SetActive(true);
        CantinaRoom.SetActive(false);

    }

    public void ToLivingFromCantina()
    {
        Debug.Log("si entra a toLivingFromCantina");
        //LivingRoom.SetActive(false);
        LivingRoom.SetActive(true);
        CantinaRoom.SetActive(false);

    }

    public void ToCantinaFromLiving()
    {
        Debug.Log("si entra a toLivingFromCantina");
        //LivingRoom.SetActive(false);
        LivingRoom.SetActive(false);
        CantinaRoom.SetActive(true);

    }

}
