using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMovement : MonoBehaviour
{
    Rigidbody2D dummy;
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

        if (collider.gameObject.tag == "Car" && gameObject.tag == "Dummy") {
            controller.GetComponent<GameController>().SetReducedLife(35.0f);
        }
  
         if (collider.gameObject.tag == "Car") {
            hasContacted = true;
            audio.Play();
            BlowUp();
        }
    } 

    void BlowUp() {
        animator.SetInteger("explode", 1);
   
        Invoke("Kill", 1.5f);
    }

    void Kill() {
        Destroy(animator.gameObject);
    }
}
