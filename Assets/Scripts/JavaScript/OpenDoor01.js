import UnityEngine.UI;

var TextDisplay: GameObject;
var distanceToObject: float = PlayerCasting.DistanceFromTarget;

var Door1: GameObject;                                  	// The double doors
var Door2: GameObject;

var ButtonOn: GameObject;                               	// Green button
var ButtonOff: GameObject;                             		// Red button

var doorSound: AudioSource;                             	// Door open sound

function Start() {
    doorSound = GetComponent.<AudioSource>();           	// Play the door open sound
}

function Update() {
    distanceToObject = PlayerCasting.DistanceFromTarget;	// Get the distance to the object using ray casting
}

function OnMouseOver() {

    if (distanceToObject <= 2) {                        	// If the distance to the object is less than 2
        TextDisplay.GetComponent.<Text>().text = "Press Action Button"; // Display action button message
    }

    if (Input.GetButtonDown("Action")) {
        // Debug.Log("<color=red>Action Button Pressed</color>");
        if (distanceToObject <= 2) {                   	 	// If the distance to the object is less than 2
            OpenTheDoor();                              	// Call the open door function
        }
    }
}

/*
	Reset the text when the cursor moves from the object
*/
function OnMouseExit() {
    TextDisplay.GetComponent.<Text>().text = "";        	// Clear the action text
}

/*
    Play the door animation in stages, turning on/off the button
*/
function OpenTheDoor() {
    Door1.GetComponent("Animator").enabled = true;      	// open the doors
    Door2.GetComponent("Animator").enabled = true;   
    doorSound.Play();
    ButtonOn.SetActive(true);                           	// Show the green button
    ButtonOff.SetActive(false);                        	 	// Hide the red button
    //Debug.Log("<color=green>Animator Enabled</color>");

    yield WaitForSeconds(1);                            	// Wait one second (half way through the 2 second animation)

    Door1.GetComponent("Animator").enabled = false;     	// Stop when fully open
    Door2.GetComponent("Animator").enabled = false;
   // Debug.Log("<color=red>Animator Disabled</color>");

    yield WaitForSeconds(5);                            	// Wait 5 seconds

    Door1.GetComponent("Animator").enabled = true;      	// Then close the doors
    Door2.GetComponent("Animator").enabled = true;
    doorSound.Play();
    //Debug.Log("<color=green>Animator Enabled</color>");

    yield WaitForSeconds(1);                           	 	// Play the full closing half of animation

    Door1.GetComponent("Animator").enabled = false;     	// Then stop the door animations
    Door2.GetComponent("Animator").enabled = false;
    Debug.Log("<color=red>Animator Disabled</color>");
    
    ButtonOn.SetActive(false);                          	// Hide the green button
    ButtonOff.SetActive(true);                          	// Show the red button
}
