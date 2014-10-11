using UnityEngine;
using System.Collections;

public class SimpleAnim : MonoBehaviour {

	public Color[] colors;
	public Vector3 pool;
	public AnimationClip verAnim;
	public AnimationClip horAnim;
	public float minX, maxX, minY, maxY, permZ;

	private int _numOfObjects = 0;

	void Start () {
		foreach(Transform tran in transform){
			int c = Random.Range(0, colors.Length-1);
			tran.renderer.material.color = colors[c];
			randomPositionObject(tran);
			_numOfObjects++;
		}
	}

	void Update () {
	}

	private void randomStartPositionHor(Transform t){
		float randY = Random.Range(minY+10f,maxY-10f);
		t.position = new Vector3(minX, randY, permZ);
		t.animation.clip = horAnim;
		t.animation.Play();

	}

	private void randomStartPositionVer(Transform t){
		float randX = Random.Range(minX+10f, maxX-10f);
		Debug.Log(randX.ToString());
		t.position = new Vector3(randX, minY, permZ);
		t.animation.clip = verAnim;
		t.animation.Play();

	}

	private void randomPositionObject(Transform t){
		int rand = Random.Range(0, 2);
		switch(rand) {
			case 0:
				randomStartPositionHor(t);
				break;
			case 1:
				randomStartPositionVer(t);
				break;
		}
	}
}
