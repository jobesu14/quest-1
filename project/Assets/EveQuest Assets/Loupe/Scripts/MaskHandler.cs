using UnityEngine;
using System.Collections;

public class MaskHandler : MonoBehaviour {
	
	public GameObject maskImageTarget;
	public GameObject mask;
	
	private bool mWantMaskOn = false;
	private bool mImageTargetOn = false;
	
	// Use this for initialization
	void Start () {
		
		bool maskBtRequired = PlayerPrefs.GetInt( "show_mask_bt", 0) > 0;
		if(maskBtRequired) {
			
			mWantMaskOn = PlayerPrefs.GetInt( "show_mask", 0) > 0;
			mask.SetActiveRecursively( mWantMaskOn );
			maskImageTarget.SetActiveRecursively( true );
		
		}
		else {
		
			gameObject.SetActiveRecursively( false );
			//Destroy ( mask ); //.SetActiveRecursively( false );
			//Destroy ( maskImageTarget ); //.SetActiveRecursively( false );
		
		}
		
	}
	
	void OnClick() {
		
		if( !mImageTargetOn ) {
			
			mWantMaskOn = !mWantMaskOn;
			mask.SetActiveRecursively( mWantMaskOn );
			//maskImageTarget.SetActiveRecursively( activate );
		
		}
	
	}
	
	void OnTrackingFound () {
		
		Debug.Log(" FOUND ");
		mImageTargetOn = true;
		mask.SetActiveRecursively( false );
		
	}
	
	void OnTrackingLost () {
		
		Debug.Log(" LOST ");
		mImageTargetOn = false;
		mask.SetActiveRecursively( mWantMaskOn );
		
	}
}
