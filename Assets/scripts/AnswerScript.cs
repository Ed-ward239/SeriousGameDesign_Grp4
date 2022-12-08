using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms.Button;
public class AnswerScript : MonoBehaviour
{
  public bool isCorrect = false;
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
 
       turnButtonsOff();
       changeButtonsColor();
       StartCoroutine(waiter(2.0F));
       quizManager.correct();
       togglePanel();
       toggleCar();
       Score.amountQuestions++;
       turnButtonsOn();
 
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
  public void turnButtonsOff(){
   button1.interactable = false;
   button2.interactable = false;
   button3.interactable = false;
   GameObject.interactable = false;
 
 
  }
  public void turnButtonsOn(){
   button1.interactable = true;
   button2.interactable = true;
   button3.interactable = true;
   GameObject.interactable = true;
  }
  public void changeButtonsColor(){
   var red = Color.red;
   var green = Color.green;
   if(button1.isCorrect){
       button1.GetComponent<Button>().colors = green;
       button2.GetComponent<Button>().colors = red;
       button3.GetComponent<Button>().colors = red;
       GameObject.GetComponent<Button>().colors = red;
   }else if(button2.isCorrect){
       button1.GetComponent<Button>().colors = red;
       button2.GetComponent<Button>().colors = green;
       button3.GetComponent<Button>().colors = red;
       GameObject.GetComponent<Button>().colors = red;
   }else if(button3.isCorrect){
       button1.GetComponent<Button>().colors = red;
       button2.GetComponent<Button>().colors = red;
       button3.GetComponent<Button>().colors = green;
       GameObject.GetComponent<Button>().colors = red;
   }else{
       button1.GetComponent<Button>().colors = red;
       button2.GetComponent<Button>().colors = red;
       button3.GetComponent<Button>().colors = red;
       GameObject.GetComponent<Button>().colors = green;
   }
 
  }
 
  IEnumerator waiter(float waitTime) {
       yield return new WaitForSeconds(waitTime);
 
  }
}
