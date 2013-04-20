using UnityEngine;
using System.Collections;

public class LoupeBtHandler : MonoBehaviour {

	void OnClick() {
		Debug.Log("Loupe bt pressed");
		
		PlayerPrefs.SetInt( "show_mask", 0);
		Application.LoadLevel("Loupe");
	}
}
