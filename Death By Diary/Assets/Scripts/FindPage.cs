using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindPage : MonoBehaviour
{

    //the interactable object that tells us if this interaction can happen
    private InteractableObject interactionHolder;


    //boolean variable that keeps track of what the last return value was, if changed then does code
    private bool interactionLast;

    //access for the characters input
    private CharacterInput cInput;

    //the desired pagenumber to be found
    public string pageNumber;

    //the page to show when the correct pagenumber is entered
    public GameObject shownPage;


    // Start is called before the first frame update
    void Start()
    {
        interactionHolder = this.gameObject.GetComponent<InteractableObject>();

        //destroy if not interactable
        if (interactionHolder == null)
        {
            Destroy(this);
        }

        interactionLast = false;

        shownPage.SetActive(false);

        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        cInput = player[0].GetComponent<CharacterInput>();

    }

    // Update is called once per frame
    void Update()
    {

        //checks for if the object is being interacted with, and toggles showable gameobjects if it switches
        if (interactionHolder.Interaction)
        {
            if (!interactionLast)
            {
                //open the player input
                cInput.ToggleText();
                interactionLast = true;
            }
                
            //if player exits text then turn off
            if(!cInput.visibleText)
            {
                interactionLast = false;
                interactionHolder.ToggleInteraction();
                shownPage.SetActive(false);
            }

            
        }

        //if interaction is toggled off hide all relevant gameobjects
        else
        {
            if (interactionLast)
            {
                interactionLast = false;

                //toggle text
                cInput.ToggleText();

                //if text was already closed reset to true
                if (cInput.visibleText)
                {
                    interactionHolder.ToggleInteraction();
                    interactionLast = true;
                    return;
                }
                          
                // close shown page if shown
                shownPage.SetActive(false);
            }
        }

        //if hits the enter key while interacting checks to see if the page number is correect, if so we set the shownpage to active
        if (interactionLast == true && Input.GetKeyDown(KeyCode.Return))
        { 
            if (cInput.ReturnText() == pageNumber)
            {
                shownPage.SetActive(true);
            }
        }


    }
}

