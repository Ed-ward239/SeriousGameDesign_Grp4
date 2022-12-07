using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    GameObject controller;
    [SerializeField] int speedLimit;

    // Start is called before the first frame update
    void Start()
    {
        if (controller == null) {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }

        if (gameObject.tag == "25speed") {
            speedLimit = 25;
        }

        if (gameObject.tag == "50speed") {
            speedLimit = 50;
        }

        if (gameObject.tag == "70speed") {
            speedLimit = 70;
        }

        if (gameObject.tag == "UnlimitedSpeed") {
            speedLimit = 1000;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Car") {
            controller.GetComponent<GameController>().SetSpeedLimit(speedLimit);
        }
    }
}
