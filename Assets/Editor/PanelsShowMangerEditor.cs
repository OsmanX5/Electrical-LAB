using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PanelsShowManger))]
public class PanelsShowMangerEditor :Editor
{
	string toShowPanel;

	
	public override void OnInspectorGUI()
	{
		PanelsShowManger myTarget = (PanelsShowManger)target;
		base.OnInspectorGUI();
		GUILayout.Space(10);
		GUILayout.Label("# Test Show Panel ");
		toShowPanel = EditorGUILayout.TextField("Panel Name", toShowPanel);
		if (GUILayout.Button("Test Show Panel"))
		{
			Debug.Log($"Test Show Panel: {toShowPanel} ");
			myTarget.GetPanelsFromHolder();
			myTarget.ShowPanelWithName(toShowPanel);
		}
	}
}
