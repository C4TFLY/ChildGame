using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LocalizedTextEditor : EditorWindow {

    public LocalizationData localizationData;
    public LocalizationData localizationData2;

    private Vector2 scrollPos, scrollPos2 = Vector2.zero;
    private float currentScrollViewWidth;
    private Rect cursorChangeRect;
    private bool resize = false;
    private bool loadedData1, loadedData2 = false;

    [MenuItem("Window/Localized Text Editor")]
    private static void Init()
    {
        GetWindow(typeof(LocalizedTextEditor)).Show();
    }

    private void OnEnable()
    {
        position = new Rect(200, 200, 400, 300);
        currentScrollViewWidth = position.width / 2;
        cursorChangeRect = new Rect(position.width / 2, 0, 5f, position.height);
    }

    private void OnGUI()
    {
        cursorChangeRect.Set(currentScrollViewWidth, cursorChangeRect.y, cursorChangeRect.width, position.height);
        GUILayout.BeginHorizontal();

#region Left side

        scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.Height(position.height), GUILayout.Width(currentScrollViewWidth));

        

        if (localizationData != null && loadedData1)
        {
            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty("localizationData");
            if (serializedProperty != null)
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

        GUILayout.EndScrollView();

#endregion

        ResizeScrollView();
        GUILayout.FlexibleSpace();

        scrollPos2 = GUILayout.BeginScrollView(scrollPos2, GUILayout.Height(position.height), GUILayout.Width(position.width - currentScrollViewWidth));

        if (localizationData2 != null && loadedData2)
        {
            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty("localizationData2");
            if (serializedProperty != null)
                EditorGUILayout.PropertyField(serializedProperty, true);
        }

        if (GUILayout.Button("Load comparison data"))
        {
            CompareData();
        }

        GUILayout.EndScrollView();

        GUILayout.EndHorizontal();
        Repaint();
    }

    private void CreateNewData()
    {
        localizationData = new LocalizationData();
        loadedData1 = true;
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
            loadedData1 = true;
        }
    }

    private void CompareData()
    {
        string filePath = EditorUtility.OpenFilePanel("Select localization data file", Application.streamingAssetsPath, "json");
        if (!string.IsNullOrEmpty(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            localizationData2 = JsonUtility.FromJson<LocalizationData>(dataAsJson);
            loadedData2 = true;
        }
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
        }
        if (Event.current.type == EventType.MouseUp)
        {
            resize = false;
        }
    }
}
