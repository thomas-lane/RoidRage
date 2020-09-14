using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeIn : MonoBehaviour {
    public Graphic[] graphics;

    private bool begin = false;
    private float currentAlpha = 0.0f;

    // Update is called once per frame
    void Update() {
        if(begin && currentAlpha < 1.0f) {
            currentAlpha = Mathf.Lerp(currentAlpha, 1.0f, Time.deltaTime * 2.0f);

            foreach(Graphic graphic in graphics) {
                graphic.color = new Color(1.0f, 1.0f, 1.0f, currentAlpha);
            }
        }
    }

    public void Begin() {
        begin = true;
    }
}
