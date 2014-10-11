using UnityEngine;
using System.Collections;

public class ActiveTester : MonoBehaviour {

	Active _active;

	// Use this for initialization
	void Start () {
		_active = Camera.main.GetComponent<Active>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		string s = "";
		RaycastHit[] hits = _active.getHits();
		if(hits != null){
			foreach(RaycastHit hit in hits){
				LineHitPoint lhp = hit.transform.gameObject.GetComponent<LineHitPoint>();
				if(lhp != null)
					s = s + lhp.getLHPIndex().ToString() + ": " + lhp.gameObject.GetInstanceID().ToString();
			}
		}
		GUI.Label(new Rect(0,0,100,30), s);
	}
}
