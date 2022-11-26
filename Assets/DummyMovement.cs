using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMovement : MonoBehaviour
{
    Rigidbody2D dummy;
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (dummy == null) {
            dummy = GetComponent<Rigidbody2D>();
        }

        if (animator == null) {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collider) {
        if (collider.gameObject.tag == "Car") {
            // yield WaitForSeconds (3);
            // Invoke("BlowUp", 0.05f);
            BlowUp();
        }
    } 

    void BlowUp() {
        animator.SetInteger("explode", 1);
        // Invoke("Kill", 1);
    }

    void Kill() {
        Destroy(animator.gameObject);
    }
}
