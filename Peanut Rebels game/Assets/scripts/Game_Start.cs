using UnityEngine;
using System.Collections;

public class Game_Start : MonoBehaviour {

	public void StartGame () {
        #pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel ("Game_Play");
        #pragma warning restore CS0618 // Type or member is obsolete
    }

    public void ResetHighScore () {
		PlayerPrefs.SetInt ("highScore",0);
	}
}
