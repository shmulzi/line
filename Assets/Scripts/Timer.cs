using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
		
	private float _stopWatchTime = 0f;
	private float _stopWatchRelativeTime = 0f;
	private float _stopWatchPrev = 0f;
	private float _startTime = 0f;
	private float _currentTime = 0f;
	
	private bool _stopWatchActivated = false;

	void Awake() {
		_startTime = Time.realtimeSinceStartup;
	}

	void Update () {
		_currentTime = Time.realtimeSinceStartup - _startTime;
		if(_stopWatchActivated)
			_stopWatchTime = _stopWatchPrev + Time.realtimeSinceStartup - _stopWatchRelativeTime;
//		Debug.Log(transform.parent.transform.name + ": " + _stopWatchTime.ToString() + ", " + _stopWatchRelativeTime.ToString());

	}

	public float getTime(){
		return _currentTime;
	}

	public void resetTime(){
		_currentTime = _startTime;
	}

	public void startStopWatch(){
		if(!_stopWatchActivated){
			_stopWatchRelativeTime = Time.realtimeSinceStartup;
			_stopWatchActivated = true;
		}
	}
	
	public void stopStopWatch(){
		if(_stopWatchActivated){
			_stopWatchPrev = _stopWatchTime;
			_stopWatchActivated = false;
		}
	}

	public void resetStopWatch(){
		_stopWatchRelativeTime = 0f;
		_stopWatchTime = 0f;
		_stopWatchPrev = 0f;
	}

	public float getStopWatchTime(){
		return _stopWatchTime;
	}
}
