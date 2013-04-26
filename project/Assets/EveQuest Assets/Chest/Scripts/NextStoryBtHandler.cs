using UnityEngine;
using System.Collections;

public class NextStoryBtHandler : MonoBehaviour {
	
	
	public GameObject[] storyLabels;
	public GameObject[] objsToFadeOut;
	public float fadeDuration = 2.0f;
	
	private int mStoryNo = 0;
	
	// Use this for initialization
	void Start () {
		
		if(  PlayerPrefs.GetInt( "show_island_landing", 0 ) != 0 ) {
			mStoryNo = 0;
			ShowLabel( mStoryNo );
		}
		else {
			Destroy( transform.parent.parent.parent.parent.gameObject );
		}
		
	}
	
	void OnClick() {
		
		mStoryNo++;
		
		if( mStoryNo < storyLabels.Length )
			ShowLabel( mStoryNo );
		else
			FadeOutStoryPanel();
		
	}
	
	void ShowLabel( int no ) {
		
		foreach( GameObject lbl in storyLabels )
			lbl.active = false;
		
		storyLabels[ no ].active = true;
		
	}
	
	void FadeOutStoryPanel() {
		
		PlayerPrefs.SetInt( "show_island_landing", 0 );
		Destroy( transform.parent.parent.parent.parent.gameObject );
		
	}
	
}
