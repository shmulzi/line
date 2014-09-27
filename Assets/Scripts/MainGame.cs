using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {

	public float timeToKillinSeconds = 10f;
	
	private player _playerData;
	private Sliders obs;
	private SliderLauncher sl;
	
	// Use this for initialization
	void Start () {
		_playerData = Camera.main.GetComponent<player>();
		GameObject obsObj = GameObject.FindGameObjectWithTag("Slider");
		obs = obsObj.GetComponent<Sliders>();
		GameObject scriptHolder = GameObject.FindGameObjectWithTag("Script Holder");
		sl = scriptHolder.GetComponent<SliderLauncher>();
	}

	void Update () {
		if(_playerData.getAllContactPointsHit())
			timeToKillinSeconds -= 0.1f;
		if(sl.allSlidersDead())
			sl.launchRandomSlider();
		
		
		if(timeToKillinSeconds < 0f){
			obs.die();
			timeToKillinSeconds = 10f;
			_playerData.setAllContactPointsHit(false);
		}
		
		if(!obs.isAlive()){
			sl.launchRandomSlider();
		}
	}
}
