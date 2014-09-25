using UnityEngine;
using System.Collections;

public class DebugGUI : MonoBehaviour {

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
	
	}
	
	void OnGUI(){
		GUI.Label(new Rect(0,0,200,100),"F1: " + _playerData.getTouch(0).ToString());
		GUI.Label(new Rect(0,20,200,100),"F2: " + _playerData.getTouch(1).ToString());
		GUI.Label(new Rect(0,40,200,100),"All Points Hit: " + _playerData.getAllContactPointsHit());
		GUI.Label(new Rect(0,60,200,100),"Obstacle Alive?: " + obs.isAlive());
	}
}
