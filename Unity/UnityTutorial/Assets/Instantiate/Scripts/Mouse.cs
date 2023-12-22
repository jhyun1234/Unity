using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CURSOR
{
    Hold,
    Attack
}
public class Mouse : MonoBehaviour
{
    [SerializeField] Texture2D [] mouseCursor;
    void Start()
    {
        SetCursor(CURSOR.Hold);
    }

    
    void Update()
    {
        Lanuch();
    }

    public void Lanuch()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            SetCursor(CURSOR.Attack);
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            SetCursor(CURSOR.Hold);
        }
    }

    public void SetCursor(CURSOR cursorImage)
    {
        Cursor.SetCursor(mouseCursor[(int)cursorImage], Vector2.zero, CursorMode.ForceSoftware);

    }
}
