using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Pointer : MonoBehaviour
{
    public Button button;
    public Button second;
     public Button thirdBtn;
     public Button dinosaurBtn; 
    public LineRenderer Line; //Line renederer to track ray
public TMP_Text secondText; // text component for second artifact
    public TMP_Text textbox , textThird; //text component for first and 3rd artifact
       public AudioSource audioSource; // the AudioSource component
    public AudioClip audioClip; // the AudioClip that you want to play
    
    // Start is called before the first frame update
    void Start()
    {
        // textbox.text = "DEbug Window";

        //hide the text component on start
          textbox.gameObject.SetActive(false);
         secondText.gameObject.SetActive(false);
          textThird.gameObject.SetActive(false);

          //Get the audio on start
            audioSource = GetComponent<AudioSource>(); 
         

    }

    // Update is called once per frame
    void Update()
    {
        Line.SetPosition(0 , transform.position);
        Line.SetPosition(1 , transform.position + (transform.forward * 1000));
        RaycastHit hit;
        Ray ray = new Ray(transform.position , transform.forward);
        Physics.Raycast(ray ,out hit);

         //checks if the ray hits a collider

          if(hit.collider)
        {
              if(hit.collider.CompareTag("newtry"))
            {
                button.Select();
            }
            if(hit.collider.CompareTag("sec"))
            {
                second.Select();
            }
            if(hit.collider.CompareTag("third"))
            {
               thirdBtn.Select();
            }
             else if(hit.collider.CompareTag("dinosaur")) // check if ray hits the new button
            {
                dinosaurBtn.Select();
            }
            //sets the selected game object to null if none of the buttons are hit.
             else
            {
                EventSystem.current.SetSelectedGameObject(null);
            }
        }  

    }



       public void ChangeScene(Button buttonClicked)
    {
        
         if(buttonClicked == button)
        {
            textbox.gameObject.SetActive(true);
           textbox.text = "the wine vessel: 11th-10th century BCE old vessel type that emerged as early as the Erlitou period,dating from the 17th century BCE.";

             Invoke("HideText", 10f);
        }
            else if(buttonClicked == second)
        {
            secondText.gameObject.SetActive(true);
           secondText.text = "Vessel for potpourri - mixtures of dried flowers. The ornamentation and figural scenes depicted on the vase refer to trade expeditions and exchanges with China, from where luxury goods, including incense, were imported";
            Invoke("HideTextSec", 10f);
        }
           else if(buttonClicked == thirdBtn)
        {
            textThird.gameObject.SetActive(true);
           textThird.text = "Shengding food vessel, 6th century BCE,This magnificent ritual food vessel was cast around 575 BCE for use in religious or state ceremonies";
            Invoke("HideTextThird", 10f);
        }
         else if(buttonClicked == dinosaurBtn) // check if new button is clicked
        {
           //textbox4.text = "DEbug Window";
             audioSource.clip = audioClip;
            audioSource.Play();
        }
    }


    //invoke the HideText, HideTextSec, and HideTextThird methods after 10 seconds to hide the TextMeshPro text components.
    
    public void HideText()
{
    textbox.gameObject.SetActive(false);
}
       public void HideTextSec()
{
    secondText.gameObject.SetActive(false);
}
     public void HideTextThird()
{
    textThird.gameObject.SetActive(false);
}
}
