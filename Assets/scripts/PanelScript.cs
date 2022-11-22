using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PanelScript : MonoBehaviour
{
   public GameObject Panel;
   public GameObject Car;
   public GameObject Sign;
   public GameObject GearsCanvas;
 
   public void vanishGear(){
       if(GearsCanvas!= null){
           //bool isActive = GearsCanvas.activeSelf;
           GearsCanvas.SetActive(false);
       }
   }
   public void vanishCar(){
       if(Car!= null){
           Car.SetActive(false);
       }
   }
   public void appearPanel(){ //turns panel off/on
       if(Panel!= null){
          // bool isActive = Panel.activeSelf;
           Panel.SetActive(true);
           vanishCar();
           vanishGear();
       }
   }   
   private void OnTriggerEnter2D(Collider2D collider){
       Sign.GetComponent<BoxCollider2D> ().enabled = false;
       Debug.Log("Trigger Panel!");
       appearPanel();
       StartCoroutine(EnableBox(20.0F));
   }
   IEnumerator EnableBox(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        Sign.GetComponent<BoxCollider2D> ().enabled = true;
   }
  
  
}
