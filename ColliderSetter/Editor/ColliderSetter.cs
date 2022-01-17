using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColliderSetter : MonoBehaviour
{
    public static EditorWindow window;

    public const int width = 300;
    public const int height = 100;

    [MenuItem("ColliderSetter/ColliderSetter")]
    public static void HierarchySearcher_Show()
    {
        window = EditorWindow.GetWindow<ColliderSetterWindow>();
        window.titleContent = new GUIContent("ColliderSetter");
        Rect WindowRect = window.position;
        WindowRect.x = Screen.width;
        WindowRect.width = width;
        WindowRect.height = height;
        window.position = WindowRect;
        window.minSize = new Vector2(width, height / 10);
        window.maxSize = new Vector2(width, height);
    }
    
}
