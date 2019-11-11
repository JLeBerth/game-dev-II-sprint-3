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
        if(Input.GetKeyDown(KeyCode.E))
        {
            //draw a ray in 3d worldspace to see what object you are interacting with
            //then take that objects collidor and get the objects interractable if it has one
            //then toggle interaction
            //that gameobject will have a script with an event that reads when interaction is toggled and will know what to do with it
        }



    }
}
