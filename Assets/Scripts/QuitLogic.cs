using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitLogic : MonoBehaviour
{
    public void QuitApp()
    {
#if UNITY_EDITOR
        
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

        Debug.Log("Application is quitting...");
    }
}
