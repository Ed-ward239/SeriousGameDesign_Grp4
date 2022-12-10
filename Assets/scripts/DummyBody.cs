using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBody : MonoBehaviour
{
    [SerializeField] GameObject dummy;
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
    }

  void OnTriggerEnter2D(Collider2D collider) {
         if (collider.gameObject.tag == "Car") {
            dummy.GetComponent<Animator>().SetInteger("explode", 1);
            dummy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -0.75f);
        }
    }

     void OnTriggerStay2D(Collider2D collider) {
        if (collider.gameObject.tag == "Car" && collider.gameObject.GetComponent<CarMovement>().GetIfIsHunking()) {
            dummy.GetComponent<Animator>().SetInteger("explode", 3);
            dummy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Invoke("StartThrowing", 3.0f);
        }
     }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    void StartThrowing() {
        dummy.GetComponent<Animator>().SetInteger("explode", 4);
    }
}
