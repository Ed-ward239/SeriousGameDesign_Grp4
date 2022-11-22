using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
public class AnswerScript : MonoBehaviour
{
   public bool isCorrect = false;
   public QuizManager quizManager;
   public GameObject Panel;
   public GameObject Car;
   public GameObject GearsCanvas;
   public Timer Score;
   int numCorrect = 0;
   int numQuestions = 20;


 
 
 
   public void Answer(){
       if(isCorrect){
           Debug.Log("Correct Answer");
           numCorrect++;
       }
       else{
           Debug.Log("Wrong Answer");

       }
           numQuestions--;
           quizManager.correct();
           togglePanel();
           toggleCar();
           toggleGear();
           Score.amountCorrect = numCorrect;
           Score.amountQuestions = 20 - numQuestions;
           if(numQuestions==0){
            //end game call method
           }
   }
   public void toggleCar(){
       if(Car!= null){
           //bool isActive = Car.activeSelf;
           Car.SetActive(true);//Car.SetActive(!isActive)
       }
   }
   public void togglePanel(){ //turns panel off/on
       if(Panel!= null){
           //bool isActive = Panel.activeSelf;
           Panel.SetActive(false);
       }
   }
   public void toggleGear(){
       if(GearsCanvas!= null){
           //bool isActive = GearsCanvas.activeSelf;
           GearsCanvas.SetActive(true);
       }
 
   }
}
