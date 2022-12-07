using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuizManager : MonoBehaviour
{
    public List<QuestionsandAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public TextMeshProUGUI QuestionTxt;


    private void Start(){
        generateQuestion();

    }

    void generateQuestion(){
        currentQuestion = Random.Range(0,QnA.Count);
        QuestionTxt.text = QnA[currentQuestion].Question;
        setAnswers();

    }

    void setAnswers(){

        for( int i = 0; i < options.Length; i++){
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];
            if(QnA[currentQuestion].CorrectAnswer == i+1){
                Debug.Log(QnA[currentQuestion].CorrectAnswer);
                options[i].GetComponent<AnswerScript>().isCorrect = true; 
            }
        }
    }

    public void correct(){
        // QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
     
}
