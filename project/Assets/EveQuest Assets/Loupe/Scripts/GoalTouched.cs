using UnityEngine;
using System.Collections;

public class GoalTouched : MonoBehaviour {

	void OnTriggerEnter( Collider other ) {
		
		PlayerPrefs.SetInt( "show_chest_items", 1 );  
		Application.LoadLevel( "Chest" );
		
	}
	
}
