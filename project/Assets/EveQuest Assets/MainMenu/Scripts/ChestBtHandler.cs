using UnityEngine;
using System.Collections;

public class ChestBtHandler : MonoBehaviour {
	
	void Start() {
		
		if( PlayerPrefs.GetInt( PrefsKeys.SHOW_CHEST_ITEM_KEY, 0 ) == 0 )
			gameObject.SetActiveRecursively( false );
		
	}
	
	void OnClick() {
		
		Application.LoadLevel("Chest");
	
	}
	
}
