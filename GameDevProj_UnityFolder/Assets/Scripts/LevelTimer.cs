using UnityEngine;
using System.Collections;

public class LevelTimer : MonoBehaviour 
{
	public int levelTime = 60;

	public int gameOverLoad = 0;
	private CountdownTimer myTimer;
	public GameObject player;
	
	private void Start()
	{
		myTimer = GetComponent<CountdownTimer>();
		myTimer.ResetTimer(levelTime);	
	}

	private void Update()
	{
		int fog1Start = levelTime * 4/5;
		int fog1End  = 	(levelTime * 3/5)+1;
		int fog2Start = levelTime * 3/5;
		int fog2End = 	(levelTime * 2/5)+1;
		int fog3Start = levelTime * 2/5;
		int fog3End =	(levelTime * 1/5)+1;
		int fog4Start = levelTime * 1/5;
		int fog4End = 	(levelTime - levelTime) +1;

		print (myTimer.GetSecondsRemaining ());

		if (myTimer.GetSecondsRemaining () < fog1Start && myTimer.GetSecondsRemaining () > fog1End)
			RenderSettings.fogDensity = 0.025f;
		else if(myTimer.GetSecondsRemaining() < fog2Start && myTimer.GetSecondsRemaining() > fog2End)
			RenderSettings.fogDensity = 0.050f;
		else if(myTimer.GetSecondsRemaining() < fog3Start && myTimer.GetSecondsRemaining() > fog3End)
			RenderSettings.fogDensity = 0.075f;
		else if(myTimer.GetSecondsRemaining() < fog4Start && myTimer.GetSecondsRemaining() > fog4End)
			RenderSettings.fogDensity = 0.1f;

		if (myTimer.GetSecondsRemaining () < 10)
			Time.timeScale = 0.5f; 
		else 
			Time.timeScale = 1;


		if(myTimer.GetSecondsRemaining() < 1)
		{
			Application.LoadLevel (gameOverLoad);
		}
	}

}//end of class
