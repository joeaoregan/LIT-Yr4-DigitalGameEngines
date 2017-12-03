import UnityEngine.UI;

var distanceToObject: float = PlayerCasting.DistanceFromTarget;     // Use raycasting to measure the distance
var TextDisplay: GameObject;                                        // The game object to interact with

var BassAudio: AudioSource;                                         // Sound effect to play

function Update() {
    distanceToObject = PlayerCasting.DistanceFromTarget;            // Calculate the distance between the player and object
}

function OnMouseOver() {                                            // When the cursor is over an object
    if (distanceToObject <= 2) {                                    // And the distance to the object is less than 2
        TextDisplay.GetComponent.<Text>().text = "Slap The Bass";   // Display a message
    }
    if (Input.GetButtonDown("Action")) {                            // If the action button is pressed
        if (distanceToObject <= 2) {                                // And the distance is less than 2
            SlapTheBass();                                          // Play the bass effect
        }
    }
}

function OnMouseExit() {                                            // When the cursor is not over the object
    TextDisplay.GetComponent.<Text>().text = "";                    // Clear the action message text
}

function SlapTheBass() {
    BassAudio.Play();                                               // Play the bass effect
}