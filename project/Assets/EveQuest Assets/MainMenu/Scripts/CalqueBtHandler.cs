using UnityEngine;
using System.Collections;

public class CalqueBtHandler : MonoBehaviour {
	
	public GameObject itemsPanel;
	public GameObject loadingPanel;
	
	void OnClick() {
		Debug.Log("Calque bt pressed");
		
		Destroy( itemsPanel );
		loadingPanel.SetActiveRecursively( true );
		
		PlayerPrefs.SetInt( "show_mask", 1);
		Application.LoadLevel("Loupe");
	}
	
}
