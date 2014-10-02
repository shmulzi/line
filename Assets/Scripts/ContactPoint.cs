using UnityEngine;
using System.Collections;

public class ContactPoint : MonoBehaviour {

	private int _contactIndex;
	private bool _isBeingTouched;
	private bool _marked = false;
	private TouchMarkerDispenser markDispenser;

	void Start () {
		_isBeingTouched = false;
		GameObject scriptHolder = GameObject.FindGameObjectWithTag("Script Holder");
		markDispenser = scriptHolder.GetComponent<TouchMarkerDispenser>();
	}

	public void touching(bool b){
		_isBeingTouched = b;
		shouldAttachMarker(b);
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

	public void deatchMarker(){
		if(transform.childCount > 0){
			Transform currMarker = transform.GetChild(0);
			TouchMarker currMarkerScript = currMarker.GetComponentInChildren<TouchMarker>();
			currMarker.transform.parent = null;
			currMarker.transform.position = markDispenser.markerPool;
			currMarkerScript.deactivate();
		}
	}

	private void shouldAttachMarker(bool b){
		if(b && !_marked){
			Transform mark = markDispenser.dispenseMarker();
			if(mark != null){
				mark.transform.position = transform.position;
				mark.transform.parent = transform;
				_marked = true;
			}
		} 

	}
}
