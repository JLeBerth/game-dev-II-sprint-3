using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterInput : MonoBehaviour
{
    public InputField input; //input field for player to add text or type statements
    public GameObject canvasObject; //canvas gameobject to hold the text input in
    // Start is called before the first frame update
    void Awake()
    {
        canvasObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //press t to bring up text
        if(Input.GetKeyDown(KeyCode.T))
        {
            input.enabled = !input.IsActive();
            canvasObject.SetActive(!canvasObject.activeSelf);
        }

        //if the text is active and enter is hit, return the currently input text
        if(canvasObject.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log(input.textComponent.text);
            //input logic here for resolving the input text
        }

        //interact with objects controller
        if (Input.GetKeyDown(KeyCode.E))
        {

            //find any objects we are looking at
            GameObject[] lookingAt;
            lookingAt = GameObject.FindGameObjectsWithTag("mouseOver");

            //toggle their interaction
            foreach (GameObject thisObject in lookingAt)
            {
                InteractableObject thisInteraction = thisObject.GetComponent<InteractableObject>();
                thisInteraction.ToggleInteraction();
            }

            //do the same for held objects, as if an object is held then we always want to interact with it
            lookingAt = GameObject.FindGameObjectsWithTag("Held");

            foreach (GameObject thisObject in lookingAt)
            {
                InteractableObject thisInteraction = thisObject.GetComponent<InteractableObject>();
                thisInteraction.ToggleInteraction();
            }
        }



    }
}