using UnityEngine;
using System.Collections;

public class LoupeBtHandler : MonoBehaviour {
	
	public GameObject itemsPanel;
	public GameObject loadingPanel;

	void OnClick() {
		
		Destroy( itemsPanel );
		loadingPanel.SetActiveRecursively( true );
		
		Application.LoadLevel("Loupe");
		
	}
}
