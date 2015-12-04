using UnityEngine;
using System.Collections;

public class ExitSensorBehaviour : MonoBehaviour {

 	public PlayerBehaviour playerScriptedObject;
   	public GameObject exit;
  
  	private void OnTriggerEnter(){

		int keyPieces = playerScriptedObject.GetKeyPieces();

		if (keyPieces >= 4) 
			exit.GetComponent<Animation> ().Play ();

  	}


}//end of class