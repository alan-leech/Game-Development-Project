using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

		RenderSettings.fog = true;
	}
	
	// Update is called once per frame
	void Update () {
		RenderSettings.fogDensity = 0.01f;
	}
}
