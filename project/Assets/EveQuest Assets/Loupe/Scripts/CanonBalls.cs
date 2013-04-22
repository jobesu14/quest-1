using UnityEngine;
using System.Collections;

public class CanonBalls : MonoBehaviour {
	
	public GameObject ballGO;
	public GameObject smokeGO;
	public GameObject splashGO;
	public Vector2 dtBetweenBalls;
	public Vector2 rangeX;
	public Vector2 rangeY;
	public Vector2 rangeZ;
	
	private bool mFireBallEnable = false;
	
	void OnTrackingFound () {
		
		mFireBallEnable = true;
		FireBall ();
	
	}
	
	void OnTrackingLost () {
		
		mFireBallEnable = false;
		
	}
	
	void FireBall () {
		
		if( mFireBallEnable ) {
			float delay = Random.Range( dtBetweenBalls.x, dtBetweenBalls.y );
			StartCoroutine( FireBallCoroutine ( delay ) );
		}
		
	}
	
	IEnumerator FireBallCoroutine ( float delay ) {
		
		yield return new WaitForSeconds( delay );
		GameObject ball = Instantiate ( ballGO ) as GameObject;
		ball.transform.parent = transform.parent;
		ball.transform.localPosition = transform.localPosition;
		ball.transform.localScale = ballGO.transform.localScale;
		ball.transform.localRotation = transform.transform.localRotation;
		ball.GetComponent<Ball>().splashGO = splashGO;
		
		float xForce = Random.Range( rangeX.x, rangeX.y ); 
		float yForce = Random.Range( rangeY.x, rangeY.y ); 
		float zForce = Random.Range( rangeZ.x, rangeZ.y ); 
		ball.rigidbody.AddRelativeForce( new Vector3 (xForce, yForce, zForce) );
			
		GameObject smoke = Instantiate ( smokeGO ) as GameObject;
		smoke.transform.parent = transform.parent;
		smoke.transform.localPosition = transform.localPosition;
		smoke.transform.localScale = smokeGO.transform.localScale;
		Destroy( smoke, 2f );
		
		FireBall ();
		
	}
	
}
