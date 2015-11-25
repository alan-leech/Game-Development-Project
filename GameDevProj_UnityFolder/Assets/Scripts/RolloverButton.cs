using UnityEngine;
using System.Collections;

	/** 
  	* standard behavior class for rollover buttons that will load a new scene when clicked
    */
 	public class RolloverButton : MonoBehaviour {

	/** integer number of level to load when button clicked */
	public int levelToLoadOnClick = 0;
 	/** reference to button image when mouse not over it */
 	public Texture2D normalImage;
	/** reference to mouse over button image */
 	public Texture2D rolloverImage;

	public AudioClip hover;

	private bool played = false;

	 /** when mouse over image, change image to rollover image */
 	private void OnMouseOver(){
 		GetComponent<GUITexture>().texture = rolloverImage;

		if (!played)
		{
			GetComponent<AudioSource>().PlayOneShot (hover);
			played = true;
		}
 	}
 
   /** when mouse no longer over image, change back to normal image */
  	private void OnMouseExit(){
       GetComponent<GUITexture>().texture = normalImage;
		played = false;
  	}
   
 	/** when mouse button clicked, make application load scene for given integer */
  	private void OnMouseUp(){
    	 Application.LoadLevel( levelToLoadOnClick );
   	}

 }//end of class
