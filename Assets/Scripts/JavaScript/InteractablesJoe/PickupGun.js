import UnityEngine.UI;

var distanceToObject: float = PlayerCasting.DistanceFromTarget;     // Distance from the Player to the game object
var TextDisplay: GameObject;                                        // Canvas action text

var FakeGun: GameObject;                                            // The collectable gun object
var RealGun: GameObject;                                            // The gun the player is carrying
var AmmoDisplay: GameObject;                                        // Shows the text with the amount of ammo the player has
var TargetDisplay: GameObject;										// Shows the text with the amount of targets the player has to shoot
var PickupAudio: AudioSource;                                       // Sound effect for picking up ammo

var hasGun: GameObject;                                             // Set the hasGun objective to true

function Update() {
    distanceToObject = PlayerCasting.DistanceFromTarget;             // Use raycasting to calculate the distance from the player to the object
}

function OnMouseOver() {                                            // If the cursor is over the object
    if (distanceToObject <= 2) {                                     // and the distance is less than 2
        TextDisplay.GetComponent.<Text>().text = "Take 9mm Pistol"; // Display the message
    }       
    if (Input.GetButtonDown("Action")) {                            // If the action button (E) is pressed
        if (distanceToObject <= 2) {                                 // and the distance is less than 2
            TakeGun();                                              // call the take gun function
        }
    }
}

function OnMouseExit() {                                            // When the cursor has moved away from the object
    TextDisplay.GetComponent.<Text>().text = "";                    // Reset the action text
}

function TakeGun() {
    hasGun.SetActive(true);                                         // Set the hasGun objective as true

    PickupAudio.Play();                                             // play the sound effect
    transform.position = Vector3(0, -1000, 0);                      // hide the weapon out of the scene
    FakeGun.SetActive(false);                                       // hide pickup gun
    RealGun.SetActive(true);                                        // display player gun
    AmmoDisplay.SetActive(true);                                    // Set the UI for displaying the Players ammo count active
    TargetDisplay.SetActive(true);                                  // Set the UI for displaying the targets to shoot count active

    // CANCELLED OUT BY OnMouseExit()
    //TextDisplay.GetComponent.<Text>().text = "Objective 1:\nFind Gun Complete"; // Display the message
    //yield WaitForSeconds(2);                            			// Wait one second (half way through the 2 second animation)
    //TextDisplay.GetComponent.<Text>().text = ""; 					// Display the message
}
