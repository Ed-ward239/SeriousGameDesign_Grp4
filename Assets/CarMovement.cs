using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] public static Rigidbody2D car;
    [SerializeField] float horizontalMovement;
    [SerializeField] float verticalMovement;
    [SerializeField] int speed = 20;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        if (car == null) {
            car = GetComponent<Rigidbody2D>();
        }
        // speed = 15;
        // jumpForce = 750.0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump"))
			jumpPressed = true;
    }

    void Flip() {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }


    void Jump() {
        car.velocity = new Vector2(car.velocity.x * 2, car.velocity.y);
		// car.AddForce(new Vector2(0, jumpForce));
		// jumpPressed = false;
		// isGrounded = false;
    }

    void FixedUpdate()
    {
        if(horizontalMovement > 0) {
            speed = 35;
        }
        if(horizontalMovement < 0) {
            speed = 15;
        }
        car.velocity = new Vector2(horizontalMovement * speed, car.velocity.y);
        // if(horizontalMovement < 0 && isFacingRight || horizontalMovement > 0 && !isFacingRight) {
        //     Flip();
        // }
        if (jumpPressed) {
            Jump();
        }
        // balloon.position = new Vector2(100, 0);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }
}
