using UnityEngine;
using System.Collections;

public class LoadSceneManager : MonoBehaviour {
	
	public int levelToLoad;
	public AudioClip winSound;

	void OnTriggerEnter(){
		//audio.PlayOneShot (winSound); 
		Invoke ("loadWin", 1.0f);
	}
	
	void loadWin(){
		Application.LoadLevel(levelToLoad);
	}

}//end Of Class
