using UnityEngine;
using System.Collections;

public class ShowDecalqueBt : MonoBehaviour {
	
	public GameObject decalqueBt;
	
	void Start () {
		
		decalqueBt.SetActiveRecursively( false );
	
	}
	
	void OnZoom () {
		
		if( PlayerPrefs.GetInt( PrefsKeys.HIDE_DECALQUE_BT_KEY, 0 ) <= 0 ) {
			decalqueBt.SetActiveRecursively( true );
		}
	}
	
	void OnDezoom () {
		
		decalqueBt.SetActiveRecursively( false );
		
	}
	
}
