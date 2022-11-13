using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireMovement : MonoBehaviour
{
    [SerializeField] public static Rigidbody2D tire;
    [SerializeField] float horizontalMovement;
    [SerializeField] bool brake = false;
    [SerializeField] float verticalMovement;
    [SerializeField] int speed = 20;
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

         if(Input.GetButtonDown("Jump")) {
            brake = true;
        }

         if(horizontalMovement != 0) {
            brake = false; 
        }

    }

    void FixedUpdate() {
        gameObject.transform.Rotate(0, 0, 0);
        if (brake) {
            gameObject.transform.Rotate(0, 0, 0);
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
