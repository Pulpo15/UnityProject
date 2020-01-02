using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NexusController : MonoBehaviour {

    public Slider HPBar;
    public float HP;

    void Start() {
        HPBar = GameObject.FindObjectOfType<Slider>();
    }

    void Update() {
        if (HP <= 0) {
            //Win
            Destroy(gameObject);
        }
    }

    //private void OnCollisionEnter(Collision collision) {
    //    if (collision.gameObject.tag == "Enemy") {
    //        Destroy(collision.gameObject);
    //        HP -= 0.1f;
    //        HPBar.value = HP;
    //    }
    //}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            Destroy(other.gameObject);
            HP -= 0.1f;
            HPBar.value = HP;
        }
    }

    //private void OnControllerColliderHit(ControllerColliderHit hit) {
    //    if (hit.gameObject.tag == "Enemy") {
    //        Destroy(hit.gameObject);
    //        HP -= 0.1f;
    //        HPBar.value = HP;
    //    }
    //}

}
