using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputhandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
         if (!Application.isFocused) return;
         Vector3 mp = Input.mousePosition;

    if (mp.x < 0 || mp.y < 0 || mp.x > Screen.width || mp.y > Screen.height)
        return; // Out of Game view

    if (float.IsInfinity(mp.x) || float.IsNaN(mp.x))
        return;

        Debug.Log(" " + mp);
    }
}
