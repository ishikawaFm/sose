using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnTarget : MonoBehaviour
{

    [SerializeField]
    private GameObject target;
    public GameObject player;
    CameraController CameraController;
    public GameObject mainCamera = null;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        CameraController = mainCamera.GetComponent<CameraController>();
    }
    void Update()
    {
        transform.position = player.transform.position;
    }
    protected void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Enemy")
        {
            target = c.gameObject;
        }
    }
    protected void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Enemy")
        {

            target = null;
            CameraController.targetObj = null;

        }
    }
    public GameObject getTarget()
    {
        return this.target;
    }


}
