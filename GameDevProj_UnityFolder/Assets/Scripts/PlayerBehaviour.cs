using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
	
	//public int livesLeft = 3;
	//private bool carryingKey = false;
	private bool mainGatesKey = false;

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

	public int coins = 0;
	public int keyPieces = 0;

	/** Reference to audio Clips */
	//public AudioClip deathSound;
	//public AudioClip keyPickupSound;
	//public AudioClip civilianSavedSound;
	//public int gameOverLoad;

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
	public void setCoins(int x){
		coins = x;
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

	public int GetCoins(){
		return coins;	
	}


	// Start and Update Methods ************************************************************
	public void Start(){
		unityCharacter = GameObject.FindWithTag("Player").GetComponent<ThirdPersonCharacter>();
	}

	public void Update(){
		if (speedUpgrade) 
			unityCharacter.setSpeed(1.4f, 1.4f);

		if (torchUpgrade)
			;

		if (gunUpgrade)
			;

	}//end of Update ************************************************************************


	private void OnTriggerEnter(Collider c){

		if(c.CompareTag("GunUpgrade"))
			Instantiate(gunUpgradeMenuPrefab);
		
		if(c.CompareTag("SpeedUpgrade"))
			Instantiate(speedUpgradeMenuPrefab);

		if(c.CompareTag("TorchUpgrade"))
			Instantiate(torchUpgradeMenuPrefab);

		if(c.CompareTag("Coin")){
			coins = coins + 50;
			print(coins.ToString());
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

		if(c.CompareTag("GunUpgrade")){
			print("Exited Gun");
			Destroy(GameObject.FindWithTag("GunPopUp"));
		}
		
		if(c.CompareTag("SpeedUpgrade")){
			print("Exited Speed");
			Destroy(GameObject.FindWithTag("SpeedPopUp"));
		}
		
		if(c.CompareTag("TorchUpgrade")){
			print("Exited Torch");
			Destroy(GameObject.FindWithTag("TorchPopUp"));
		}
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
