using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Activator : MonoBehaviour
{
   private bool isInRange;
   public KeyCode InteractKey = KeyCode.E;
   /* public UnityEvent InteractAction; */
   private GameObject InteractItem;
   [SerializeField] GameObject inputButtonImage;
   
   private void Start()
   {
     inputButtonImage.SetActive(false);
   }
   
   private void Update() 
   {    
        if((isInRange)&(Input.GetKeyDown(InteractKey)))
        {
            
           if ((InteractItem.TryGetComponent<Interactable>(out Interactable ob)))
           {
                ob.Interact();
           }
            
            /* InteractAction.Invoke(); */
        }
   }

   private void OnTriggerEnter(Collider other)
   {
        if ((other.tag == "Interactable"))
        {
            
            isInRange=true;
            inputButtonImage.SetActive(true);
            InteractItem=other.gameObject;

            
        }
   }

   private void OnTriggerExit(Collider other) 
   {
        if ((other.tag == "Interactable"))
        {
               inputButtonImage.SetActive(false);
               InteractItem=null;
               isInRange=false;  
        }
   }
}