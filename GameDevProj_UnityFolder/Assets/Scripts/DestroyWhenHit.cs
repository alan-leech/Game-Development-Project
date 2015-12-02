using UnityEngine;
using System.Collections;

	/**
	 * Make Parent Object destroy itself when something enters it
 	*/
	public class DestroyWhenHit : MonoBehaviour {

	/**
	 * When Collided with, destroy Parent Object
 	*/
	private void OnTriggerEnter()
	{
		Destroy (gameObject);
	}
}
