using UnityEngine;
using System.Collections;

public class SliderBasic : Sliders {
	
	void Update () {
		slideTo(Vector3.up, slideUpwardSpeed);
		rotate(rotateSpeed);
		if(!_alive && transform.position != limbo){
			transform.position = limbo;
		}
		if(shouldDie()){
			die();
			resetContactPoints();
		}
	}
}
