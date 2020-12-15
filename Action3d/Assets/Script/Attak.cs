using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attak : MonoBehaviour
{
    Animator ekardAnimator;
    public BoxCollider swordCollider;


    // Start is called before the first frame update
    void Start()
    {
        ekardAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))

        {
            ekardAnimator.SetBool("Attak", true);

        }

    }
    void Attak1Start()
    {
        swordCollider.enabled = true;
    }
    void Attak1End()
    {
        swordCollider.enabled = false;
        ekardAnimator.SetBool("Attak", false);
    }
}
