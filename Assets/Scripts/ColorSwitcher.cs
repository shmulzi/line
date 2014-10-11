using UnityEngine;
using System.Collections;

public class ColorSwitcher : MonoBehaviour {
	
	public Color[] colorsInSwitcher = { Color.red, Color.green, Color.blue, Color.white, Color.yellow };
	
	private int _currColor;
	private Sliders _slider;
	private bool _colorChanged = false;


	// Use this for initialization
	void Awake () {
		switchToRandomColor();
		_slider = GetComponent<Sliders>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!_slider.isAlive() && !_colorChanged)
			switchToRandomColor();

	}

	private void switchColor(Color c){
		foreach(Transform tran in transform){
			if(tran.tag == "Block"){
				tran.renderer.material.color = c;
			}
		}
	}

	private void switchToRandomColor(){
		int c = Random.Range(0, colorsInSwitcher.Length-1);
		switchColor(colorsInSwitcher[c]);
	}

	public void unlockColorChange(){
		_colorChanged = false;
	}
}
