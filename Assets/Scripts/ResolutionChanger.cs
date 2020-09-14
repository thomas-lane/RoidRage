using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionChanger : MonoBehaviour {
    public GameObject[] resolutionObjects;

    void Update() {
        if(Input.GetKeyDown(KeyCode.R)) {
            foreach(GameObject resolution in resolutionObjects) {
                resolution.SetActive(true);
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            foreach(GameObject resolution in resolutionObjects) {
                resolution.SetActive(false);
            }
        }
    }

    public void SetResolution(int height) {
        int width = height * 16 / 9;

        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    public void ToggleFullScreen() { // Failure
        Screen.fullScreen = !Screen.fullScreen;
        
    }
}
