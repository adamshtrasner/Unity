using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float boostSpeed = 800f;
    [SerializeField] private float rotationSpeed = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessBoost();
        ProcessRotation();
    }

    void ProcessBoost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * boostSpeed * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Rotate(Vector3.back);
        }
    }

    void Rotate(Vector3 vec)
    {
        rb.freezeRotation = true; // freezing rotation so that we can manually rotate
        transform.Rotate(vec * rotationSpeed * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation back
    }
}
