using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Puzzle : MonoBehaviour {

	[XmlAttribute("name")]
	public string name;

	[XmlAttribute("type")]
	public string type;

	public int topLeft, botLeft, topRight, botRight;
}
