using UnityEngine;
using System.Collections;

public class ContactPoint : MonoBehaviour {

	private int _contactIndex;
	private bool _isBeingTouched;

	void Start () {
		_isBeingTouched = false;
	}

	public void touching(bool b){
		_isBeingTouched = b;
	}

	public bool isTouched(){
		return _isBeingTouched;
	}

	public void setContactIndex(int i){
		_contactIndex = i;
	}

	public int getContactIndex(){
		return _contactIndex;
	}
}
