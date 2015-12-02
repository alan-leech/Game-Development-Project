using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	/**
	 * Program to control all platform movment, in each axis
	 * 
	*/
	public float yMovementPerSecond = 1f;
	public float minY = 0f;
	public float maxY = 10f;

	public float xMovementPerSecond = 1f;
	public float minX = 0f;
	public float maxX = 10f;

	public float zMovementPerSecond = 1f;
	public float minZ = 0f;
	public float maxZ = 10f;

	private bool movingUp = true;
	private bool movingBack = true;
	private bool movingLeft = true;

	/**
	 * Check the limits for the movement of the platform
	 * Check the tag of the platform to check which axis it will move on
	 * Call Method to move the platform on the corresponding axis
	 */
	void Update () {
		CheckLimits ();

		if (CompareTag("MovePlatformX")) {
			MovePlatformX();
		}

		if (CompareTag("MovePlatformY")) {
			MovePlatformY();
		}

		if (CompareTag("MovePlatformZ")) {
			MovePlatformZ();
		}
	}

	/**
	 * Move the platform between the Max and Min points set on the X Axis
	 */
	void MovePlatformX()
	{
		// dy is small amount to change Y position
		float dy = xMovementPerSecond;
		
		if(!movingLeft){
			dy = -xMovementPerSecond;
		}
		
		// reduce DY based on fraction of a second since last frame
		dy *= Time.deltaTime;
		
		// move platform by DY
		transform.Translate(dy,0,0);
	}//end of MovePlatformX

	/**
	 * Move the platform between the Max and Min points set on the Y Axis
	 */
	void MovePlatformY()
	{
			// dy is small amount to change Y position
			float dy = yMovementPerSecond;
			
			if(!movingUp){
				dy = -yMovementPerSecond;
			}
			
			// reduce DY based on fraction of a second since last frame
			dy *= Time.deltaTime;
			
			// move platfor by DY
			transform.Translate(0,dy,0);

	}//end of MovePlatformY

	/**
	 * Move the platform between the Max and Min points set on the Z Axis
	 */
	void MovePlatformZ()
	{
		// dy is small amount to change Y position
		float dy = zMovementPerSecond;
		
		if(!movingBack){
			dy = -zMovementPerSecond;
		}
		
		// reduce DY based on fraction of a second since last frame
		dy *= Time.deltaTime;
		
		// move platfor by DY
		transform.Translate(0,0,dy);

	}//end of MovePlatformZ

	/**
	 * Set limits on the movement of the platform.
	 * Toggle the motion of the platform when it reaches Max/Min Limit
	 */
	void CheckLimits()
	{
			float x = transform.position.x;
			float y = transform.position.y;
			float z = transform.position.z;
			
			if (CompareTag ("MovePlatformX")) {

				if (movingLeft && (x > maxX)) {
						movingLeft = false;
				} else if (x < minX) {
						movingLeft = true;
				}
			}
			else if (CompareTag ("MovePlatformY")) {
				
				if (movingUp && (y > maxY)) {
					movingUp = false;
				} else if (y < minY) {
					movingUp = true;
				}
			}
			else if (CompareTag ("MovePlatformZ")) {
				
				if (movingBack && (z > maxZ)) {
					movingBack = false;
				} else if (z < minZ) {
					movingBack = true;
				}
			}

	}//end of CheckLimits
		
}//end of class
