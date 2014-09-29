using UnityEngine;
using System.Collections;

public class DebugGUI : MonoBehaviour {

	private Active _active;
	private Sliders obs;

	// Use this for initialization
	void Start () {
		_active = Camera.main.GetComponent<Active>();
		GameObject obsObj = GameObject.FindGameObjectWithTag("Slider");
		obs = obsObj.GetComponent<Sliders>();
	}

	void Update () {
	
	}
	
	void OnGUI(){
//		GUI.Label(new Rect(0,0,200,100),"F1: " + _active.getTouch(0).ToString());
//		GUI.Label(new Rect(0,20,200,100),"F2: " + _active.getTouch(1).ToString());
//		GUI.Label(new Rect(0,40,200,100),"Slider: " + obs.transform.position.ToString());
//		GUI.Label(new Rect(0,80,200,100),"On Bottom Half?: " + obs.isBeforeHalfOfScreen());
//		Vector2 p = Camera.main.ScreenToWorldPoint(new Vector2(0,Camera.main.pixelHeight+ 50f));
//		if(_active.getHits() != null)
//			GUI.Label(new Rect(0,100,200,100),"How Many Hits?: " + _active.getHits().Length);

	}
}
