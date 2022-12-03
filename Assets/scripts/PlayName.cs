using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayName : MonoBehaviour
{
    private InputField NameInput;
     
    public void clickSave(){
        PlayerPrefs.SetString("name", NameInput.text);
        Debug.Log("Player name:  " + PlayerPrefs.GetString("name"));
    }
}

// Edited by Edward Lee

