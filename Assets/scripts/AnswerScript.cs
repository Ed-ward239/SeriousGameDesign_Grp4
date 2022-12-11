using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
 
public class AnswerScript : MonoBehaviour
{
   public bool isCorrect;
   public QuizManager quizManager;
   public GameObject Panel;
   public GameObject Car;
   public GameObject GearsCanvas;
   public Timer Score;
   public GameObject ScoreBoard;

    public Button button1;
    public Button button2;
    public Button button3;
 
   public void Answer(){

        if(isCorrect){
            Debug.Log("Correct Answer");
            Score.amountCorrect++;
        }
        else{
            Debug.Log("Wrong Answer");
        }

            quizManager.correct();
            Score.amountQuestions++;
            if(Score.amountQuestions%4==0){
                removePanel();
                returnCar();
                if(Score.amountQuestions==20){
                    ScoreBoard.SetActive(true);
                    removeCar();
                }
                else
                    returnGear();
            }
   }

   public void returnCar(){
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
   public void removePanel(){ //turns panel off/on
       if(Panel!= null){
           //bool isActive = Panel.activeSelf;
           Panel.SetActive(false);
       }
   }
   public void returnGear(){
       if(GearsCanvas!= null){
           //bool isActive = GearsCanvas.activeSelf;
           GearsCanvas.SetActive(true);
       }
 
   }
  public void turnButtonsOff(){
   button1.enabled = false;
   button2.enabled = false;
   button3.enabled = false;
   this.enabled = false;
 
 
  }
  public void turnButtonsOn(){
   button1.enabled = true;
   button2.enabled = true;
   button3.enabled = true;
   this.enabled = true;
  }
//   public void changeButtonsColor(){
//    var red = Color.red;
//    var green = Color.green;
//    if(button1.GetComponent<AnswerScript>().isCorrect){
//        button1.GetComponent<Button>().colors = green;
//        button2.GetComponent<Button>().colors = red;
//        button3.GetComponent<Button>().colors = red;
//        this.GetComponent<Button>().colors = red;
//    }else if(button2.isCorrect){
//        button1.GetComponent<Button>().colors = red;
//        button2.GetComponent<Button>().colors = green;
//        button3.GetComponent<Button>().colors = red;
//        this.GetComponent<Button>().colors = red;
//    }else if(button3.isCorrect){
//        button1.GetComponent<Button>().colors = red;
//        button2.GetComponent<Button>().colors = red;
//        button3.GetComponent<Button>().colors = green;
//        this.GetComponent<Button>().colors = red;
//    }else{
//        button1.GetComponent<Button>().colors = red;
//        button2.GetComponent<Button>().colors = red;
//        button3.GetComponent<Button>().colors = red;
//        this.GetComponent<Button>().colors = green;
//    }
 
//   }
 
//   IEnumerator waiter(float waitTime) {
//        yield return new WaitForSeconds(waitTime);
 
//   }
}

