using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TireMovement : MonoBehaviour
{
    [SerializeField] public static Rigidbody2D tire;
    [SerializeField] float horizontalMovement;
    [SerializeField] bool brake = false;
    [SerializeField] float verticalMovement;
    [SerializeField] int initialSpeed = 50;
    [SerializeField] int speed = 25;
    [SerializeField] int gear = 1;
    [SerializeField] public Text gearNumber;
    // Start is called before the first frame update
    void Start()
    {
        tire = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Fire1")) {
            if (gear == 4) {
                gear = 1;
                return;
            }
            gear++;
        }

        if(horizontalMovement > 0) {
            speed = gear * initialSpeed;
        }
        if(horizontalMovement < 0) {
            speed = gear * initialSpeed / 2;
        }

        gearNumber.text = gear + "";

         if(Input.GetButtonDown("Jump")) {
            brake = true;
        }

         if(horizontalMovement != 0) {
            brake = false; 
        }

    }

    void FixedUpdate() {
        tire.AddTorque(speed * -horizontalMovement * Time.fixedDeltaTime);

        if (brake) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            tire.AddTorque(0);
        }
        // tire.velocity = new Vector2(horizontalMovement * speed, 0);

        // float rotation = 0f;
        // if (horizontalMovement > 0)
        //     rotation = horizontalMovement * (-35);
        // if (horizontalMovement < 0)   
        //     rotation = horizontalMovement * (-15);
        // RotateTire(rotation);

        
        
    }

    void RotateTire(float rotation) {
        transform.Rotate(0, 0, rotation);
    }


    void Brake() {
        gameObject.transform.Rotate(0, 0, 0);
    }
}
