using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject[] cars;
    [SerializeField] GameObject[] frontTires;
    [SerializeField] GameObject[] backTires;
    [SerializeField] GameObject[] signs;
    [SerializeField] int selectedOption;
    [SerializeField] public GameObject carBody;
    [SerializeField] public GameObject camera;
    [SerializeField] public GameObject background;
    [SerializeField] GameObject astroid;
    [SerializeField] GameObject dummy;
    [SerializeField] int speedLimit;
    Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        signs = GameObject.FindGameObjectsWithTag("signs");
        selectedOption = PersistentData.Instance.GetOption();
        // cars = GameObject.FindGameObjectsWithTag("Car");
        // tires = GameObject.FindGameObjectsWithTag("Tire");
        // cars[selectedOption].SetActive(true);
        // frontTires[selectedOption].SetActive(true);
        // backTires[selectedOption].SetActive(true);
        MakeTargetCarAppear();

        if (carBody == null) {
            carBody = cars[selectedOption];
        }
        // transform.position = new Vector2(carBody.transform.position.x, carBody.transform.position.y);
        camera.GetComponent<CameraFollow>().SetTarget(carBody.transform);
        frontTires[selectedOption].GetComponent<TireMovement>().SetTire(frontTires[selectedOption].GetComponent<Rigidbody2D>());
        backTires[selectedOption].GetComponent<TireMovement>().SetTire(backTires[selectedOption].GetComponent<Rigidbody2D>());
        carBody.GetComponent<CarMovement>().SetTire(frontTires[selectedOption]);
        carBody.GetComponent<CarMovement>().SetBody(carBody.GetComponent<Rigidbody2D>());
        background.GetComponent<FreeParallaxDemo>().SetPlayer(carBody);

        InvokeRepeating("CreateAstroids", 10.0f, 10.0f);
    }

    public void MakeTargetCarAppear() {
          for (int i = 0; i < 3; i++) {
            if (i != selectedOption) {
                cars[i].SetActive(false);
                frontTires[i].SetActive(false);
                backTires[i].SetActive(false);
            }
        }
    }

    public void SetSpeedLimit(int limit) {
        speedLimit = limit;
    }

    public GameObject GetCar() {
        return carBody;
    }
    
    void CreateAstroids() {
        position = new Vector2(carBody.transform.position.x + 25, carBody.transform.position.y + 10);
        Instantiate(astroid, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (speedLimit == 25) {
            for (int i = 0; i<3; i++) {
                signs[i].SetActive(false);
            }
            signs[0].SetActive(true);
        }
        else if (speedLimit == 50) {
            for (int i = 0; i<3; i++) {
                signs[i].SetActive(false);
            }
            signs[1].SetActive(true);
        }
        else if (speedLimit == 70) {
            for (int i = 0; i<3; i++) {
                signs[i].SetActive(false);
            }
            signs[2].SetActive(true);
        } else {
        for (int i = 0; i<3; i++) {
                signs[i].SetActive(false);
            }
        }
    }
}
