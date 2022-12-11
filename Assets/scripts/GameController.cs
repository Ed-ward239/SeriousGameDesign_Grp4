using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject[] cars;
    [SerializeField] GameObject[] frontTires;
    [SerializeField] GameObject[] backTires;
    [SerializeField] GameObject[] signs;
    [SerializeField] GameObject[] batteries;
    [SerializeField] int selectedOption;
    [SerializeField] public GameObject carBody;
    [SerializeField] public GameObject camera;
    [SerializeField] public GameObject background;
    [SerializeField] GameObject astroid;
    [SerializeField] GameObject dummy;
    [SerializeField] int speedLimit;
    [SerializeField] float life;
    [SerializeField] bool isAlive;
    [SerializeField] bool isNotified = false;
    [SerializeField] GameObject notificationObj;
    [SerializeField] bool isBatteryNotified = false;
    [SerializeField] GameObject batteryNotificationObj;
    Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        life = 100.0f;
        isAlive = true;
        signs = GameObject.FindGameObjectsWithTag("signs");
        batteries = GameObject.FindGameObjectsWithTag("Battery");
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
        InvokeRepeating("AddSpeedingPenalty", 1.0f, 1.0f);
        CreateDummies();
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

    void AddSpeedingPenalty() {
        if (carBody.GetComponent<Rigidbody2D>().velocity.x * 10 >= speedLimit + 5 && (speedLimit == 25 || speedLimit == 50 || speedLimit == 70)) {
            life-=3;
            if (isAlive && !isNotified) {
                notificationObj.SetActive(true);
                Invoke("KillNotification", 25.0f);
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
    
    void CreateDummies() {
        for (int i = 0; i < 20; i++) {
            int pos = Random.Range(50, 1570);
            if (pos < 246 || (pos >280 && pos < 320) ||  (pos >360 && pos < 390) || (pos >600 && pos < 780) || (pos >940 && pos < 1130) || (pos >1320 && pos < 1430) || (pos >1460 && pos < 1570)) {
            position = new Vector2(pos, -4.0f);
            Instantiate(dummy, position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0.0f) {
            isAlive = false;
        }

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

        if (life < 0.0f) {
            for (int i = 0; i<5; i++) {
                batteries[i].SetActive(false);
            }
            batteries[0].SetActive(true);
        }
        else if (life < 25.0f) {
            for (int i = 0; i<5; i++) {
                batteries[i].SetActive(false);
            }
            batteries[1].SetActive(true);
            if (isAlive && !isBatteryNotified) {
                batteryNotificationObj.SetActive(true);
                Invoke("KillBatteryNotification", 25.0f);
            }
        }
        else if (life < 50.0f) {
            for (int i = 0; i<5; i++) {
                batteries[i].SetActive(false);
            }
            batteries[2].SetActive(true);
        }
        else if (life < 75.0f) {
            for (int i = 0; i<5; i++) {
                batteries[i].SetActive(false);
            }
            batteries[3].SetActive(true);
        }
         else {
            for (int i = 0; i<5; i++) {
                batteries[i].SetActive(false);
            }
            batteries[4].SetActive(true);
        }

        if (life <= 0) {
            SceneManager.LoadScene("level1");
        }

    }

    public void SetReducedLife(float reducedLife) {
        life -= reducedLife;
    }

    public void RefillLife() {
        life = 100.0f;
    }

    public float GetLife() {
        return life;
    }

    public bool GetLifeStatus() {
        return isAlive;
    }

    void KillNotification() {
        notificationObj.SetActive(false);
        isNotified = true;
    }

    void KillBatteryNotification() {
        batteryNotificationObj.SetActive(false);
        isBatteryNotified = true;
    }
}
