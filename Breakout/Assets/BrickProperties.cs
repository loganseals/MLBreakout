﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// using these to parse strings and access the TextMeshProUGUI component of an object
using System;
using TMPro;

public class BrickProperties : MonoBehaviour
{

	// set public variables that can be set in Unity; different blocks will have different
	// point values and the bricks on either side of two player mode will have a different ball
	// and different scor objects
    public GameObject myBall;
    public GameObject scoreObject;
    public int points;

    // this is the variable that will hold the TextMeshProUGUI and allows us
    // to access and change the text displayed
    private TextMeshProUGUI ugui;

    // Start is called before the first frame update
    void Start()
    {
    	// get the component of the current score object for the ugui
    	ugui = scoreObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // after something collides with the brick
    void OnCollisionExit2D(Collision2D col){

    	// if the object that collided has the same name as our ball, then disable
    	// the collider for the brick and stop displaying it on screen
    	if(col.collider.name == myBall.name){
    		
    		// disable components
    		gameObject.GetComponent<SpriteRenderer>().enabled = false;
    		gameObject.GetComponent<BoxCollider2D>().enabled = false;

    		// call function to update the score on the screen appropriately
    		IncreaseTMProUGUIText(ugui, points);
    		
    	}
    }

    // This is a function to update the integer value of the text in a TextMeshProUGUI. The
    // function takes in a TextMeshProUGUI component, and the integer value to increase the
    // value of the text in the TextMeshProUGUI. The TextMeshProUGUI must already have an integer value
    // in the text field. THe function does not return anything.
    void IncreaseTMProUGUIText(TextMeshProUGUI textUGUI, int change){

    	// get the current text value as a string from the textmeshprougui
    	string curVal = textUGUI.text;

    	// calculate the new score by converting the string from the text to a long and adding the 
    	// points variable to it
    	long newVal = Int64.Parse(curVal) + (long)change;

    	// update the text for the textmeshprougui with the new score
    	textUGUI.text = newVal.ToString();
    }
}
