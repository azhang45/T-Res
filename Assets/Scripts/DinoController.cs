using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    private float jumpInput;
    private float jumpHeight = 10.0f;
    private float timer = 0.0f;
    private float jumpTime = 1.0f;
    private float x;
    private float z;
    public SpawnManager SpawnManager;
    public bool over = false;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "cactusCOLOR(Clone)" || collision.gameObject.name == "birdcolor(Clone)"){
            SpawnManager.GameOver();
            over = true;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer > 0.7){
            jumpInput = Input.GetAxis("Jump");
            transform.Translate(Vector3.forward * jumpHeight * jumpInput * Time.deltaTime);
            if (jumpInput > 0){
                jumpTime -= Time.deltaTime;
                if(jumpTime <= 0){
                    jumpTime = 1.0f;
                    timer = 0.0f;
                } 
            }
            else{
                jumpTime = 1.0f;
            }
        }
        transform.localRotation = Quaternion.Euler(-90, 180, 0);
        if(transform.position.x != 990 || transform.position.z != 500){
            transform.position = new Vector3(990, transform.position.y, 500);
        }

        
    }
}
