using UnityEngine;
using System.Collections;

public class GoalTouched : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		
		Application.LoadLevel( "Chest" );
		
	}
	
}
