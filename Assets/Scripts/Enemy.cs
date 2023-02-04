using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Bullet") {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}