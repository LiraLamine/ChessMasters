using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickRaycaster : MonoBehaviour {

	Board boardscript;
	// Update is called once per frame
	void Update () {
		if ( Input.GetMouseButtonDown (0)){ 
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			if ( Physics.Raycast (ray,out hit,100.0f)) {
				boardscript = hit.collider.gameObject.GetComponent<Board>();
				Debug.Log("You selected the " + hit.collider.gameObject.name); // ensure you picked right object
			}
		}
	}
}
