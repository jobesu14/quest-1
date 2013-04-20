using UnityEngine;
using System.Collections;

public class CalqueBtHandler : MonoBehaviour {

	void OnClick() {
		Debug.Log("Calque bt pressed");
		
		PlayerPrefs.SetInt( "show_mask", 1);
		Application.LoadLevel("Loupe");
	}
	
}
