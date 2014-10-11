using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {
	
	public GameObject[] sliders;
	public GameObject circle;
	public GameObject cross;
	public GameObject touchMarker;
	public Vector3 pool;
	public static bool loadingDone = false;

	void Awake () {
//		foreach(GameObject slider in sliders){
//			Instantiate(slider, pool, Quaternion.identity);
//		}
		
//		Instantiate(cross, pool, Quaternion.identity);
//		Instantiate(circle, pool, Quaternion.identity);
//		loadingDone = true;
	}

	void Update () {
	
	}
}
