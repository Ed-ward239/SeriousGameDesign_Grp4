using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countUp;

    [Header("Questions Score")]
    public TextMeshProUGUI questionsScore;
    public int amountCorrect = 0;
    public int amountQuestions = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   if(amountQuestions !=20){
            currentTime = countUp ? currentTime += Time.deltaTime : currentTime -= Time.deltaTime;
            timerText.text = currentTime.ToString("0.00");
            questionsScore.text = amountCorrect.ToString() + "/" + amountQuestions.ToString();
        }
    }
}
