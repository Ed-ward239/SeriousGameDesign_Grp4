using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBody : MonoBehaviour
{
    [SerializeField] GameObject dummy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

  void OnTriggerEnter2D(Collider2D collider) {
         if (collider.gameObject.tag == "Car") {
            dummy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -0.25f);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
