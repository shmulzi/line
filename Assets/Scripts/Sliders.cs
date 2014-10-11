using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sliders : MonoBehaviour {

	public float slideUpwardSpeed = 1.0f;
	public float rotateSpeed = 1.0f;
	public Vector3 limbo = new Vector3(-999f, -999f, -10);
	
	private bool _alive;
	private ColorSwitcher _cSwitcher;
	private int _numOfContactPoints = 0;
	private List<GameObject> _contactPointObjs = new List<GameObject>();
		
	void Awake () {
		_cSwitcher = GetComponent<ColorSwitcher>();
		int i = 0;
		foreach(Transform tran in transform){
			if(tran.tag == "Contact"){
				LineHitPoint cpt = tran.GetComponent<LineHitPoint>();
				if(cpt != null){
					cpt.setLHPIndex(i);
					i++;
					_numOfContactPoints++;
					_contactPointObjs.Add(tran.gameObject);
				}
			}
		}
		_alive = false;
	}
	
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
	
	public void spawn(Vector3 pos){
		if(!_alive){
			_alive = true;
		}
		transform.position = pos;
		_cSwitcher.unlockColorChange();
	}
	
	public void die(){
		if(_alive){
			_alive = false;
			Active.resetHits();
		}
	}

	public void setSlideSpeed(float s){
		slideUpwardSpeed = s;
	}

	public void setRotation(float r){
		rotateSpeed = r;
	}
	
	public bool isAlive(){
		return _alive;
	}

	public int getNumOfContactPoints(){
		return _numOfContactPoints;
	}

	private bool shouldDie(){
		foreach(GameObject o in _contactPointObjs.ToArray()){
			LineHitPoint cp = o.GetComponent<LineHitPoint>();
			if(!cp.getSignal()){
				return false;
			}
		}
		return true;	
	}

	private void resetContactPoints(){
		foreach(GameObject o in _contactPointObjs.ToArray()){
			LineHitPoint cp = o.GetComponent<LineHitPoint>();
			cp.resetSignal();
		} 
	}

	private void slideTo(Vector3 dir, float speed){
		transform.Translate(dir * Time.deltaTime * speed, Space.World);
	}

	private void rotate(float speed){
		transform.Rotate(Vector3.forward * speed * Time.deltaTime);
	}
}
