using UnityEngine;
using System.Collections;

public class ColorSwitcher : MonoBehaviour {
	
	public Color[] colorsInSwitcher = { Color.red, Color.green, Color.blue, Color.white, Color.yellow };
	
	protected int _currColor;
//	private Sliders _slider;
	protected bool _colorChanged = false;
	
	void Awake () {
//		switchToRandomColor();
//		_slider = GetComponent<Sliders>();
	}

	void Update () {
//		if(!_slider.isAlive() && !_colorChanged)
//			switchToRandomColor();

	}

	protected virtual void switchColor(Color c, string tag){
		foreach(Transform tran in transform){
			if(tran.tag == tag){
				tran.renderer.material.color = c;
			}
		}
	}

	public void switchToRandomColor(string tag){
		int c = Random.Range(0, colorsInSwitcher.Length-1);
		switchColor(colorsInSwitcher[c], tag);
		_currColor = c;
	}

	public void unlockColorChange(){
		_colorChanged = false;
	}
}
