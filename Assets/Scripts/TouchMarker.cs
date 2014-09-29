using UnityEngine;
using System.Collections;

public class TouchMarker : MonoBehaviour {

	private bool _activated = false;

	void Start(){
	}

	public void activate(){
		_activated = true;
	}

	public void deactivate(){
		_activated = false;
	}

	public bool isActivated(){
		return _activated;
	}
}
