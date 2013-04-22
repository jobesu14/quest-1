using UnityEngine;
using System.Collections;

public class MaskHandler : MonoBehaviour {
	
	public GameObject maskImageTarget;
	public GameObject mask;
	
	private bool mWantMaskOn = false;
	private bool mImageTargetOn = false;
	
	// Use this for initialization
	void Start () {
		
		mWantMaskOn = true;
		mask.SetActiveRecursively( mWantMaskOn );
		
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
