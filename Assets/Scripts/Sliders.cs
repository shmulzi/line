using UnityEngine;
using System.Collections;

public class Sliders : MonoBehaviour {

	public float slideUpwardSpeed = 1.0f;
	public float rotateSpeed = 1.0f;

	private bool alive;
	private Vector3 limbo = new Vector3(999f, 999f, -10);

	void Start () {
		foreach(Transform tran in transform){
			if(tran.name == "Fuck Machine"){
				tran.renderer.material.color = Color.green;
			}
		}
		alive = true;
	}
	
	void Update () {
		transform.Translate(Vector3.up * Time.deltaTime * slideUpwardSpeed, Space.World);
		transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
		if(!alive && transform.position != limbo){
			transform.position = limbo;
		}
	}
	
	public void spawn(Vector3 pos){
		if(!alive)
			alive = true;
		transform.position = pos;
	}
	
	public void die(){
		if(alive)
			alive = false;
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
	
	private IEnumerator wait(float seconds){
		yield return new WaitForSeconds(seconds);
	}
}
