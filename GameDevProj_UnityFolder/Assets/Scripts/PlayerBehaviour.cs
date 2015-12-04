using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	//Key booleans
	private bool mainGatesKey = false;
	private bool metalWallKey = false;

	//References unityCharacter Script 
	private ThirdPersonCharacter unityCharacter;

	//GameObject References for Instantiation
	public GameObject speedUpgradeMenuPrefab;
	public GameObject torchUpgradeMenuPrefab;
	public GameObject gunUpgradeMenuPrefab;
	public GameObject magnetCapsuleNotifyPrefab;

	//Upgrade Managers
	private bool gunUpgrade = false;
	private bool speedUpgrade = false;
	private bool torchUpgrade = false;
	public bool magnetCapsule = false;

	//Interger Values
	private int coins = 0;
	private int health = 5;
	private int livesLeft = 3;
	private int keyPieces = 0;
	public int levelToLoad;

	/** Reference to audio Clips */
	public AudioClip dmgSound;
	public AudioClip deathSound;
	public AudioClip keyPickUpSound;
	public AudioClip coinPickUpSound;
	public AudioClip healthPickUpSound;

	private AudioSource source;

	//Death Managing Vals
	private float delayBetweenDeaths = 0.5f; 
	private float nextTimeAllowedToDie = 0; 


	// Start and Update Methods ************************************************************
	public void Start(){
		unityCharacter = GameObject.FindWithTag("Player").GetComponent<ThirdPersonCharacter>();
		source = GetComponent<AudioSource>();
	}

	public void Update(){
		checkUpgrades ();
		checkHealth ();
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
			DestroyObject(c.gameObject);
		}

		if(c.CompareTag("KeyPiece")){
			keyPieces++;
			source.PlayOneShot(keyPickUpSound);
			DestroyObject(c.gameObject);
		}

		if(c.CompareTag("MagnetCapsule")){
			magnetCapsule = true;
			source.PlayOneShot(keyPickUpSound);
			Instantiate(magnetCapsuleNotifyPrefab);
			DestroyObject(c.gameObject);
		}

		if(c.CompareTag("damage")){
			source.PlayOneShot(dmgSound);
			health--;
		}

		if(c.CompareTag("health")){
			source.PlayOneShot(healthPickUpSound);
			DestroyObject(c.gameObject);
			if(health < 5){
				health++;
			}
		}

	}//end of OnTriggerEnter

	private void onTriggerExit(Collider c){

		if(c.CompareTag("GunUpgrade"))
			Destroy(GameObject.FindWithTag("GunPopUp"));
		
		if(c.CompareTag("SpeedUpgrade"))
			Destroy(GameObject.FindWithTag("SpeedPopUp"));

		if(c.CompareTag("TorchUpgrade"))
			Destroy(GameObject.FindWithTag("TorchPopUp"));
		
	}

	private void checkHealth(){
		
		if (health <= 0) {
			if(Time.time > nextTimeAllowedToDie){
				livesLeft--;
				source.PlayOneShot(deathSound);
				MoveToCheckpoint();
				health = 5;
				nextTimeAllowedToDie = Time.time + delayBetweenDeaths;
				if (livesLeft == 0) 
						Application.LoadLevel (levelToLoad);
			}
		}
	}//end of CheckHealth

	private void MoveToCheckpoint(){ 

		GameObject respawnGO = GameObject.FindWithTag("Respawn"); 
			Vector3 checkPoint = respawnGO.transform.position; 
			transform.position = checkPoint; 

	}//end of MoveToCheckpoint

	
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

}//end of class
