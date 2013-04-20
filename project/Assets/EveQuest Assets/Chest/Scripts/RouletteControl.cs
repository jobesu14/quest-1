using UnityEngine;
using System.Collections;

public class RouletteControl : MonoBehaviour {
	
	public GameObject[] serruresCol;
	public GameObject[] roulettes;
	
	private int mMoveSerrureNo = -1;
	
	// Use this for initialization
	void Start () {
	
	}
	
	public void OnFingerDown ( FingerEvent eventData ) {
		
		if( eventData.Hit.collider == null )
			return;
		
		mMoveSerrureNo = -1;
		
		string tag = eventData.Hit.collider.gameObject.tag;
		if( string.IsNullOrEmpty( tag ) )
			return;
		
		int i = 0;
		foreach( GameObject serrure in serruresCol ) {
			if( serrure.tag == tag ) {
				mMoveSerrureNo = i;
				break;
			}
			i++;
		}
		
	}
	
	public void OnSwipe ( SwipeGesture swipeData ) {
		
		if( mMoveSerrureNo < 0 )
			return;
		
		if( swipeData.Direction == FingerGestures.SwipeDirection.Up ) {
			
			Debug.Log( "Up: "+swipeData.Move+" ; "+swipeData.Velocity );
			roulettes[mMoveSerrureNo].transform.Rotate( Vector3.right * 36f );
			
		}
		else if( swipeData.Direction == FingerGestures.SwipeDirection.Down ) {
			
			Debug.Log( "Down: "+swipeData.Move+" ; "+swipeData.Velocity );
			roulettes[mMoveSerrureNo].transform.Rotate( -Vector3.right * 36f );
			
		}
		
	}
}
