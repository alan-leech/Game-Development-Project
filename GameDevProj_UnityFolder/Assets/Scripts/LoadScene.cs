using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

	public void loadScene(int index){
		Application.LoadLevel (index);
	}
}
