using UnityEngine;
using System.Collections;

public class ShowDecalqueBt : MonoBehaviour {
	
	public GameObject decalqueBt;
	
	void Start () {
		
		decalqueBt.SetActiveRecursively( false );
	
	}
	
	void OnZoom () {
		
		if( PlayerPrefs.GetInt( "hide_decalque_bt", 0 ) <= 0 ) {
			decalqueBt.SetActiveRecursively( true );
		}
	}
	
	void OnDezoom () {
		
		decalqueBt.SetActiveRecursively( false );
		
	}
	
}
