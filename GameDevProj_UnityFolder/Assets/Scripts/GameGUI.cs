using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	/** 
	 * Reference All Images for GUI Textures
	 */
	public Texture2D civilian0;
	public Texture2D civilian1;
	public Texture2D civilian2;
	public Texture2D civilian3;
	public Texture2D civilian4;
	public Texture2D civilianAll;
	public Texture2D lives1;
	public Texture2D lives2;
	public Texture2D lives3;
	public Texture2D lives4;
	public Texture2D lives5;
	public Texture2D keyIcon;
	public Texture2D noKeyIcon;
	public Texture2D timeLeft1;
	public Texture2D timeLeft2;
	public Texture2D timeLeft3;
	public Texture2D timeLeft4;
	public Texture2D timeLeft5;
	

	private PlayerBehaviour playerInfo;


	// Use this for initialization
	void Start () {
		playerInfo = gameObject.GetComponent<PlayerBehaviour>();
	}
	
	/**
	* main GUI method:
	*	
	* <ol>
	*  <li>start a horizontal layout arrangement </li>
	*  <li>display lives left</li>
	*  <li>display Civilians Saved</li>
	*  <li>display whether or not player is carrying the key</li>
	* </ol>
	*/
	private void OnGUI(){
 		GUILayout.BeginHorizontal();
 		DisplayLivesLeft();
		DisplayHealth ();
		DisplayCoins ();
		DisplayKeyStatus();
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		DisplayUpgrades ();
		GUILayout.EndHorizontal();
	}

	/**
	 * Display Key icon to show if the player is carrying the key
	 */
	void DisplayKeyStatus(){

		GUILayout.Label ("KEY PIECES: " + playerInfo.GetKeyPieces() + "/4");

		/*
		//bool carryingKey = playerInfo.IsCarryingKey();
		if (carryingKey) {
			GUILayout.Label ("Key:");
			GUILayout.Label (keyIcon);
		} 
		else if(!carryingKey)
		{
			GUILayout.Label ("Key:");
			GUILayout.Label (noKeyIcon);
		}
		*/

	}

	/**
	 * Display Life Icons to show how many lives the player has left
	 */
	void DisplayLivesLeft(){
		int livesLeft = playerInfo.GetLivesLeft();

		if (livesLeft == 1) { GUILayout.Label("Lives:" + livesLeft); /*GUILayout.Label(lives1);*/}
		//if (livesLeft == 1) { GUILayout.Label("Lives:" + livesLeft); GUI.Label(noteRect, lives1);}
		if (livesLeft == 2) { GUILayout.Label("Lives:" + livesLeft); /*GUILayout.Label(lives2);*/}
		//if (livesLeft == 2) { GUILayout.Label("Lives:" + livesLeft); GUI.Label(noteRect, lives2);}
		if (livesLeft == 3) { GUILayout.Label("Lives:" + livesLeft); /*GUILayout.Label(lives3);*/}
	}

	/**
	 * Display Civilian Icons to show how many Civilians the player has saved
	 * Display "ALL" Icon when number of Civilians saved equals the total Civilians in the level
	 */
	void DisplayCoins(){
		int coins = playerInfo.GetCoins();

		GUILayout.Label ("COINS: " + coins);
		//if (civiliansSaved == 0) { GUILayout.Label("Civilians:" + civiliansSaved); GUILayout.Label(civilian0);}
		//if (civiliansSaved == 1) { GUILayout.Label("Civilians:" + civiliansSaved); GUILayout.Label(civilian1);}
	}

	void DisplayHealth(){
		int health = playerInfo.GetHealth();
		
		GUILayout.Label ("Health: " + health);
		//if (civiliansSaved == 0) { GUILayout.Label("Civilians:" + civiliansSaved); GUILayout.Label(civilian0);}
		//if (civiliansSaved == 1) { GUILayout.Label("Civilians:" + civiliansSaved); GUILayout.Label(civilian1);}
	}

	void DisplayUpgrades(){
		bool gun = playerInfo.GetGunUpgrade();
		bool speedBoost = playerInfo.GetSpeedUpgrade();
		bool torch = playerInfo.GetTorchUpgrade();

		GUILayout.Label ("GUN: " + gun);
		GUILayout.Label ("SPEED BOOST: " + speedBoost);
		GUILayout.Label ("TORCH: " + torch);

		//if (civiliansSaved == 0) { GUILayout.Label("Civilians:" + civiliansSaved); GUILayout.Label(civilian0);}
		//if (civiliansSaved == 1) { GUILayout.Label("Civilians:" + civiliansSaved); GUILayout.Label(civilian1);}
	}
	/*
	void DisplayExitPopup()
	{
		bool carryingKey = playerScriptedObject.IsCarryingKey();
		bool allCivilians = playerScriptedObject.SavedAllCivilains();

		if(!wasOn & (allCivilians & carryingKey)){
			Instantiate(exitPopupPrefab);
			wasOn = true;
		}
	}
	*/

}
