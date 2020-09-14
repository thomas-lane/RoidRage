using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {
    public GameObject player, layer1, layer2;
    public float scale1, scale2;

    private float referenceX, referenceY;

    void Start() {
        referenceX = player.transform.position.x;
        referenceY = player.transform.position.y;
    }

    void Update() {
        float x = player.transform.position.x - referenceX, y = player.transform.position.y - referenceY;
        layer1.transform.position = new Vector3(transform.position.x - x * scale1, transform.position.y - y * scale1, layer1.transform.position.z);
        layer2.transform.position = new Vector3(transform.position.x - x * scale2, transform.position.y - y * scale2, layer2.transform.position.z);
    }
}
