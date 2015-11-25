using UnityEngine;
using System.Collections;

public class throwStone : MonoBehaviour {

	public GameObject stone;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.E))
		{
			Instantiate(stone, transform.position+(transform.forward*6), transform.rotation);

		}

	}
}
