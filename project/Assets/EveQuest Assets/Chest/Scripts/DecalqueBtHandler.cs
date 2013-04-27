using UnityEngine;
using System.Collections;

public class DecalqueBtHandler : MonoBehaviour {
	
	public GameObject calqueText;
	
	void Start () {
		
		calqueText.SetActiveRecursively( false );
	
	}
	
	// Update is called once per frame
	void OnClick () {
		
		PlayerPrefs.SetInt( PrefsKeys.SHOW_CALQUE_ITEM_KEY, 1 );
		PlayerPrefs.SetInt( PrefsKeys.HIDE_DECALQUE_BT_KEY, 1 );
		
		gameObject.SetActiveRecursively( false );
		calqueText.SetActiveRecursively( true );
		
	}
	
	/*IEnumerator HideCalqueText () {
		yield return new WaitForSeconds( 5.0f );
		calqueText.GetComponent<TweenAlpha>();
	}*/
	
}
