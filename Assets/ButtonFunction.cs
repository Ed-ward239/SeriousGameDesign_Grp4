using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMain() {
        SceneManager.LoadScene("Menu");
    }

    public void GoToInstructions() {
        SceneManager.LoadScene("Instructions");
    }

    public void GoToLevel() {
        SceneManager.LoadScene(1);
    }
}