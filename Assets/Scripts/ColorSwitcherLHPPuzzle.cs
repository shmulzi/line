using UnityEngine;
using System.Collections;

public class ColorSwitcherLHPPuzzle : ColorSwitcher {
	
	void Start () {
		_currColor = 0;
		switchToRandomColor("Contact");
	}

	public void switchToNextColor(){
		if(_currColor < colorsInSwitcher.Length-1)
			_currColor++;
		else 
			_currColor = 0;
		this.switchColor(colorsInSwitcher[_currColor], "Contact");
	}

	protected override void switchColor(Color c, string tag){
		if(transform.tag == tag){
			transform.renderer.material.color = c;
		}
	}
}
