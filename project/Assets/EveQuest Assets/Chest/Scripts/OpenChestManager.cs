using UnityEngine;
using System.Collections;

public class OpenChestManager : MonoBehaviour {
	
	public Camera cam;
	public GameObject chestCloseGO;
	public GameObject chestOpenGO;
	public GameObject finTextGO;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnCodeFund() {
		
		GameObject chest = GameObject.Instantiate( chestOpenGO ) as GameObject;
		chest.transform.position = Vector3.up * (-2.292585f);
		chest.transform.eulerAngles = Vector3.up * 270;
		
		chest.transform.parent = chestCloseGO.transform.parent;
		Destroy( chestCloseGO );
		
		cam.animation.Play();
		
		StartCoroutine( ShowFinText() );
		
	}
	
	private IEnumerator ShowFinText() {
		
		yield return new WaitForSeconds( 5.0f );
		finTextGO.active = true;
		
	}
	
}
