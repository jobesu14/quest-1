using UnityEngine;
using System.Collections;

public class CalqueBtHandler : MonoBehaviour {
	
	public GameObject itemsPanel;
	public GameObject loadingPanel;
	
	void Start() {
		
		if( PlayerPrefs.GetInt( PrefsKeys.SHOW_CALQUE_ITEM_KEY, 0 ) == 0 )
			gameObject.SetActiveRecursively( false );
		
	}
	
	void OnClick() {
		
		Destroy( itemsPanel );
		loadingPanel.SetActiveRecursively( true );
		
		Application.LoadLevel("Calque");
		
	}
	
}
