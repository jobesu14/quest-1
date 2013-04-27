using UnityEngine;
using System.Collections;

public class GoalTouched : MonoBehaviour {
	
	public Camera camFadeOut;
	public Camera camFadeIn;
	public Mesh shape;
	public float fadeTime = 4.0f;
	
	public Camera camGUI;

	void OnTriggerEnter( Collider other ) {
		
		camGUI.enabled = false;
		
		StartCoroutine( ScreenWipe.use.ShapeWipe( camFadeOut, camFadeIn, fadeTime,
						ScreenWipe.ZoomType.Shrink, shape, 0, null ) );
		
		StartCoroutine( LoadChestScene( fadeTime ) );
		
	}
	
	IEnumerator LoadChestScene( float delay ) {
		
		yield return new WaitForSeconds( delay );
		
		PlayerPrefs.SetInt( PrefsKeys.LANDING_STORY_KEY, 1 );
		PlayerPrefs.SetInt( PrefsKeys.SHOW_CHEST_ITEM_KEY, 1 );  
		Application.LoadLevel( "Chest" );
		
	}
	
}
