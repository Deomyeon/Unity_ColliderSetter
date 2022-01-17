using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColliderSetterWindow : EditorWindow
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D collider;

    void OnGUI()
    {
        GUILayout.Space(10);
        spriteRenderer = EditorGUILayout.ObjectField("SpriteRenderer",spriteRenderer, typeof(SpriteRenderer), true) as SpriteRenderer;
        collider = EditorGUILayout.ObjectField("Collider", collider, typeof(BoxCollider2D), true) as BoxCollider2D;
        GUILayout.Space(20);
        if (GUILayout.Button("Setting"))
        {
            ColliderTesting();
        }
    }

    
    void ColliderTesting()
    {
        Vector2[] vertices = spriteRenderer.sprite.vertices;
        Rect rect = spriteRenderer.sprite.rect;
        
        Vector2 size = new Vector2(rect.width, rect.height) / (spriteRenderer.sprite.pixelsPerUnit * 2);


        float minX = vertices[0].x;
        float maxX = vertices[0].x;
        float minY = vertices[0].y;
        float maxY = vertices[0].y;

        foreach (var item in vertices)
        {
            if (minX > item.x)
            {
                minX = item.x;
            }
            if (maxX < item.x)
            {
                maxX = item.x;
            }
            if (minY > item.y)
            {
                minY = item.y;
            }
            if (maxY < item.y)
            {
                maxY = item.y;
            }
        }

        Vector2 verSize = new Vector2(maxX - minX, maxY - minY);
        
        collider.size = new Vector2(verSize.x, verSize.y);

        Vector2 pivot = verSize / 2 + new Vector2(minX, minY);

        collider.offset = pivot;
    }
}
