using UnityEngine;
using System.Collections;


public class HideWhenClicked : MonoBehaviour {

	//Reference to PlayerBehaviour script
	private PlayerBehaviour playerInfo;

	void Start()
	{
		//Specify reference location, script is componnent of Object tagged "Player"
		playerInfo = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
		//gameObject.SetActive (true);
	}


	void Update()
	{
		UpgradePopUpManager ();
	}

	private void UpgradePopUpManager(){
		//If "P" is pressed
		if (Input.GetKeyDown (KeyCode.P)) {
			
			//If "P" is pressed during the gun upgrade popup menu
			if(gameObject.name.Equals("GunUpgradeMenu(Clone)")){
				
				if(playerInfo.GetCoins() >= 900 && !playerInfo.GetGunUpgrade()){
					playerInfo.SetGunUpgrade(true);
					playerInfo.setCoins(playerInfo.GetCoins() - 900);
				}
				else if(playerInfo.GetGunUpgrade() == true)
					print("Purchased Gun");
				else
					print("Not enough Coins to purchase Gun");
				
			}//end If Gun
			
			//If "P" is pressed during the speedboost upgrade popup menu
			if(gameObject.name.Equals("SpeedUpgradeMenu(Clone)")){
				
				if(playerInfo.GetCoins() >= 600 && !playerInfo.GetSpeedUpgrade()){
					playerInfo.SetSpeedUpgrade(true);
					playerInfo.setCoins(playerInfo.GetCoins() - 600);
				}
				else if(playerInfo.GetSpeedUpgrade() == true)
					print("Purchased Speed Boost");
				else
					print("Not enough Coins to purchase Speed Boost");
				
			}//end If Speed
			
			//If "P" is pressed during the torch upgrade popup menu
			if(gameObject.name.Equals("TorchUpgradeMenu(Clone)")){
				
				if(playerInfo.GetCoins() >= 300 && !playerInfo.GetTorchUpgrade()){
					playerInfo.SetTorchUpgrade(true);
					playerInfo.setCoins(playerInfo.GetCoins() - 300);
				}
				else if(playerInfo.GetTorchUpgrade() == true)
					print("Purchased Torch");
				else
					print("Not enough Coins to purchase Torch");
				
			}//end If Torch
			
		}//end If "P" is pressed 
		
		//Deactivate popup menu when use presses enter
		if (Input.GetKeyDown ("return"))
			//gameObject.SetActive (false);
			Destroy (gameObject);

	}//end of UpgradePopUpManager...

}