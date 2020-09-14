using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UIFadeIn))]
public class CommunicatorCollider : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collider) {
        AstronautController astronaut = collider.GetComponent<AstronautController>();

        if(astronaut) {
            GetComponent<UIFadeIn>().Begin();
        }
    }
}
