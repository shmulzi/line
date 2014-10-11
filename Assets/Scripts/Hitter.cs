using UnityEngine;
using System.Collections;

public class Hitter : MonoBehaviour {

	public static bool blocked = false;

	void Update () {
		blocked = false;
		RaycastHit[] hits = Active._hits;
		bool gotHit = false;
		if(hits != null && hits.Length > 0){
			foreach(RaycastHit hit in hits){
				if(hit.transform.tag == "Contact"){
					LineHitPoint l = hit.transform.gameObject.GetComponent<LineHitPoint>();
					l.hit (true);
					gotHit = true;
				}
				if(hit.transform.tag == "Block"){
					blocked = true;
				}
			}
		}
		if(!gotHit){
			GameObject[] los = GameObject.FindGameObjectsWithTag("Contact");
			foreach(GameObject o in los){
				if(o.transform.tag == "Contact"){
					LineHitPoint l = o.GetComponent<LineHitPoint>();
					l.hit (false);
				}
			}
		}
		Active.resetHits();
//		Debug.Log("Blocked? : " + blocked);
	}
	
}
