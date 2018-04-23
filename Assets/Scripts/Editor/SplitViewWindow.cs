﻿using UnityEngine;
using UnityEditor;

public class SplitViewWindow : EditorWindow
{
    private Vector2 scrollPos = Vector2.zero;
    float currentScrollViewHeight;
    bool resize = false;
    Rect cursorChangeRect;

    [MenuItem("MyWindows/SplitView")]
    public static void Init()
    {
        GetWindow(typeof(SplitViewWindow)).Show();
    }

    void OnEnable()
    {
        position = new Rect(200, 200, 400, 300);
        currentScrollViewHeight = position.width / 2;
        cursorChangeRect = new Rect(position.width / 2, 0, 5f, position.height);
    }

    void OnGUI()
    {
        GUILayout.BeginVertical();
        scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.Height(currentScrollViewHeight));
        for (int i = 0; i < 20; i++)
            GUILayout.Label("dfs");
        GUILayout.EndScrollView();

        ResizeScrollView();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Lower part");

        GUILayout.EndVertical();
        Repaint();
    }

    private void ResizeScrollView()
    {
        GUI.DrawTexture(cursorChangeRect, EditorGUIUtility.whiteTexture);
        EditorGUIUtility.AddCursorRect(cursorChangeRect, MouseCursor.ResizeVertical);

        if (Event.current.type == EventType.MouseDown && cursorChangeRect.Contains(Event.current.mousePosition))
        {
            resize = true;
        }
        if (resize)
        {
            currentScrollViewHeight = Event.current.mousePosition.y;
            cursorChangeRect.Set(cursorChangeRect.x, currentScrollViewHeight, cursorChangeRect.width, cursorChangeRect.height);
        }
        if (Event.current.type == EventType.MouseUp)
            resize = false;
    }
}