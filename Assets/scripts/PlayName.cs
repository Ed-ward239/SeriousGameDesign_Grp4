using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayName : MonoBehaviour
{
    private UI_InputWindow NameInput;
     
    public void clickSave(){
        PlayerPrefs.SetString("name", NameInput.text);
        Debug.Log("Your name is " + PlayerPrefs.GetString("name"));
    }
}

// Edited by Edward Lee

