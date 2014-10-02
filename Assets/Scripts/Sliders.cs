using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sliders : MonoBehaviour {

	public float slideUpwardSpeed = 1.0f;
	public float rotateSpeed = 1.0f;
	
	private bool alive;
	private Vector3 limbo = new Vector3(-999f, -999f, -10);
	private int _numOfContactPoints = 0;
	private Active active;
	private List<GameObject> cpHits = new List<GameObject>();
	private Color[] colors = { Color.red, Color.green, Color.blue, Color.white, Color.yellow };
	private int currColor;
	private List<ContactPoint> contactPoints = new List<ContactPoint>();

	void Start () {
		currColor = Random.Range(0, colors.Length-1);
		active = Camera.main.GetComponent<Active>();
		foreach(Transform tran in transform){
			int i = 0;
			if(tran.tag == "Block"){
				tran.renderer.material.color = colors[currColor];
			}
			if(tran.tag == "Contact"){
				ContactPoint cpt = tran.GetComponent<ContactPoint>();
				cpt.setContactIndex(i);
				i++;
				_numOfContactPoints++;
				contactPoints.Add(cpt);
			}
		}
		alive = false;
	}
	
	void Update () {
		transform.Translate(Vector3.up * Time.deltaTime * slideUpwardSpeed, Space.World);
		transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
		if(!alive && transform.position != limbo){
			transform.position = limbo;
		}
		
		if(shouldDie()){
			die();
			resetContactPoints();
		}
	}
	
	public void spawn(Vector3 pos){
		if(!alive){
			currColor = Random.Range(0, colors.Length-1);
			foreach(Transform tran in transform){
				if(tran.tag == "Block"){
					tran.renderer.material.color = colors[currColor];
				}
			}
			alive = true;
		}
		transform.position = pos;
	}
	
	public void die(){
		if(alive){
			alive = false;
			active.resetHits();
		}
	}

	public void setSlideSpeed(float s){
		slideUpwardSpeed = s;
	}

	public void setRotation(float r){
		rotateSpeed = r;
	}
	
	public bool isAlive(){
		return alive;
	}
	

	public bool isBeforeHalfOfScreen(){
		if(transform.position.y <= Screen.height/16)
			return true;
		else
			return false;
	}

	public int getNumOfContactPoints(){
		return _numOfContactPoints;
	}

	private bool shouldDie(){
		RaycastHit[] hits = active.getHits();
		if(hits != null && hits.Length > 0){
			foreach(RaycastHit hit in hits){
				if(hit.transform.tag == "Contact"){
					ContactPoint cp = hit.transform.GetComponent<ContactPoint>();
					cp.touching(true);
				}
			}
		}
		foreach(ContactPoint cp in contactPoints){
			if(!cp.isTouched()){
				return false;
			}
		}
		return true;
	}

	private void resetContactPoints(){
		foreach(ContactPoint cp in contactPoints){
			cp.touching(false);
			cp.deatchMarker();
		}
	}


}
