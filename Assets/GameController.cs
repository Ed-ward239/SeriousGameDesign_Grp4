using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject[] cars;
    [SerializeField] GameObject[] frontTires;
    [SerializeField] GameObject[] backTires;
    [SerializeField] int selectedOption;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
