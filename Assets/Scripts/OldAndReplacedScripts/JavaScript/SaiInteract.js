import UnityEngine.UI;

var distanceToObject: float = PlayerCasting.DistanceFromTarget;                                     // Use raycasting to measure the distance
var TextDisplay: GameObject;                                                                        // The game object to interact with

function Update() {
    distanceToObject = PlayerCasting.DistanceFromTarget;                                            // Use raycasting to determine the distance to an object
}

/*
    If the cursor is over the object display a message
*/
function OnMouseOver() {                                                                            // When the cursor is over an object
    if (distanceToObject <= 2) {                                                                    // If the distance to an object is less than 2
        TextDisplay.GetComponent.<Text>().text = "Sai! I Could Go All Teenage Mutant Ninja Turtle"; // Display message
    }
    if (Input.GetButtonDown("Action")) {                                                            // If the action button is pressed
        if (distanceToObject <= 2) {                                                                // And the distance to the object is less than 2
            TextDisplay.GetComponent.<Text>().text = "They Looked To Be Jammed In There";           // Display Message
            yield WaitForSeconds(1);                                                                // Wait one second
            TextDisplay.GetComponent.<Text>().text = "";                                            // And Clear The Text
        }
    }
}

/*
    Clear the action text when the cursor moves away from the object
*/
function OnMouseExit() {                                                                            // When the cursor is not over an object
    TextDisplay.GetComponent.<Text>().text = "";                                                    // Clear the text
}