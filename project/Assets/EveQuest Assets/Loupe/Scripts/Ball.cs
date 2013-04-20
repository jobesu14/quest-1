using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	public GameObject splashGO;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter ( Collider col ) {
		
		GameObject splash = Instantiate( splashGO ) as GameObject;
		splash.transform.parent = transform.parent;
		splash.transform.localPosition = transform.localPosition;
		splash.transform.localScale = splashGO.transform.localScale;
		
		Destroy( gameObject );
		
	}
}
