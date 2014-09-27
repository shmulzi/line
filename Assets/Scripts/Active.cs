using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Active : MonoBehaviour {

	private GameObject _lineObj;
	private LineRenderer _line;
	private Vector3 _p0, _p1;
	private string _lastHit = "No hits registered yet";
	private bool _allContactsHit = false;
	private RaycastHit[] _hits;
	
	public float fingerFrame = 0.2f;

	void Start () {
		_lineObj = GameObject.FindGameObjectWithTag("Line");
		_line = _lineObj.GetComponent<LineRenderer>();
		fingerFrame *= Screen.width;
	}

	void Update () {
		
		if(Input.touches.Length > 1){
			RaycastHit hit;
			RaycastHit[] hits;
			_p0 = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
			_p1 = Camera.main.ScreenToWorldPoint(Input.touches[1].position);
			_line.SetPosition(0, _p0);
			_line.SetPosition(1, _p1);
			if(Physics.Linecast(_p0,_p1,out hit)){
				_lastHit = hit.transform.name;
			}
			_hits = Physics.RaycastAll(_p0,(_p1-_p0),Vector3.Distance(_p0,_p1));
//			if(hits.Length > 0){
//				string hitString = "";
//				foreach(RaycastHit hiti in hits){
//					hitString += hiti.transform.name + ", ";
//				}
//				if(hits.Length == 2 && ((hits[0].transform.tag == "Contact A" && hits[1].transform.tag == "Contact B") ||
//				                        (hits[0].transform.tag == "Contact B" && hits[1].transform.tag == "Contact A"))){
//					_allContactsHit = true;
//				} else {
//					_allContactsHit = false;
//				}
//				Debug.Log(hitString);
//			}
//			
//		} else {
//			_line.SetPosition(0, new Vector2(-999f,-999f));
//			_line.SetPosition(1, new Vector2(-999f,-999f));
//		}
		
		
		}
	}
	
	public Vector3 getTouch(int i){
		if(i == 0)
			return _p0;
		if(i == 1)
			return _p1;
		return Vector3.zero;
	}
	
	public string getLineHit(){
		return _lastHit;
	}
	
	public bool getAllContactPointsHit(){
		return _allContactsHit;
	}
	
	public void setAllContactPointsHit(bool b){
		_allContactsHit = b;
	}

	public RaycastHit[] getHits(){
		return _hits;
	}
}
