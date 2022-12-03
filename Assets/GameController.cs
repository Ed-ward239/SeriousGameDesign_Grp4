using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject[] cars;
    [SerializeField] GameObject[] frontTires;
    [SerializeField] GameObject[] backTires;
    [SerializeField] int selectedOption;
    [SerializeField] public GameObject carBody;
    [SerializeField] public GameObject camera;
    [SerializeField] public GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        selectedOption = PersistentData.Instance.GetOption();
        // cars = GameObject.FindGameObjectsWithTag("Car");
        // tires = GameObject.FindGameObjectsWithTag("Tire");
        Debug.Log(selectedOption);
        // cars[selectedOption].SetActive(true);
        // frontTires[selectedOption].SetActive(true);
        // backTires[selectedOption].SetActive(true);
        for (int i = 0; i < 3; i++) {
            if (i != selectedOption) {
                cars[i].SetActive(false);
                frontTires[i].SetActive(false);
                backTires[i].SetActive(false);
            }
        }

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
    }

    public GameObject GetCar() {
        return carBody;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector2(carBody.transform.position.x, carBody.transform.position.y);

    }
}
