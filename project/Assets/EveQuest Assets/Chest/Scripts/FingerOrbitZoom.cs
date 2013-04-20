using UnityEngine;
using System.Collections;

public class FingerOrbitZoom : MonoBehaviour {
	
	public Transform target;
	public float distance = 10.0f;
	
	public float xSpeed = 0.3f;
	public float ySpeed = 0.3f;
	
	public float yMinLimit = -20;
	public float yMaxLimit = 80;
	
	private float mXDown = 0.0f;
	private float mYDown = 0.0f;
	private float mXStartRot = 0.0f;
	private float mYStartRot = 0.0f;
	
	private bool mIsScriptActive = true;
	
	void Start () {
		
		Quaternion rotation = Quaternion.Euler(0, 0, 0);
		Vector3 position = rotation * (-distance * Vector3.forward) + target.position;
		transform.rotation = rotation;
		transform.position = position;
		
		// Make the rigid body not change rotation
	   	if (rigidbody)
			rigidbody.freezeRotation = true;
	}
	
	void LateUpdate () {
		if (target && mIsScriptActive) {
			if ( Input.GetMouseButtonDown(0) ) {
			    var angles = transform.eulerAngles;
			    mXStartRot = angles.y;
			    mYStartRot = angles.x;
				mXDown = Input.mousePosition.x; //Input.GetAxis("Mouse X");
				mYDown = Input.mousePosition.y; //Input.GetAxis("Mouse Y");
				Debug.Log( "Down at " + mXDown + " ; " + mYDown );
			}
			else if ( Input.GetMouseButton(0) ) {
		        float x = mXStartRot + (Input.mousePosition.x - mXDown) * xSpeed; //Input.GetAxis("Mouse X") * xSpeed * 0.02f;
		        float y = mYStartRot - (Input.mousePosition.y - mYDown) * ySpeed; //Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
		 		
		 		y = ClampAngle(y, yMinLimit, yMaxLimit);
		 		       
		        Quaternion rotation = Quaternion.Euler(y, x, 0);
		        Vector3 position = rotation * (-distance * Vector3.forward) + target.position;
		        
		        transform.rotation = rotation;
		        transform.position = position;
		    }
		}
	}
	
	public void ToggleOrbitActivation () {
		mIsScriptActive = !mIsScriptActive;
	}
	
	static float ClampAngle ( float angle, float min, float max ) {
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}
	
}