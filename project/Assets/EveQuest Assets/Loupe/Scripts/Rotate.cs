using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	
	public float speed = 360.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		gameObject.transform.localEulerAngles += Vector3.up * speed * Time.deltaTime;

	}
}
