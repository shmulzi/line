	using UnityEngine;
using System.Collections;

public class LineHitPointPuzzle : LineHitPoint {

	public float timeToColorSwitch = 1.0f;

	private int _numberOfColors;
	private ColorSwitcherLHPPuzzle _colorSwitcher;

	// Use this for initialization
	void Start () {
		_timer = GetComponent<Timer>();
		_colorSwitcher = GetComponent<ColorSwitcherLHPPuzzle>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isHit()){
			_timer.startStopWatch();
		} else {
			_timer.stopStopWatch();
		}
		if(_timer.getStopWatchTime() >= timeToColorSwitch){
			_colorSwitcher.switchToNextColor();
			_timer.stopStopWatch();
			_timer.resetStopWatch();
		}
	}
}
