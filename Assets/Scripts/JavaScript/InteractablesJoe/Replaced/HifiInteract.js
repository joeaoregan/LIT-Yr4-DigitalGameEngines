import UnityEngine.UI;

var distanceToObject: float = PlayerCasting.DistanceFromTarget;                                     // Use raycasting to measure the distance
var ActionText: GameObject;                                                                        // The game object to interact with

function Update() {
    distanceToObject = PlayerCasting.DistanceFromTarget;                                            // Use raycasting to determine the distance to an object
}

/*
    If the cursor is over the object display a message
*/
function OnMouseOver() {                                                                            // When the cursor is over an object
    if (distanceToObject <= 3) {                                                                    // If the distance to an object is less than 2
    	ActionText.GetComponent.<Text>().text = "Music by Joe O'Regan";     						// Display message
    }     
}

/*
    Clear the action text when the cursor moves away from the object
*/
function OnMouseExit() {                                                                            // When the cursor is not over an object
    ActionText.GetComponent.<Text>().text = "";                                                    // Clear the text
}