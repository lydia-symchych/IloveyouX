﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Ink.UnityIntegration;
using Ink.Runtime;

[CustomEditor(typeof(InkManager))]
[InitializeOnLoad]
public class InkManagerEditor : Editor {

    static InkManagerEditor () {
        InkManager.OnCreateStory += OnCreateStory;
    }

    static void OnCreateStory (Story story) {
        // If you'd like NOT to automatically show the window and attach (your teammates may appreciate it!) then replace "true" with "false" here. 
        InkPlayerWindow window = InkPlayerWindow.GetWindow(true);
        if(window != null) InkPlayerWindow.Attach(story);
    }
	public override void OnInspectorGUI () {
		Repaint();
		base.OnInspectorGUI ();
		var realTarget = target as InkManager;
		var story = realTarget.story;
		InkPlayerWindow.DrawStoryPropertyField(story, new GUIContent("Story"));
	}
}
