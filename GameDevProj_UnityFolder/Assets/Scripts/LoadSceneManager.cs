using UnityEngine;
using System.Collections;

public class LoadSceneManager : MonoBehaviour {
	
	public int levelToLoad;
	public AudioClip winSound;
	public GameObject magnetCapsuleNeeded;
	private PlayerBehaviour playerInfo;

	void Start () {
		playerInfo = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
	}

	void OnTriggerEnter(Collider c){
		//audio.PlayOneShot (winSound); 
	
		if (c.CompareTag ("Player")) {
			if(gameObject.CompareTag("BuildingLoader")){
				if(playerInfo.magnetCapsule == true)
					Invoke ("loadWin", 1.0f);
				else
					Instantiate(magnetCapsuleNeeded);
			}
			else{
			Invoke ("loadWin", 1.0f);
			}
		}
			//Invoke ("loadWin", 1.0f);
		
	}
	
	public void loadWin(){
		Application.LoadLevel(levelToLoad);
	}

}//end Of Class
