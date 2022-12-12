using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonFunction : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] Toggle notificationsToggle;
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

    public void SavePlayerName() {
        PersistentData.Instance.SetName(nameInput.text);
    }

    public void SaveNotificationsOption() {
        PersistentData.Instance.SetNotificationsOption(notificationsToggle.isOn);
    }
    public void TurnNotificationsOff() {
        PersistentData.Instance.SetNotificationsOption(false);
    }
}
