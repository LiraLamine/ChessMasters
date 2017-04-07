using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickRaycaster : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if ( Input.GetMouseButtonDown (0)){ 
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			if ( Physics.Raycast (ray,out hit,100.0f)) {
				StartCoroutine(MoveMe(hit.transform));
				Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
			}
		}
	}

	void MoveMe(Transform objTr) {} //Temporary function that will call for movement
}
