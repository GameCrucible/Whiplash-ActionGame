using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{ 
    public MouseLook mouseScript;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MouseSensitivity"))
        {
            float sensitivity = PlayerPrefs.GetFloat("MouseSensitivity");
            mouseScript.SetMouseSensitivity(sensitivity);
        }
    }
}
