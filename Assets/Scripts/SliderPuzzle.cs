using UnityEngine;
using System.Collections;
using System.IO;

public class SliderPuzzle : Sliders {

	private PuzzleCollection puzzleCollection;

	void Start(){
		puzzleCollection = PuzzleCollection.Load(Path.Combine(Application.dataPath, "XML/puzzles.xml"));
		_cSwitcher = GetComponent<ColorSwitcher>();
		foreach(Transform t in transform){
			if(t.tag == "Block"){
				_cSwitcher.switchToRandomColor("Block");
			}
		}
	}

	void Update () {
		slideTo(Vector3.up, slideUpwardSpeed);
	}
}
