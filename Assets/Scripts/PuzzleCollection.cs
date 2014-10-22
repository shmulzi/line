using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("PuzzleCollection")]
public class PuzzleCollection {

	[XmlArray("Puzzles")]
	[XmlArrayItem("Puzzle")]
	public Puzzle[] puzzles;
	int dummy = 0;

	public static PuzzleCollection Load(string path)
	{
		var serializer = new XmlSerializer(typeof(PuzzleCollection));
		using(var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize(stream) as PuzzleCollection;
		}
	}
}
