using UnityEngine;
using System.Collections;

public class HelpHandler : MonoBehaviour {
	
	public GameObject helpPanel;
	
	void OnClick () {
		
		helpPanel.SetActiveRecursively( !helpPanel.active );	
		
	}
}
