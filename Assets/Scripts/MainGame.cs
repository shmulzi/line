using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGame : MonoBehaviour {

	public float timeToKillinSeconds = 10f;


	private Active _active;
	private SliderLauncher _sl;

	void Start () {
		_active = Camera.main.GetComponent<Active>();
		GameObject scriptHolder = GameObject.FindGameObjectWithTag("Script Holder");
		_sl = scriptHolder.GetComponent<SliderLauncher>();
	}

	void Update () {
		if(_sl.allSlidersDead())
			_sl.launchRandomSlider();
	}
}
