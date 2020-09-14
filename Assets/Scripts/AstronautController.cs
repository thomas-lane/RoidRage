using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class AstronautController : MonoBehaviour {
    public Transform jumpTest;
    public SpriteRenderer[] spriteRenderers;
    public float gravityRadius = 1.0f, jumpForce, minJumpInterval = 0.1f, movementSpeed;

    private Rigidbody2D rb2d;
    private Animator animator;
    private float lastJumpTime, moveLeft = -1.0f, moveRight = -1.0f;
    private bool isGrounded = false;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lastJumpTime = -minJumpInterval;
    }

    void Update() {
        //transform.position += (Vector3.up * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal")) * Time.deltaTime;

        Collider2D jumpTestCollision = Physics2D.OverlapPoint(jumpTest.position);
        if(jumpTestCollision) isGrounded = true;
        else isGrounded = false;

        if(Input.GetKey(KeyCode.Space) && isGrounded && Time.time - lastJumpTime > minJumpInterval) {
            // Jump!
            rb2d.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

            Rigidbody2D oppositeRb2d = jumpTestCollision.GetComponent<Rigidbody2D>();
            if(oppositeRb2d) {
                oppositeRb2d.AddForce(-transform.up * jumpForce, ForceMode2D.Impulse);
            }

            lastJumpTime = Time.time;
        } else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            // Move left!
            moveLeft = Time.time;
        } else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            // Move right!
            moveRight = Time.time;
        }

        if(!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))) {
            moveLeft = -1.0f;
        }

        if(!(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))) {
            moveRight = -1.0f;
        }
    }

    void FixedUpdate() {
        RaycastHit2D gravityHit = Physics2D.CircleCast(transform.position, gravityRadius, Vector2.zero, 0.0f, LayerMask.GetMask("Gravity"));
        
        if(gravityHit) {
            rb2d.gravityScale = 0.0f;
            Vector2 difference = gravityHit.collider.transform.position - transform.position;
            rb2d.AddForce(difference.normalized * Physics2D.gravity.magnitude, ForceMode2D.Force);
            rb2d.SetRotation(Mathf.MoveTowardsAngle(rb2d.rotation, Mathf.Rad2Deg * Mathf.Atan2(difference.y, difference.x) + 90.0f, Time.deltaTime * 100.0f));
        } else {
            rb2d.gravityScale = 1.0f;
            rb2d.SetRotation(Mathf.MoveTowardsAngle(rb2d.rotation, 0.0f, Time.deltaTime * 100.0f));
        }

        if(moveLeft > 0.0f || moveRight > 0.0f) {
            animator.SetBool("isWalking", true);

            // I'm pretty sure this should be changed for when the player is not under the influence of gravity...
            Vector2 xComponent, yComponent = -transform.up * rb2d.velocity.magnitude * Mathf.Cos(Mathf.Deg2Rad * Vector2.SignedAngle(rb2d.velocity, -transform.up));
            if(moveLeft > moveRight) {
                // Move left
                xComponent = -transform.right * movementSpeed;

                foreach(SpriteRenderer sr in spriteRenderers) {
                    sr.flipX = true;
                }
            } else {
                // Move right
                xComponent = transform.right * movementSpeed;

                foreach(SpriteRenderer sr in spriteRenderers) {
                    sr.flipX = false;
                }
            }
            rb2d.velocity = xComponent + yComponent;
        } else {
            if(isGrounded) rb2d.velocity = -transform.up * rb2d.velocity.magnitude * Mathf.Cos(Mathf.Deg2Rad * Vector2.SignedAngle(rb2d.velocity, -transform.up));

            animator.SetBool("isWalking", false);
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, gravityRadius);
    }
}
