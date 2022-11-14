using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Car;
    public GameObject Sign;

    
    public void toggleCar(){
        if(Car!= null){
            bool isActive = Car.activeSelf;
            Car.SetActive(!isActive);
        }
    }
    public void togglePanel(){ //turns panel off/on
        if(Panel!= null){
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
            toggleCar();
        }
        while(Panel.activeSelf){
        }
        StartCoroutine(EnableBox(5.0F));

        
    }    
    private void OnTriggerEnter2D(Collider2D collider){
        Sign.GetComponent<BoxCollider2D> ().enabled = false;
        Debug.Log("Trigger Panel!");
        togglePanel();
    }
 
    IEnumerator EnableBox(float waitTime) {
         yield return new WaitForSeconds(waitTime);
         Sign.GetComponent<BoxCollider2D> ().enabled = true;
    }
    
    
}
