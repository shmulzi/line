using UnityEngine;
using System.Collections;

public class SliderLauncher : MonoBehaviour {

	private GameObject[] sliders;
	private bool dieOnDissapear = true;
	private float screenMaxY;
	private float screenMinY;

	public float spawnPointOffset = 50f;
	public float killOffScreenOffset = 50f;
	public float randomSpeedRangeMin = 20f;
	public float randomSpeedRangeMax = 30f;
	public float randomRotateRangeMin = -30f;
	public float randomRotateRangeMax = 30f;


	void Start () {
		sliders = GameObject.FindGameObjectsWithTag("Slider");
		screenMaxY = Camera.main.ScreenToWorldPoint(new Vector3(0,Camera.main.pixelHeight,0)).y;
		screenMinY = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0)).y;
	}
	

	void Update () {
		foreach(GameObject slider in sliders){
			Sliders scr = slider.GetComponent<Sliders>();
			//when slider reaches top of screen kill and launch new slider
			if(dieOnDissapear && slider.transform.position.y > screenMaxY+killOffScreenOffset){
				scr.die();
				launchRandomSlider();
			}
		}
	}

	private void launchSlider(int i){
		if(i < sliders.Length){
			Sliders scr = sliders[i].GetComponent<Sliders>();
			scr.spawn(new Vector3(0,screenMinY - spawnPointOffset,0));
		} else {
			Debug.Log("index is above the length of slider array");
		}
	}

	private void launchSlider(int i, float speed){
		if(i < sliders.Length){
			Sliders scr = sliders[i].GetComponent<Sliders>();
			scr.setSlideSpeed(speed);
			scr.spawn(new Vector3(0,screenMinY - spawnPointOffset,0));
		} else {
			Debug.Log("index is above the length of slider array");
		}
	}

	private void launchSlider(int i, float speed, float rotation){
		if(i < sliders.Length){
			Sliders scr = sliders[i].GetComponent<Sliders>();
			scr.setSlideSpeed(speed);
			scr.setRotation(rotation);
			scr.spawn(new Vector3(0,screenMinY - spawnPointOffset,0));
		} else {
			Debug.Log("index is above the length of slider array");
		}
	}

	public bool allSlidersDead(){
		foreach(GameObject slider in sliders){
			Sliders scr = slider.GetComponent<Sliders>();
			if(scr.isAlive()){
				return false;
			}
		}
		return true;
	}

	public void launchRandomSlider(){
		int rand = Random.Range(0, sliders.Length);
		float randSpeed = Random.Range(randomSpeedRangeMin,randomSpeedRangeMax);
		float randRotation = Random.Range(randomRotateRangeMin,randomRotateRangeMax);
		launchSlider(rand, randSpeed, randRotation);
	}

	public void launchRandomSlider(float speed){
		int rand = Random.Range(0, sliders.Length-1);
		float randRotation = Random.Range(randomRotateRangeMin,randomRotateRangeMax);
		launchSlider(rand, speed, randRotation);
	}

	public void launchRandomSlider(float speed, float rotation){
		int rand = Random.Range(0, sliders.Length-1);
		launchSlider(rand, speed, rotation);
	}

	public void shouldDieOnDissapear(bool b){
		dieOnDissapear = b;
	}
}
