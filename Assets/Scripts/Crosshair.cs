using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    Vector3 targetPos;
    // public Texture2D cursorTexture;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        // Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

        transform.position = targetPos;
    }
}