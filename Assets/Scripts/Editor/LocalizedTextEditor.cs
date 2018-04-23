using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LocalizedTextEditor : EditorWindow {

    public LocalizationData localizationData;

    private Vector2 scrollPos = Vector2.zero;
    private float currentScrollViewWidth, currentScrollViewHeight;
    private Rect cursorChangeRect;
    private bool resize = false;

    [MenuItem("Window/Localized Text Editor")]
    private static void Init()
    {
        GetWindow(typeof(LocalizedTextEditor)).Show();
    }

    private void OnEnable()
    {
        position = new Rect(200, 200, 400, 300);
        currentScrollViewWidth = position.width / 2;
        currentScrollViewHeight = position.height / 2;
        cursorChangeRect = new Rect(position.width / 2, 0, 5f, position.height);
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();

        scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.Height(currentScrollViewHeight), GUILayout.Width(currentScrollViewWidth));
        GUILayout.EndScrollView();

        if (localizationData != null)
        {

            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty("localizationData");
            EditorGUILayout.PropertyField(serializedProperty, true);

            serializedObject.ApplyModifiedProperties();

            if(GUILayout.Button("Save data"))
            {
                SaveLocaleData();
            }
        }
        if(GUILayout.Button("Load data"))
        {
            LoadLocaleData();
        }
        if(GUILayout.Button("Create new data"))
        {
            CreateNewData();
        }

        ResizeScrollView();
        GUILayout.FlexibleSpace();

        if(GUILayout.Button("Load comparison data"))
        {
            CompareData();
        }

        GUILayout.EndHorizontal();
        Repaint();
    }

    private void CreateNewData()
    {
        localizationData = new LocalizationData();
    }

    private void SaveLocaleData()
    {
        string filePath = EditorUtility.SaveFilePanel("Save localization data file", Application.streamingAssetsPath, "", "json");

        if (!string.IsNullOrEmpty(filePath))
        {
            string dataAsJson = JsonUtility.ToJson(localizationData);
            File.WriteAllText(filePath, dataAsJson);
        }
    }

    private void LoadLocaleData()
    {
        string filePath = EditorUtility.OpenFilePanel("Select localization data file", Application.streamingAssetsPath, "json");

        if (!string.IsNullOrEmpty(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);

            localizationData = JsonUtility.FromJson<LocalizationData>(dataAsJson);
        }
    }

    private void CompareData()
    {
        GetWindow(typeof(DataComparison)).Show();
    }

    private void ResizeScrollView()
    {
        GUI.DrawTexture(cursorChangeRect, EditorGUIUtility.whiteTexture);
        EditorGUIUtility.AddCursorRect(cursorChangeRect, MouseCursor.ResizeHorizontal);

        if(Event.current.type == EventType.MouseDown && cursorChangeRect.Contains(Event.current.mousePosition))
        {
            resize = true;
        }
        if (resize)
        {
            currentScrollViewWidth = Event.current.mousePosition.x;
            cursorChangeRect.Set(currentScrollViewWidth, cursorChangeRect.y, cursorChangeRect.width, cursorChangeRect.height);
        }
        if (Event.current.type == EventType.MouseUp)
        {
            resize = false;
        }
    }
}

public class DataComparison : EditorWindow
{
    public LocalizationData localizationData;

    private void OnGUI()
    {
        if (localizationData != null)
        {
            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty("localizationData");
            EditorGUILayout.PropertyField(serializedProperty, true);
        }
        if (GUILayout.Button("Load data"))
        {
            string filePath = EditorUtility.OpenFilePanel("Select localization data file", Application.streamingAssetsPath, "json");
            string dataAsJson = File.ReadAllText(filePath);
            localizationData = JsonUtility.FromJson<LocalizationData>(dataAsJson);
        }
    }
}
