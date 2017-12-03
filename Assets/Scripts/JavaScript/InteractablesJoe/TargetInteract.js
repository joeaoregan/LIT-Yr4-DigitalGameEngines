import UnityEngine.UI;

var distanceToObject: float = PlayerCasting.DistanceFromTarget;                                     // Use raycasting to measure the distance
var TextDisplay: GameObject;                                                                        // The game object to interact with

var hasGun: GameObject;

function Update() {
    distanceToObject = PlayerCasting.DistanceFromTarget;                                            // Use raycasting to determine the distance to an object
}

/*
    If the cursor is over the object display a message
*/
function OnMouseOver() {                                                                            // When the cursor is over an object
    if (distanceToObject <= 2) {                                                                    // If the distance to an object is less than 2
        if (hasGun.activeSelf) {
            TextDisplay.GetComponent.<Text>().text = "Hit the bullseye, win a completed objective"; // Display message
        }
        else {
            TextDisplay.GetComponent.<Text>().text = "Find the gun for target practice";            // Display message
        }
    } 
    
}

/*
    Clear the action text when the cursor moves away from the object
*/
function OnMouseExit() {                                                                            // When the cursor is not over an object
    TextDisplay.GetComponent.<Text>().text = "";                                                    // Clear the text
}