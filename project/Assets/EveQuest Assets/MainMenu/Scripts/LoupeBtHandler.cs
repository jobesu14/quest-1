using UnityEngine;
using System.Collections;

public class LoupeBtHandler : MonoBehaviour {
	
	public GameObject itemsPanel;
	public GameObject loadingPanel;

	void OnClick() {
		Debug.Log("Loupe bt pressed");
		
		Destroy( itemsPanel );
		loadingPanel.SetActiveRecursively( true );
		
		PlayerPrefs.SetInt( "show_mask", 0);
		Application.LoadLevel("Loupe");
	}
}
