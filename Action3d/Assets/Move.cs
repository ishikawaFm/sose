using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private CharacterController ekardController;
    private Animator ekardAnimator;

    public float speed = 3.0f;
    
    Vector3 direction;
 
    // Start is called before the first frame update
    void Start()
    {
        ekardController = GetComponent<CharacterController>();
        ekardAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

   
        if (ekardController.isGrounded)
        {
            direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            if (direction.magnitude > 0.1f)
            {
                ekardAnimator.SetFloat("Speed", direction.magnitude);
                transform.LookAt(transform.position + direction);
            }
            else
            {
                ekardAnimator.SetFloat("Speed", 0);
            }

        }
        direction.y += Physics.gravity.y * Time.deltaTime;
        ekardController.Move(direction * speed * Time.deltaTime);
    }
}
