using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{
    public Slider mouseSensitivitySlider;

    public void MouseSensitivity()
    {
        float sensitivity = mouseSensitivitySlider.value;
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
        PlayerPrefs.Save();
    }

    void Update()
    {
        MouseSensitivity();
    }
}
