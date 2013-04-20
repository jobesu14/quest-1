using UnityEngine;
using System.Collections;

public class ComeToMe : MonoBehaviour {
	
	public Transform objToMove;
	public Transform finalTransform;
	public float duration;
	
	private bool mMove = false;
	private bool mZoomed = false;
	private float mStartTime;
	private Vector3 mStartPos;
	private Quaternion mStartRot;
	
	// Update is called once per frame
	void Update () {
		
		if( mMove ) {
			
			float cursor = (Time.time - mStartTime ) / duration;
			
			Vector3 v;
			Quaternion r;
			if( mZoomed ) {
				v = Vector3.Lerp( mStartPos, finalTransform.position, cursor );
				r = Quaternion.Lerp( mStartRot, finalTransform.rotation, cursor );
			}
			else {
				v = Vector3.Lerp( finalTransform.position, mStartPos, cursor );
				r = Quaternion.Lerp( finalTransform.rotation, mStartRot, cursor );
			}
			
			objToMove.position = v;
			objToMove.rotation = r;
			
			if( cursor >= 1.0f ) {
				mMove = false;
			}
			
		}
		
	}
	
	void OnClick () {
		
		if( mMove ) // disable action when animating.
			return;
		
		if( !mZoomed ) { // save the sarting point.
			mStartPos = objToMove.position;
			mStartRot = objToMove.rotation;
			
			SendMessage ( "OnZoom", SendMessageOptions.DontRequireReceiver );
		}
		else {
			SendMessage ( "OnDezoom", SendMessageOptions.DontRequireReceiver );
		}
		
		mMove = true;
		mStartTime = Time.time;
		mZoomed = !mZoomed;
	
	}
}
