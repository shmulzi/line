using UnityEngine;
using UnityEditor;
using System.Collections;

public class findGBFromIDWindow : EditorWindow {

	int id = 0;
	
	Object o = null;
	string s = "none";
	
	[MenuItem ("Custom/Find GB from ID")]

	public static void  ShowWindow () {
		EditorWindow.GetWindow(typeof(findGBFromIDWindow));
	}
	
	void OnGUI(){
		id = EditorGUILayout.IntField("fuckity: ", id);
		if(GUILayout.Button("BUTTUN")){
			Debug.Log("FUCK ME BABY!");
			o = EditorUtility.InstanceIDToObject(id);
			s = o.name;
		}
		EditorGUILayout.ObjectField(o, typeof(GameObject),true);
	}
}
