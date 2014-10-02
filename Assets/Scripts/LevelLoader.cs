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
		}
		GameObject[] cpObjs = GameObject.FindGameObjectsWithTag("Contact");
		for(int i = 0; i < cpObjs.Length; i++){
			Instantiate(touchMarker,pool,Quaternion.identity);
		}
		loadingDone = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
