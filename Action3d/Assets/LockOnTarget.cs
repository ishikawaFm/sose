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


     void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }
    void Update()
    {
        transform.position = player.transform.position;
    }
    protected void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag=="Enemy")
        {
            target = c.gameObject;
        }
    }
    protected void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag=="Enemy")
        {
            
            target = null;

        }
    }
    public GameObject getTarget()
    {
        return this.target;
    }

  
}
