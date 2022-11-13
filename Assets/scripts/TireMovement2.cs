using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TireMovement2 : MonoBehaviour
{
    public Rigidbody2D frontTire;
    public Rigidbody2D backTire;
    [SerializeField] int speed = 100;
    [SerializeField] float movement;
    [SerializeField] bool brake = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump")) {
            brake = true;
        }

        if(!Input.GetButtonDown("Jump")) {
            brake = false;
        }
    }

    void FixedUpdate() {
        frontTire.AddTorque(speed * -movement * Time.fixedDeltaTime);
        backTire.AddTorque(speed * -movement * Time.fixedDeltaTime);

        if(Input.GetButtonDown("Jump")) {
            frontTire.AddTorque(0);
        backTire.AddTorque(0);

        }
    }

    void Brake() {
           frontTire.AddTorque(0);
        backTire.AddTorque(0);
    }
}
