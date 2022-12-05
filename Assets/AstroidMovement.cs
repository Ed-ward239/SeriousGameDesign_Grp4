using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidMovement : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] public Rigidbody2D astroid;
    [SerializeField] GameObject fire;
    [SerializeField] AudioSource audio;
    [SerializeField] bool hasContacted = false;
    [SerializeField] GameObject car;
    // [SerializeField] GameObject ast;
    // Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        if (astroid == null) {
            astroid = GetComponent<Rigidbody2D>();
        }

        // if (ast == null) {
        //     ast = gameObject;
        // }
        
        if (animator == null) {
            animator = GetComponent<Animator>();
        }

        if (audio == null) {
            audio = GetComponent<AudioSource>();
        }

        if (car == null) {
            car = GameObject.FindGameObjectWithTag("Car");
        }

        Shoot();

        // position = new Vector2(10, 10);

        // InvokeRepeating("CreateAstroids", 5.0f, 3.0f);
    }

    // void CreateAstroids() {
    //     Instantiate(astroid, position, Quaternion.identity);
    // }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 0.15f);
        // fire.GetComponent<Rigidbody2D>().velocity = new Vector2(astroid.velocity.x, astroid.velocity.y);
        // fire.transform.Rotate(0, 0, 1);

        // Vector2 position = new Vector2(car.transform.position.x + 10, car.transform.position.y + 10);
        
    }

    void OnCollisionEnter2D(Collision2D collider) {
        if (hasContacted == false && collider.gameObject.tag != "Astroid") {
        hasContacted = true;
        animator.SetInteger("explosion", 1);
        // AudioSource.PlayClipAtPoint(audio.clip, transform.position);
        audio.Play();
        Destroy(fire);
        Invoke("Kill", 1.75f);
        }

    }

    void Shoot() {
        astroid.AddForce(new Vector2(-70000, 0));
    }

    void Kill() {
        animator.SetInteger("explosion", 0);
        Destroy(animator.gameObject);
    }
}
