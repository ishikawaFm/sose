using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject mainCamre;
    public float rotateSpeeds;
    private const int rotateButton = 1;
    private const float angleLimitUp = 60f;
    private const float angleLimitDown = -60f;
    LockOnTarget lockOnTarget;
    Vector3 StartPosition;
    Quaternion StartRotation;

    GameObject targetObj = null;

    void Start()
    {
        mainCamre = Camera.main.gameObject;
        player = GameObject.FindGameObjectWithTag("player");
        lockOnTarget = player.GetComponentInChildren<LockOnTarget>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        transform.position += new Vector3(1.3f, -5, 0);
        mainCamre.transform.LookAt(player.transform, Vector3.up);
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject target = lockOnTarget.getTarget();
            if (target != null)
            {
                if(targetObj == null)
                {
                    StartPosition = transform.localPosition;
                    StartRotation = transform.localRotation;
                }

                targetObj = target;

            }
            else if(targetObj != null)
            {
                ResetCamera();
                targetObj = null;
                
            }
        }
        if (targetObj != null)
        {
            lockOnTargetObject(targetObj);
            transform.position = player.transform.localPosition;
        }
        else
        {
            
            if (Input.GetMouseButton(rotateButton))
            {
                rotateCameraAngle();
            }
        }
        
        if (Input.GetMouseButton(rotateButton))
        {
            rotateCameraAngle();
        }
        float angleX = 180f <= transform.eulerAngles.x ? transform.eulerAngles.x - 360 : transform.eulerAngles.x;
        transform.eulerAngles = new Vector3(
            Mathf.Clamp(angleX, angleLimitDown, angleLimitUp),
            transform.eulerAngles.y,
            transform.eulerAngles.z);
    }

  

    private void lockOnTargetObject(GameObject target)
    {
        
        mainCamre.transform.LookAt(target.transform, Vector3.up);
    }

    public  void ResetCamera()
    {
        transform.localPosition = StartPosition;
        transform.localRotation = StartRotation;
    }

    private void rotateCameraAngle()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X")
        + rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);
        transform.eulerAngles += new Vector3(angle.y, angle.x);
        

    }
}
