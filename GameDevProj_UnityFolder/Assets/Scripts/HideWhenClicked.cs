using UnityEngine;
using System.Collections;


public class HideWhenClicked : MonoBehaviour {


	// CLICK Wasn't working changed to keyboard input
	void Start()
	{
			gameObject.SetActive (true);
	}


	void Update()
	{
		if(Input.GetKeyDown("return"))
			gameObject.SetActive (false);
	}
}