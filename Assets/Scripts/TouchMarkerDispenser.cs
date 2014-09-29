using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchMarkerDispenser : MonoBehaviour {

	public Vector3 markerPool;

	private List<TouchMarker> markerScripts = new List<TouchMarker>();

	// Use this for initialization
	void Start () {
		GameObject[] markers = GameObject.FindGameObjectsWithTag("Touch Marker");
		foreach(GameObject marker in markers){
			TouchMarker scr = marker.GetComponent<TouchMarker>();
			markerScripts.Add(scr);
		}
	}

	void Update () {
		//check if marker is alive and if not send to pool
		foreach(TouchMarker marker in markerScripts){
			if(!marker.isActivated()){
				marker.transform.parent.transform.position = markerPool;
			}
		}
	}

	public GameObject dispenseMarker(){
		foreach(TouchMarker marker in markerScripts){
			if(!marker.isActivated()){
				marker.activate();
				return marker.transform.gameObject;
			}
		}
		return new GameObject();
	}
}
