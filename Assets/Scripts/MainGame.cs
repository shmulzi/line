using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {

	public float timeToKillinSeconds = 10f;
	
	private player _playerData;
	private Sliders obs;
	
	// Use this for initialization
	void Start () {
		_playerData = Camera.main.GetComponent<player>();
		GameObject obsObj = GameObject.FindGameObjectWithTag("Obstacle");
		obs = obsObj.GetComponent<Sliders>();
	}
	
	// Update is called once per frame
	void Update () {
		if(_playerData.getAllContactPointsHit()){
			timeToKillinSeconds -= 0.1f;
		}
		
		if(timeToKillinSeconds < 0f){
			obs.die();
			timeToKillinSeconds = 10f;
			_playerData.setAllContactPointsHit(false);
		}
		
		if(!obs.isAlive()){
			obs.spawn();
		}
	}
}
