using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Active : MonoBehaviour {

	private bool _lineLock = false;
	private Timer _timer;
	private GameObject _lineObj;
	private LineRenderer _line;
	private Vector3 _p0, _p1;

	public static RaycastHit[] _hits;

	void Start () {
		_lineObj = GameObject.FindGameObjectWithTag("Line");
		_line = _lineObj.GetComponent<LineRenderer>();
		_timer = GetComponent<Timer>();
	}

	void Update () {
		if(Input.touches.Length > 1 && !Hitter.blocked && !_lineLock){
			RaycastHit hit;
			_p0 = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
			_p1 = Camera.main.ScreenToWorldPoint(Input.touches[1].position);
			_line.SetPosition(0, _p0);
			_line.SetPosition(1, _p1);
			_hits = Physics.RaycastAll(_p0,(_p1-_p0),Vector3.Distance(_p0,_p1));
		} else {
			_line.SetPosition(0, new Vector2(-999f,-999f));
			_line.SetPosition(1, new Vector2(-999f,-999f));
			_p0 = new Vector3(999,-999,0);
			_p1 = new Vector3(999,-999,0);

		}
		if(!_lineLock)
			lockDrawLine();
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

	public static void resetHits(){
		_hits = null;
	}

	private void lockDrawLine(){
		StartCoroutine(wait (1));
	}

	private IEnumerator wait(float seconds){
		if(Hitter.blocked){
			_lineLock = true;
			yield return new WaitForSeconds(seconds);
			_lineLock = false;
		}
	}
}
