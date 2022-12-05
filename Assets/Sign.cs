using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    GameObject controller;

    // Start is called before the first frame update
    void Start()
    {
        if (controller == null) {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Car") {
            controller.GetComponent<GameController>().SetSpeedLimit(25);
        }
    }
}
