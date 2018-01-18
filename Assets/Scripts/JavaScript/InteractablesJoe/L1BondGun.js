import UnityEngine.UI;

var distanceToObject: float = PlayerCasting.DistanceFromTarget;                                 				// Use raycasting to measure the distance
var TextDisplay: GameObject;                                                                    				// The game object to interact with

var bondGunAudio: AudioSource;                                                                 	 				// The audio clip to play (bond theme)

function Update() {
    distanceToObject = PlayerCasting.DistanceFromTarget;                                        				// Calculate the distance between the player and object
}

function OnMouseOver() {                                                                        				// When the cursor is over an object
    if (distanceToObject <= 2.5f) {         																	// If the gun is in raycastings range
        	TextDisplay.GetComponent.<Text>().text = "Seems A Bit Too James Bond, Must Be Other Guns";  		// Display a message
    }

    if (Input.GetButtonDown("Action")) {                                                        				// If the action button is pressed
        if (distanceToObject <= 2.5f) {                                                            				// And the distance is less than 2
            BondAudio();                                                                        				// Play the sound effect
        }
    }
}

function OnMouseExit() {                                                                    					// When the cursor is not over the object
    if (TextDisplay.GetComponent.<Text>().text != "") {                                                     	// Display after the previous message (or don't, otherwise will appear when out of range)
	    TextDisplay.GetComponent.<Text>().text = "Jedi Mind Trick:\nThis is not the gun you are looking for";  	// Display a message
	    yield WaitForSeconds(2);                            													// Display message for 2 seconds
	    TextDisplay.GetComponent.<Text>().text = "";                                                			// Clear the action message text
    }
}

function BondAudio() {
    bondGunAudio.Play();    																	  				// Display a message 
}