using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMovement : MonoBehaviour
{
    Rigidbody2D dummy;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audio;
    [SerializeField] bool hasContacted = false;

    private bool fadeIn,fadeOut;
    public float fadeSpeed;
    private BoxCollider2D dummyCollider;
    private Rigidbody2D rb;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("body");
        dummyCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
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
        //FadeOut Effect for dummies when car is close
        // if (dummy.position.x - player.GetComponent<Rigidbody2D>().position.x < 15) {
        //     FadeOutObject();
        // }

        // if (fadeOut) {
        //     Color objectColor = this.GetComponent<Renderer>().material.color;
        //     float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

        //     objectColor = new Color(objectColor.r, objectColor.g,objectColor.b, fadeAmount);
        //     this.GetComponent<Renderer>().material.color = objectColor;

        //     if (objectColor.a <= .1) {
        //         fadeOut = false;
        //         Kill();
        //     }
        // }



    }

    void OnCollisionEnter2D(Collision2D collider) {
        if (collider.gameObject.tag == "Car" && !hasContacted) {
            hasContacted = true;
            fadeOut = false;
            // yield WaitForSeconds (3);
            // Invoke("BlowUp", 0);
            // audio.Play();
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            BlowUp();
        }
    } 

    void OnTriggerEnter2D(Collider2D other) {
        print("DUMMY IS Being Triggered");
        if (other.gameObject.CompareTag("TriggerMove")) {
            print("The car is in range");
            rb.gravityScale = .05f;
            dummyCollider.isTrigger = true;
        }   
    }

    void BlowUp() {
        animator.SetInteger("explode", 1);
   
        Invoke("Kill", 1.5f);
    }

    void Kill() {
        Destroy(animator.gameObject);
    }

    public void FadeOutObject() {
        fadeOut = true;
    }

    public void FadeInObject() {
        fadeIn = true;
    }

}
