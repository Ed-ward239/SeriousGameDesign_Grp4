using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{
    [SerializeField] public static Rigidbody2D car;
    [SerializeField] float horizontalMovement = 0;
    [SerializeField] float verticalMovement = 0;
    [SerializeField] int speed = 10;
    [SerializeField] int initialSpeed = 10;
    [SerializeField] int gear = 1;
    [SerializeField] int rotationFactor = 5;
    [SerializeField] float jumpForce = 1000.0f;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] bool isGrounded = true;
    [SerializeField] public Text gearNumber;
    // Start is called before the first frame update
    void Start()
    {
        if (car == null) {
            car = GetComponent<Rigidbody2D>();
        }
        // speed = 15;
        // jumpForce = 750.0f;
        rotationFactor = 5;
       initialSpeed = 15;
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

        gearNumber.text = gear + "";
			// jumpPressed = true;
            // Jet();

        if (gameObject.transform.rotation.z < -0.3) {
            gameObject.transform.Rotate(0, 0, rotationFactor);
        }

        if (gameObject.transform.rotation.z > 0.4) {
            gameObject.transform.Rotate(0, 0, -1 * rotationFactor);
        }
        
    }

    void Flip() {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }


    void Jet() {
        car.velocity = new Vector2(car.velocity.x * 2, car.velocity.y);
		// car.AddForce(new Vector2(0, jumpForce));
		// jumpPressed = false;
		// isGrounded = false;
    }

    void Jump() {
        car.AddForce(new Vector2(0, jumpForce));
    }

    void FixedUpdate()
    {
        if(horizontalMovement > 0) {
            speed = gear * initialSpeed;
        }
        if(horizontalMovement < 0) {
            speed = gear * initialSpeed / 2;
        }
        car.velocity = new Vector2(horizontalMovement * speed, car.velocity.y);
        // if(horizontalMovement < 0 && isFacingRight || horizontalMovement > 0 && !isFacingRight) {
        //     Flip();
        // }
        // if (jumpPressed) {
        //     Jet();
        // }

        // if (Input.GetButtonDown("Fire1")) {
        //     Jump();
        // }
      
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }
}