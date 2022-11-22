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
   public GameObject ScoreBoard;



 
 
 
   public void Answer(){
       if(isCorrect){
           Debug.Log("Correct Answer");
           Score.amountCorrect++;
       }
       else{
           Debug.Log("Wrong Answer");

       }

           quizManager.correct();
           togglePanel();
           toggleCar();
           Score.amountQuestions++;
           if(Score.amountQuestions==20){
            ScoreBoard.SetActive(true);
            removeCar();

           }
           else
            toggleGear();
   }
   public void toggleCar(){
       if(Car!= null){
           //bool isActive = Car.activeSelf;
           Car.SetActive(true);//Car.SetActive(!isActive)
       }
   }
      public void removeCar(){
       if(Car!= null){
           //bool isActive = Car.activeSelf;
           Car.SetActive(false);//Car.SetActive(!isActive)
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
