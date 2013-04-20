using UnityEngine;
using System.Collections;

public class BoatMotion : MonoBehaviour {
	
	public float maxAngularVelocity = 45f;
	public float windForceScale = 100f;
	public GameObject blower;
	public ParticleEmitter trainee;
	public Transform explosion;

	// Use this for initialization
	void Start () {
		trainee.emit = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
    	if( Input.GetMouseButton( 0 ) ) {
			
			ComputeMotion();
		
		}
	
	}
	
	void ComputeMotion () {
		
		if( !trainee.emit )
			trainee.emit = true;
		
		float K = 0.5f;
		float dAngle = blower.transform.eulerAngles.y - transform.eulerAngles.y;
		dAngle = dAngle < 180f ? dAngle : dAngle - 360f;
		//Debug.Log( "angle: " + dAngle );
		transform.eulerAngles += dAngle * K * Vector3.up * Time.deltaTime;
		
		Vector3 windForce = Vector3.Normalize(transform.position - blower.transform.position) * windForceScale;
		windForce = new Vector3( windForce.x, 0, windForce.z );
		Vector3 force = Vector3.Project( windForce, transform.forward );
		rigidbody.AddForce( force );
		
	}
	
	void OnCollisionEnter(Collision collision) {
		
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        Instantiate(explosion, pos, rot);
		
		rigidbody.isKinematic = true;
		trainee.emit = false;
		animation.Play();
        //Destroy(gameObject);
		
    }
	
}
