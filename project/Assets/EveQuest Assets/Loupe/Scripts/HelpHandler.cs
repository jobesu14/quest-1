using UnityEngine;
using System.Collections;

public class HelpHandler : MonoBehaviour {
	
	public GameObject helpPanel;
	
	void Start () {
		
		EnableButton( false );
		
		//StartCoroutine( tofggle() );
		
	}
	
	IEnumerator tofggle() {
		yield return new WaitForSeconds(5);
		EnableButton( true );
	}
	
	void OnClick () {
		
		helpPanel.SetActiveRecursively( !helpPanel.active );	
		
	}
	
	void OnTrackingFound () {
		
		EnableButton( true );
		
	}
	
	void OnTrackingLost () {
		
		EnableButton( false );
		
		if( helpPanel.active )
			helpPanel.SetActiveRecursively( false );
		
	}
	
	private void EnableButton( bool enable ) {
		
		gameObject.SetActiveRecursively( enable );
		gameObject.active = true;
		collider.enabled = enable;
		
	}
	
}
