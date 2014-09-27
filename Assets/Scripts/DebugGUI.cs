using UnityEngine;
using System.Collections;

public class DebugGUI : MonoBehaviour {

	private player _playerData;
	private Sliders obs;

	// Use this for initialization
	void Start () {
		_playerData = Camera.main.GetComponent<player>();
		GameObject obsObj = GameObject.FindGameObjectWithTag("Slider");
		obs = obsObj.GetComponent<Sliders>();
	}

	void Update () {
	
	}
	
	void OnGUI(){
		GUI.Label(new Rect(0,0,200,100),"F1: " + _playerData.getTouch(0).ToString());
		GUI.Label(new Rect(0,20,200,100),"F2: " + _playerData.getTouch(1).ToString());
		GUI.Label(new Rect(0,40,200,100),"Slider: " + obs.transform.position.ToString());
		GUI.Label(new Rect(0,60,200,100),"All Points Hit: " + _playerData.getAllContactPointsHit());
		GUI.Label(new Rect(0,80,200,100),"On Bottom Half?: " + obs.isBeforeHalfOfScreen());
		Vector2 p = Camera.main.ScreenToWorldPoint(new Vector2(0,Camera.main.pixelHeight+ 50f));
		GUI.Label(new Rect(0,100,200,100),"Screen Height: " + p.ToString());

	}
}
