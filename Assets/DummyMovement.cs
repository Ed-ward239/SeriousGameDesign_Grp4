using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMovement : MonoBehaviour
{
    Rigidbody2D dummy;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audio;
    [SerializeField] bool hasContacted = false;
    // Start is called before the first frame update
    void Start()
    {
        if (dummy == null) {
            dummy = GetComponent<Rigidbody2D>();
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

    void OnCollisionEnter2D(Collision2D collider) {
        if (collider.gameObject.tag == "Car" && !hasContacted) {
            hasContacted = true;
            // yield WaitForSeconds (3);
            // Invoke("BlowUp", 0);
            // audio.Play();
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
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
