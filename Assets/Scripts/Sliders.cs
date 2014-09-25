using UnityEngine;
using System.Collections;

public class Sliders : MonoBehaviour {

	public float slideUpwardSpeed = 1.0f;
	
	public bool alive;
	
	void Start () {
		foreach(Transform tran in transform){
			if(tran.name == "Fuck Machine"){
				tran.renderer.material.color = Color.green;
			}
		}
		alive = true;
		Debug.Log(Screen.height.ToString());
	}
	
	void Update () {
		transform.Translate(Vector3.up * Time.deltaTime * slideUpwardSpeed, Space.World);
		if(!alive){
			transform.position = new Vector3(999f, 999f, -10);
		}
		
		if(transform.position.y > 125f){
			die();
			spawn();
		}
	}
	
	public void spawn(){
		if(!alive)
			alive = true;
		transform.position = new Vector3(0,-125f,0);
	}
	
	public void die(){
		if(alive)
			alive = false;
	}
	
	public bool isAlive(){
		return alive;
	}
	
	private IEnumerator wait(float seconds){
		yield return new WaitForSeconds(seconds);
	}
}
