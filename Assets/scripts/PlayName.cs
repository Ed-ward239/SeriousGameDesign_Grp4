using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayName : MonoBehaviour
{
    [SerializeField] string playerName;

    public static PlayName Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }
    void Start()
    {
        playerName = "";
    }

    public void SetName(string name)
    {
        playerName = name;
    }
}

// Edited by Edward Lee

