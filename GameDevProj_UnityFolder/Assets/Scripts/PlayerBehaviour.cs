using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
	
	//public int livesLeft = 3;
	//private bool carryingKey = false;
	private bool mainGatesKey = false;
	private bool metalWallKey = false;

	//References unityCharacter Script 
	private ThirdPersonCharacter unityCharacter;

	//GameObject References for Instantiation
	public GameObject speedUpgradeMenuPrefab;
	public GameObject torchUpgradeMenuPrefab;
	public GameObject gunUpgradeMenuPrefab;

	//Upgrade Managers
	private bool gunUpgrade = false;
	private bool speedUpgrade = false;
	private bool torchUpgrade = false;
	public bool magnetCapsule = false;

	public int coins = 0;
	public int health = 5;
	public int livesLeft = 3;
	public int keyPieces = 0;

	/** Reference to audio Clips */
	//public AudioClip deathSound;
	public AudioClip keyPickUpSound;
	public AudioClip coinPickUpSound;
	//public AudioClip civilianSavedSound;
	//public int gameOverLoad;

	private AudioSource source;

	// SET ***********************************************
	public void SetGunUpgrade(bool x){
		gunUpgrade = x;	
	}
	public void SetSpeedUpgrade(bool x){
		speedUpgrade = x;	
	}
	public void SetTorchUpgrade(bool x){
		torchUpgrade = x;	
	}
	public void SetMetalWallKey(bool x){
		metalWallKey = x;	
	}
	public void setCoins(int x){
		coins = x;
	}
	public void setHealth(int x){
		health = x;
	}

	// GET ************************************************
	public bool GetGunUpgrade(){
		return gunUpgrade;	
	}
	public bool GetSpeedUpgrade(){
		return speedUpgrade;	
	}
	public bool GetTorchUpgrade(){
		return torchUpgrade;	
	}
	public bool HasMagnetCapsule(){
		return magnetCapsule;	
	}

	public int GetCoins(){
		return coins;	
	}
	public int GetHealth(){
		return health;	
	}
	public int GetLivesLeft(){
		return livesLeft;	
	}
	public int GetKeyPieces(){
		return keyPieces;	
	}
	public bool GetMetalWallKey(){
		return metalWallKey;	
	}

	// Start and Update Methods ************************************************************
	public void Start(){
		unityCharacter = GameObject.FindWithTag("Player").GetComponent<ThirdPersonCharacter>();
		source = GetComponent<AudioSource>();

	}

	public void Update(){
		checkUpgrades ();

	}//end of Update ************************************************************************


	private void checkUpgrades(){
		if (speedUpgrade) 
			unityCharacter.setSpeed(1.4f, 1.4f);
		
		if (torchUpgrade)
			;
		
		if (gunUpgrade)
			;


	}//end of Check Upgrades

	private void OnTriggerEnter(Collider c){

		if(c.CompareTag ("MetalWallKey")){
			metalWallKey = true;
		}

		if(c.CompareTag("GunUpgrade"))
			Instantiate(gunUpgradeMenuPrefab);
		
		if(c.CompareTag("SpeedUpgrade"))
			Instantiate(speedUpgradeMenuPrefab);

		if(c.CompareTag("TorchUpgrade"))
			Instantiate(torchUpgradeMenuPrefab);

		if(c.CompareTag("Coin")){
			coins = coins + 50;
			source.PlayOneShot(coinPickUpSound);
			//print(coins.ToString());
			DestroyObject(c.gameObject);
		}

		if(c.CompareTag("KeyPiece")){
			keyPieces = keyPieces + 1;
			source.PlayOneShot(keyPickUpSound);
			DestroyObject(c.gameObject);
		}

		if(c.CompareTag("MagnetCapsule")){
			magnetCapsule = true;
			source.PlayOneShot(keyPickUpSound);
			DestroyObject(c.gameObject);
		}

		/*
		if (c.CompareTag("Kill")) {
			if(Time.time > nextTimeAllowedToDie) { 
				LoseLife(); 
				print("OWWW");
			} 

		}
		*/

	}

	private void onTriggerExit(Collider c){

		if(c.CompareTag("GunUpgrade"))
			Destroy(GameObject.FindWithTag("GunPopUp"));
		
		if(c.CompareTag("SpeedUpgrade"))
			Destroy(GameObject.FindWithTag("SpeedPopUp"));

		if(c.CompareTag("TorchUpgrade"))
			Destroy(GameObject.FindWithTag("TorchPopUp"));
		
	}

	/**
	 * Respawn in level at a 'respawn' position
	 */

	/*
	private void MoveToCheckpoint(){ 

		GameObject respawnGO = GameObject.FindWithTag("Respawn"); 
			Vector3 checkPoint = respawnGO.transform.position; 
			transform.position = checkPoint; 

	}
	*/
}
