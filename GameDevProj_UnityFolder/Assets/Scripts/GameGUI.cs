using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	/** 
	 * Reference All Images for GUI Textures
	 */
	public Texture2D lives1;
	public Texture2D lives2;
	public Texture2D lives3;
	public Texture2D key;
	public Texture2D noKey;
    public Texture2D health1;
    public Texture2D health2;
    public Texture2D health3;
    public Texture2D health4;
    public Texture2D health5;
    public Texture2D coin;
    public Texture2D gunIcon;
    public Texture2D speedBoostIcon;
    public Texture2D torchIcon;


    private PlayerBehaviour playerInfo;


	// Use this for initialization
	void Start () {
		playerInfo = gameObject.GetComponent<PlayerBehaviour>();
	}
	

	private void OnGUI(){
 		GUILayout.BeginHorizontal();
 		DisplayLivesLeft();
        DisplayKeyStatus();
        DisplayHealth ();
        DisplayUpgrades();
        DisplayCoins ();
       	GUILayout.EndHorizontal();
	}

	/**
	 * Display Key icon to show if the player is carrying the key
	 */
	void DisplayKeyStatus(){
	
        if (playerInfo.GetKeyPieces() >= 4) { GUI.Label(new Rect(500, 0, key.width, key.height), key); }
        else{ GUI.Label(new Rect(500, 0, noKey.width, noKey.height), noKey); }		
    }

	/**
	 * Display Life Icons to show how many lives the player has left
	 */
	void DisplayLivesLeft(){
		int livesLeft = playerInfo.GetLivesLeft();

        if (livesLeft == 1) { GUI.Label(new Rect(100, 0, lives1.width, lives1.height), lives1); }
        if (livesLeft == 2) { GUI.Label(new Rect(100, 0, lives2.width, lives2.height), lives2); }
        if (livesLeft == 3) { GUI.Label(new Rect(100, 0, lives3.width, lives3.height), lives3); }

    }

	void DisplayCoins(){
		int coins = playerInfo.GetCoins();

        GUI.Label(new Rect(0, 0, coin.width, coin.height), coin);
        GUI.color = Color.black;
		GUILayout.Label ("               " +  coins + "\t\t\t\t\t\t\t\t\t" +  playerInfo.GetKeyPieces() + "/4");


    }

    void DisplayHealth(){
		int health = playerInfo.GetHealth();
		
        if (health == 1) { GUI.Label(new Rect(350, 0, health1.width, health1.height/2), health1); }
        if (health == 2) { GUI.Label(new Rect(350, 0, health2.width, health2.height/2), health2); }
        if (health == 3) { GUI.Label(new Rect(350, 0, health3.width, health3.height/2), health3); }
        if (health == 4) { GUI.Label(new Rect(350, 0, health4.width, health4.height/2), health4); }
        if (health == 5) { GUI.Label(new Rect(350, 0, health5.width, health5.height/2), health5); }
    }

	void DisplayUpgrades(){
		bool gun = playerInfo.GetGunUpgrade();
		bool speedBoost = playerInfo.GetSpeedUpgrade();
		bool torch = playerInfo.GetTorchUpgrade();

        if (gun == true && speedBoost == false && torch == false) { GUI.Label(new Rect(0, 100, gunIcon.width, gunIcon.height), gunIcon); }
        if (speedBoost == true && gun == false && torch == false){ GUI.Label(new Rect(0, 100, speedBoostIcon.width, speedBoostIcon.height), speedBoostIcon);}
        if (torch == true && speedBoost == false && gun == false) {GUI.Label(new Rect(0, 100, torchIcon.width, torchIcon.height), torchIcon);}
        if (gun == true && speedBoost == true && torch == false) { GUI.Label(new Rect(0, 100, gunIcon.width, gunIcon.height), gunIcon); }
        if (speedBoost == true && gun == true && torch == false) { GUI.Label(new Rect(0, 200, speedBoostIcon.width, speedBoostIcon.height), speedBoostIcon); }
        if (torch == true && speedBoost == false && gun == true) { GUI.Label(new Rect(0, 200, torchIcon.width, torchIcon.height), torchIcon); }
        if (gun == true && speedBoost == false && torch == true) { GUI.Label(new Rect(0, 100, gunIcon.width, gunIcon.height), gunIcon); }
        if (gun == false && speedBoost == true && torch == true) { GUI.Label(new Rect(0, 100, speedBoostIcon.width, speedBoostIcon.height), speedBoostIcon); }
        if (speedBoost == true && gun == false && torch == true) { GUI.Label(new Rect(0, 200, torchIcon.width, torchIcon.height), torchIcon); }
        if (gun == true && speedBoost == true && torch == true) { GUI.Label(new Rect(0, 100, gunIcon.width, gunIcon.height), gunIcon); }
        if (gun == true && speedBoost == true && torch == true) { GUI.Label(new Rect(0, 200, speedBoostIcon.width, speedBoostIcon.height), speedBoostIcon); }
        if (gun == true && speedBoost == true && torch == true) { GUI.Label(new Rect(0, 300, torchIcon.width, torchIcon.height), torchIcon); }
		
    }
}//end of class
