using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    //private float speed = 5.0f;
    private float jumpInput;
    private float jumpHeight = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jumpInput = Input.GetAxis("Jump");
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Translate(Vector3.up * jumpHeight * jumpInput * Time.deltaTime);
    }
}
