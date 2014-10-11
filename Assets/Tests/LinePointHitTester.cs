using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LinePointHitTester : MonoBehaviour {

	List<LineHitPoint> points = new List<LineHitPoint>();
	List<Timer> timers = new List<Timer>();

	void Start () {
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Contact");
		foreach(GameObject obj in objs){
			LineHitPoint p = obj.GetComponent<LineHitPoint>();
			points.Add (p);
			Timer t = obj.GetComponent<Timer>();
			timers.Add (t);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		float y = 0f;
//		foreach(LineHitPoint p in points){
//			string s = "Point " + p.getLHPIndex().ToString() + ": " + p.isHit().ToString();
//			GUI.Label(new Rect(0,y,Screen.width,40), s);
//			y += 50;
//		}
		foreach(Timer t in timers){
			string s = "Timer " + t.transform.parent.name + ": " + t.getStopWatchTime();
			GUI.Label(new Rect(0,y,Screen.width,20), s);
			y += 25;
		}
	}
}
