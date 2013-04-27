using UnityEngine;
using System.Collections;

public class NextStoryBtHandler : MonoBehaviour {
	
	
	public GameObject[] storyLabels;
	public Camera camStory;
	public Camera camChest;
	public float fadeDuration = 2.0f;
	
	public GameObject background;
	
	private int mStoryNo = 0;
	
	// Use this for initialization
	void Start () {
		
		if(  PlayerPrefs.GetInt(PrefsKeys.LANDING_STORY_KEY, 0 ) != 0 ) {
			
			camChest.gameObject.active = false;
			
			foreach( GameObject lbl in storyLabels )
				lbl.GetComponent<UILabel>().color = new Color( 1.0f, 1.0f, 1.0f, 0.0f );
			
			mStoryNo = 0;
			ShowLabel( mStoryNo );
			
		}
		else {
			
			camStory.gameObject.active = false;
			camChest.gameObject.active = true;
			//Destroy( camStory.gameObject.transform.parent.gameObject );
			
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
		
		if( no > 0 ) { // hide current.
			TweenAlpha taOut = storyLabels[ no-1 ].GetComponent<TweenAlpha>();
			if( taOut == null || !taOut.enabled )
				taOut = storyLabels[ no-1 ].AddComponent<TweenAlpha>();
			taOut.from = storyLabels[ no-1 ].GetComponent<UILabel>().color.a;
			taOut.to = 0.0f;
			taOut.delay = 0.0f;
			taOut.duration = fadeDuration / 2.0f;
		}
		
		// show next.
		TweenAlpha taIn = storyLabels[ no ].AddComponent<TweenAlpha>();
		taIn.from = storyLabels[ no ].GetComponent<UILabel>().color.a;
		taIn.to = 1.0f;
		taIn.delay = fadeDuration / 2.0f;
		taIn.duration = fadeDuration / 2.0f;
		
	}
	
	void FadeOutStoryPanel() {
		
		PlayerPrefs.SetInt( PrefsKeys.LANDING_STORY_KEY, 0 );
		
		gameObject.SetActiveRecursively( false );
		DoFadeOut( background, fadeDuration );
		DoFadeOut( storyLabels[ storyLabels.Length-1 ], fadeDuration );
		camChest.gameObject.active = true;
		
	}
	
	void DoFadeOut( GameObject go, float duration ) {
		
		TweenAlpha ta = go.AddComponent<TweenAlpha>();
		ta.from = 1.0f;
		ta.to = 0.0f;
		ta.duration = duration;
		
	}
	
}
