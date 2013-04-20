using UnityEngine;
using System.Collections;

public class ShowDecalqueBt : MonoBehaviour {
	
	public GameObject decalqueBt;
	
	void Start () {
		
		decalqueBt.SetActiveRecursively( false );
	
	}
	
	void OnZoom () {
		
		if( PlayerPrefs.GetInt( "show_mask_bt", 0 ) <= 0 ) {
			decalqueBt.SetActiveRecursively( true );
		}
	}
	
	void OnDezoom () {
		
		decalqueBt.SetActiveRecursively( false );
		
	}
	
}
