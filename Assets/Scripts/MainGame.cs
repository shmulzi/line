using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGame : MonoBehaviour {

	public float timeToKillinSeconds = 10f;


	private Active _active;
	private Sliders _obs;
	private SliderLauncher _sl;

	// Use this for initialization
	void Start () {
		_active = Camera.main.GetComponent<Active>();
		GameObject _obsObj = GameObject.FindGameObjectWithTag("Slider");
		_obs = _obsObj.GetComponent<Sliders>();
		GameObject scriptHolder = GameObject.FindGameObjectWithTag("Script Holder");
		_sl = scriptHolder.GetComponent<SliderLauncher>();
	}

	void Update () {
		if(_active.getAllContactPointsHit())
			timeToKillinSeconds -= 0.1f;
		if(_sl.allSlidersDead())
			_sl.launchRandomSlider();
		
		
		if(timeToKillinSeconds < 0f){
			_obs.die();
			timeToKillinSeconds = 10f;
			_active.setAllContactPointsHit(false);
		}
		
		if(!_obs.isAlive()){
			_sl.launchRandomSlider();
		}
	}
}
