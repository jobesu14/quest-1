using UnityEngine;
using System.Collections;

public class ChestBtHandler : MonoBehaviour {
	
	void Start() {
		
		if( PlayerPrefs.GetInt( "show_chest_items", 0 ) == 0 )
			gameObject.SetActiveRecursively( false );
		
	}
	
	void OnClick() {
		
		Application.LoadLevel("Chest");
	
	}
	
}
