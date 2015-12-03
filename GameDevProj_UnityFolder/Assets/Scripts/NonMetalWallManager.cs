using UnityEngine;
using System.Collections;

public class NonMetalWallManager : MonoBehaviour {

	private PlayerBehaviour playerInfo;
	
	
	// Use this for initialization
	void Start () {
		playerInfo = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInfo.GetMetalWallKey())
			Destroy (gameObject);
	}
}
