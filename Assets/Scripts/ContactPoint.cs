using UnityEngine;
using System.Collections;

public class ContactPoint : MonoBehaviour {

	private int _contactIndex;
	private bool _isBeingTouched;
	private TouchMarkerDispenser markDispenser;

	void Start () {
		_isBeingTouched = false;
		GameObject scriptHolder = GameObject.FindGameObjectWithTag("Script Holder");
		markDispenser = scriptHolder.GetComponent<TouchMarkerDispenser>();
	}

	public void touching(bool b){
		if(b){
			GameObject mark = markDispenser.dispenseMarker();
			mark.transform.parent = transform;
		} else {
			TouchMarker currMarker = gameObject.GetComponentInChildren<TouchMarker>();
			transform.DetachChildren();
			currMarker.deactivate();	
		}
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
