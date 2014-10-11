using UnityEngine;
using System.Collections;

public class FingerMarker : MonoBehaviour {

	private Active _active;
	private GameObject[] touchMarkers;
	// Use this for initialization
	void Start () {
		_active = Camera.main.GetComponent<Active>();
		touchMarkers = GameObject.FindGameObjectsWithTag("Finger Marker");
	}
	
	// Update is called once per frame
	void Update () {
		if(touchMarkers.Length == 2){
			touchMarkers[0].transform.position = new Vector3(_active.getTouch(0).x, _active.getTouch(0).y, 0);
			touchMarkers[1].transform.position = new Vector3(_active.getTouch(1).x, _active.getTouch(1).y, 0);
		}
	}
}
