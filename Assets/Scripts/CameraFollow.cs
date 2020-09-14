using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform toFollow;
    public float maxFollowDistance, screenShakeAmount = 0.0f;

    void Start() {
        
    }

    void Update() {
        // Slowly move towards the target until a limit distance is reached.
        Vector3 position = Vector2.Lerp(transform.position, toFollow.position, Time.deltaTime);

        if(Vector2.Distance(position, toFollow.position) > maxFollowDistance) {
            Vector2 difference = position - toFollow.position;
            difference.Normalize();
            position = difference * maxFollowDistance;
            position += toFollow.position;
        }

        // Make sure the z value stays the same
        position.z = transform.position.z;

        // Set the new camera position
        transform.position = position + new Vector3(Random.Range(-screenShakeAmount, screenShakeAmount), Random.Range(-screenShakeAmount, screenShakeAmount), 0.0f);
    }
}
