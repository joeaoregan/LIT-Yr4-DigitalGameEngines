using UnityEngine;
using UnityEngine.UI;   // To use UI components
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;	// Starting health for level 1
    public int currentHealth;
    public Slider healthSlider;     	// Slider UI element
	public Image damageImage;
	public AudioClip owClip;			// Player hit sound
	public AudioClip oohClip;			// Player hit sound
	public AudioClip ahClip;			// Player hit sound
    public AudioClip deathClip;     	// Sound player makes when they lose the game
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f); // Red, and mostly transparent

	public Canvas playerHUD;			// Disable when fade to dead animation enabled
	public Animator fadeToDead;			// Show player has died message when player has been killed

    Animator anim;
    AudioSource playerAudio;
	//public FirstPersonController playerFPS;
	//public float walkSpeed;
    //PlayerMovement playerMovement;  	// Reference to the player movement script, stop player running around if its dead
    //PlayerShooting playerShooting;
    bool isDead;
    bool damaged;

	GameObject gc;	// GameController

    void Awake ()
	{
		PlayerPrefs.SetInt("Health", startingHealth);	// Reset the health

		anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();

       // playerMovement = GetComponent <PlayerMovement> ();            // Get the component of the script
        //playerShooting = GetComponentInChildren <PlayerShooting> ();
		//playerFPS = GetComponent<FirstPersonController>();

		if (SceneManager.GetActiveScene().buildIndex == 3)				// If the current scene is level 1
			currentHealth = startingHealth;								// Set health to 100
		else															// otherwise
			currentHealth = PlayerPrefs.GetInt("Health");				// Get the saved health		

		healthSlider.value = currentHealth;
		Debug.Log("<color=red>Player Health: </color>" + currentHealth);

		gc = GameObject.FindWithTag ("GameController");
    }


    void Update ()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

		RandomHurtSound ();							// Choose random hurt sound

        if(currentHealth <= 0 && !isDead)
        {
            //Death ();
			StartCoroutine(Death());
        }
    }

    // If health drops below 0, call Death()
	IEnumerator Death ()
    {
        isDead = true;

		//SaveGameState (); 																// Save the state
		gc.GetComponent<ExitLevel> ().SaveState ();											// Save the state

        //playerShooting.DisableEffects ();

		anim.enabled = true;																// If animator is left on, it locks camera rotation for FPSController
        anim.SetTrigger ("Die");    														// Player death animation

		playerAudio.clip = deathClip;
        playerAudio.Play ();

		yield return new WaitForSeconds (1);

		playerHUD.enabled = false;
		//SceneManager.LoadScene (2);														// Go to menu
		fadeToDead.SetTrigger("Fade");
		//Debug.Log ("CHANGE SCENE XXXXXXXXXXXXXXXXXXXXX");

		//GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;	// Don't allow player to move when dead/dying by moving mouse
		//StartCoroutine ("QuitToMenu");
        //playerMovement.enabled = false; // Player stops moving
		//playerFPS.enabled = false;
        //playerShooting.enabled = false;
    }


	IEnumerator QuitToMenu(){
		yield return new WaitForSeconds (1);												// Wait for the amount of time
		SceneManager.LoadScene (2);															// Go to menu
	}

    public void RestartLevel ()
    {
        SceneManager.LoadScene (3);	// Level 1: will have to fix for level 2 and 3 XXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    }

	void RandomHurtSound(){
		// Choose random hurt sound
		int clipSelect = Random.Range (1, 4);		// Choose a clip by selecting a random number between 1 and 3 (4 is never reached)
		if (clipSelect == 1)
			playerAudio.clip = owClip;
		else if (clipSelect == 2)
			playerAudio.clip = oohClip;
		else
			playerAudio.clip = ahClip;

		//playerAudio.pitch = Random.Range (0.6f, 1.5);
		//playerAudio.pitch = 0.5f + (Random.Range (1, 11) / 10.0f);
		//playerAudio.pitch = 1.8f; // only works for multiples of 1 - no good

		playerAudio.Play ();
		//playerAudio.pitch = 1;
	}

	public int getPlayerHealth() {
		return currentHealth;
	}
	/*
	void SaveGameState(){
		// Save the state
		if (SceneManager.GetActiveScene ().buildIndex == 3)
			gc.GetComponent<ExitLevel1> ().SaveState ();
		else if (SceneManager.GetActiveScene ().buildIndex == 4)
			gc.GetComponent<ExitLevel2> ().SaveState ();
		else if (SceneManager.GetActiveScene ().buildIndex == 5)
			gc.GetComponent<ExitLevel3> ().SaveState ();
	}
	*/
}
