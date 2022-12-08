using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMovement : MonoBehaviour
{
    Rigidbody2D dummy;
    [SerializeField] CircleCollider2D dummyBubble;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audio;
    [SerializeField] bool hasContacted = false;
    [SerializeField] GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        if (dummy == null) {
            dummy = GetComponent<Rigidbody2D>();
        }
        if (controller == null) {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }

        if (dummyBubble == null) {
            dummyBubble = GetComponent<CircleCollider2D>();
        }

        if (animator == null) {
            animator = GetComponent<Animator>();
        }

        if (audio == null) {
            audio = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Car") {
            // hasContacted = true;
            // // yield WaitForSeconds (3);
            // // Invoke("BlowUp", 0);
            // audio.Play();
            // // AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            // BlowUp();
            dummy.velocity = new Vector2(0, -0.25f);
            // controller.GetComponent<GameController>().SetReducedLife(35.0f);

        }

        //  if (collider.gameObject.tag == "Car" && !hasContacted && dummy.velocity.y < 0.0f) {
        //     hasContacted = true;
        //     // yield WaitForSeconds (3);
        //     // Invoke("BlowUp", 0);
        //     audio.Play();
        //     // AudioSource.PlayClipAtPoint(audio.clip, transform.position);
        //     BlowUp();
        // }
    } 

    void BlowUp() {
        animator.SetInteger("explode", 1);
   
        Invoke("Kill", 1.5f);
    }

    void Kill() {
        Destroy(animator.gameObject);
    }
}
