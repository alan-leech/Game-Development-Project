using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

    public void loadScene(int index)
    {
        Application.LoadLevel(index);
    }

   /* public void NextLevelButton(string levelName)
    {
        Application.LoadLevel(levelName);
    }*/
}
