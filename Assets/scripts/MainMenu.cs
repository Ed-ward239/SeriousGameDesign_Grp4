using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenu : MonoBehaviour
{

    [SerializeField] TMP_InputField playerNameInput;

    public void Play()
    {
        string name = playerNameInput.text;
        PersistentData.Instance.SetName(name);
        PersistentData.Instance.SetScore(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit");
    }
}

//Edited by Edward Lee
