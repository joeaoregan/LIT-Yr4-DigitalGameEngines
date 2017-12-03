import UnityEngine.UI;

var distanceToObject: float = PlayerCasting.DistanceFromTarget;         // Use raycasting to measure the distance
var TextDisplay: GameObject;                                            // The game object to interact with

function Start() {

}

function Update() {
    distanceToObject = PlayerCasting.DistanceFromTarget;                // Calculate the distance between the player and object
}

function OnMouseOver() {                                                // When the cursor is over an object
 //  if (Input.GetButtonDown("Action")) {                               // If the action button is pressed
 //       if (distanceToObject <= 3) {                                  // And the distance to the object is less than 2
 //           DoNothing();                                              // Call The Do Nothing Function
 //       }
 //   }
 //  else

    if (distanceToObject <= 3) {                                        // And the distance to the object is less than 2
        if (Input.GetButtonDown("Action")){
           // DoNothing();
            TextDisplay.GetComponent.<Text>().text = "Nothing happened";        // Display Message
            yield WaitForSeconds(1);                                            // Wait one second
            TextDisplay.GetComponent.<Text>().text = "";                        // And Clear The Text
    }
        else
            TextDisplay.GetComponent.<Text>().text = "The outside";     // Display a message
    }  
}

function OnMouseExit() {                                                // When the cursor is not over the object
    TextDisplay.GetComponent.<Text>().text = "";                        // Clear the action message text
}

function DoNothing() {
    TextDisplay.GetComponent.<Text>().text = "Nothing happened";        // Display Message
    yield WaitForSeconds(1);                                            // Wait one second  (GREYED OUT???)
    TextDisplay.GetComponent.<Text>().text = "";                        // And Clear The Text
}