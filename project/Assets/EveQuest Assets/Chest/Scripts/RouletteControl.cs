using UnityEngine;
using System.Collections;

public class RouletteControl : MonoBehaviour {
	
	public GameObject[] serruresCol;
	public GameObject[] roulettes;
	public int[] correctCode;
	
	public GameObject unlockedTarget;
	public string unlockFctName = "OnCodeFund";
	
	private int mMoveSerrureNo = -1;
	
	private int[] mCode;
	private Vector3[] mInitEuler;
	
	// Use this for initialization
	void Awake () {
		
		mCode = new int[ roulettes.Length ];
		mInitEuler = new Vector3[ roulettes.Length ];
		
		for( int no=0; no<roulettes.Length; no++ ) {
			serruresCol[no].active = false;
			mInitEuler[no] = roulettes[ no ].transform.eulerAngles;
			mCode[no] = PlayerPrefs.GetInt("saved_code_"+no, 0);
			setRouletteCode( no, mCode[no] );
		}
		
	}
	
	public void ToggleColliderActivation () { // Activate collider when we are zoomed on lock system.
		
		foreach( GameObject col in serruresCol ) {
			col.active = !col.active;	
		}
		
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
			
			mCode[mMoveSerrureNo] = ( ++mCode[mMoveSerrureNo] ) % 10;
			setRouletteCode( mMoveSerrureNo, mCode[mMoveSerrureNo] );
			
		}
		else if( swipeData.Direction == FingerGestures.SwipeDirection.Down ) {
			
			mCode[mMoveSerrureNo] = ( --mCode[mMoveSerrureNo] ) % 10;
			mCode[mMoveSerrureNo] = mCode[mMoveSerrureNo] < 0 ? mCode[mMoveSerrureNo]+10 : mCode[mMoveSerrureNo];
			setRouletteCode( mMoveSerrureNo, mCode[mMoveSerrureNo] );
		}
		
		if( controlCode() ) { // Correct code fund.
			
			Debug.Log( "Code fund." );
			if( unlockedTarget != null )
				unlockedTarget.SendMessage( unlockFctName, SendMessageOptions.DontRequireReceiver );
		}
		
	}
	
	private void setRouletteCode( int rouletteNo, int number ) {
		PlayerPrefs.SetInt( "saved_code_"+rouletteNo, number );
		roulettes[ rouletteNo ].transform.eulerAngles = mInitEuler[ rouletteNo ] + Vector3.right * 36f * number;
	}
	
	private bool controlCode() {
		for( int i=0; i<correctCode.Length; i++ )
			if( correctCode[i] != mCode[i] )
				return false;
		return true;
	}
	
}
