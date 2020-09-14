using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeTransfer : MonoBehaviour {
    public float screenShakeAmount = 0.0f;

    void Update() {
        Camera.main.GetComponent<CameraFollow>().screenShakeAmount = screenShakeAmount;
    }
}
