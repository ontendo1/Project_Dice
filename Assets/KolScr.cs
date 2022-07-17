using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KolScr : MonoBehaviour
{
    Vector2 mousePos;
    void FixedUpdate()
    {
        mousePos = Input.mousePosition;
        transform.LookAt(new Vector2(mousePos.x,mousePos.y-90f));
    }
}
