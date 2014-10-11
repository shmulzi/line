using UnityEngine;
using System.Collections;

public class TimerTester : MonoBehaviour {

	Timer timer;

	void Start () {
		timer = GetComponent<Timer>();
	}

	void OnGUI(){
		if(GUI.Button(new Rect(10,10,50,30),"start"))
		    timer.startStopWatch();
		if(GUI.Button(new Rect(60,10,50,30),"stop"))
			timer.stopStopWatch();
		if(GUI.Button(new Rect(10,60,50,30),"reset"))
			timer.resetStopWatch();

		GUI.Box (new Rect(Screen.width-50, 0, 50, 30), timer.getStopWatchTime().ToString("0.00")); 
	}
}
