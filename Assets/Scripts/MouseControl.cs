using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    Ray ray;
    RaycastHit2D hit;
    
}


        /*
       if(hit.collider != null)
        {
            print(hit.collider.name);
        }
        else
        {
            print("b);
        }
    }
}

/*
RaycastHit hit;
bool hasHit = false;
enum CursorType
{
    Grave,
    UI,
    None
}

[System.Serializable]
struct CursorMapping
{
    public CursorType type;
    public Texture2D texture;
    public Vector2 hotspot;
}

[SerializeField] CursorMapping[] cursorMappings = null;
void Start()
{

}

void Update()
{
    InteractWithObject();
}

private void InteractWithObject()
{
    if (GetMouseRay() != false)
    {
        string targetTag = GetMouseRay().transform.gameObject.tag;
        switch (targetTag)
        {
            case "Grave":
                SetCursor(CursorType.Grave);
                if (Input.GetMouseButtonDown(0))
                {
                    // dig grave
                }
                break;

            case "UI":
                SetCursor(CursorType.UI);
                if (Input.GetMouseButtonDown(0))
                {
                    // do nothing
                }
                break;

            default:
                SetCursor(CursorType.None);
                Debug.Log("target tag is none");
                break;
        }
    }
    else
    {
        Debug.Log("no cast detected");
        SetCursor(CursorType.None);
    }
}

private void ProcessMouseClick()
{

}

private void SetCursor(CursorType type)
{
    CursorMapping mapping = GetCursorMapping(type);
    Cursor.SetCursor(mapping.texture, mapping.hotspot, CursorMode.Auto);
}

private CursorMapping GetCursorMapping(CursorType type)
{
    foreach (CursorMapping mapping in cursorMappings)
    {
        if (mapping.type == type)
        {
            return mapping;
        }
    }
    return cursorMappings[0];
}
private static RaycastHit2D GetMouseRay()
{
    RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));//Camera.main.ScreenPointToRay(Input.mousePosition);
    return rayHit;
}
}
*/
