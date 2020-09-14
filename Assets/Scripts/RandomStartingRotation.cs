using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RandomStartingRotation : MonoBehaviour {
    void Start() {
        GetComponent<Rigidbody2D>().SetRotation(Random.Range(0.0f, 360.0f));
    }
}
