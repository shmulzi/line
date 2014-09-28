using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Active : MonoBehaviour {

	private GameObject _lineObj;
	private LineRenderer _line;
	private Vector3 _p0, _p1;
	private RaycastHit[] _hits;

	void Start () {
		_lineObj = GameObject.FindGameObjectWithTag("Line");
		_line = _lineObj.GetComponent<LineRenderer>();
	}

	void Update () {
		if(Input.touches.Length > 1){
			RaycastHit hit;
			_p0 = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
			_p1 = Camera.main.ScreenToWorldPoint(Input.touches[1].position);
			_line.SetPosition(0, _p0);
			_line.SetPosition(1, _p1);
			_hits = Physics.RaycastAll(_p0,(_p1-_p0),Vector3.Distance(_p0,_p1));
		} else {
			_line.SetPosition(0, new Vector2(-999f,-999f));
			_line.SetPosition(1, new Vector2(-999f,-999f));
		}
	}
	
	public Vector3 getTouch(int i){
		if(i == 0)
			return _p0;
		if(i == 1)
			return _p1;
		return Vector3.zero;
	}

	public RaycastHit[] getHits(){
		return _hits;
	}

	public void resetHits(){
		_hits = null;
	}
}
