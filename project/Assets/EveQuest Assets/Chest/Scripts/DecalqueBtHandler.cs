using UnityEngine;
using System.Collections;

public class DecalqueBtHandler : MonoBehaviour {
	
	public GameObject calqueText;
	
	void Start () {
		
		calqueText.SetActiveRecursively( false );
	
	}
	
	// Update is called once per frame
	void OnClick () {
		
		PlayerPrefs.SetInt( "show_calque_items", 1 );
		PlayerPrefs.SetInt( "hide_decalque_bt", 1 );
		
		gameObject.SetActiveRecursively( false );
		calqueText.SetActiveRecursively( true );
		
	}
	
	/*IEnumerator HideCalqueText () {
		yield return new WaitForSeconds( 5.0f );
		calqueText.GetComponent<TweenAlpha>();
	}*/
	
}
