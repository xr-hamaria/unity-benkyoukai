using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2f;
    private float jumpHeight = 1f;
    private float gravityValue = -9.81f;

    public GameObject projectile;

    void Start() {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update() {
        groundedPlayer = controller.isGrounded;
        if(groundedPlayer && playerVelocity.y < 0) {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if(move != Vector3.zero) {
            gameObject.transform.forward = move;
        }

        if(Input.GetButtonDown("Jump") && groundedPlayer) {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.F)) {
            Vector3 playerPos = transform.position;
            Vector3 playerDirection = transform.forward;
            Quaternion playerRotation = transform.rotation;
            float spawnDistance = 1f;
            Vector3 spawnPos = playerPos + playerDirection*spawnDistance;

            GameObject bullet = Instantiate(projectile, spawnPos, transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        }
    }
}
