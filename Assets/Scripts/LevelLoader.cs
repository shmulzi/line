using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {
	
	public GameObject[] sliders;
	public GameObject touchMarker;
	public Vector3 pool;
	public static bool loadingDone = false;

	void Awake () {
		foreach(GameObject slider in sliders){
			Instantiate(slider, pool, Quaternion.identity);
			Sliders sliderScript = slider.GetComponent<Sliders>();
			for(int i = 0; i <= sliderScript.getNumOfContactPoints(); i++){
				Instantiate(touchMarker,pool,Quaternion.identity);
			}
		}
		loadingDone = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
