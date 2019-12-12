using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSocketCollider : MonoBehaviour {

    public GameObject TurretSocket;

    private void OnTriggerStay(Collider other) {
        //Debug.Log("Trigger");
        if (other.gameObject.tag == "TurretSocketTag") {
            //Debug.Log("Correct Trigger With TurretSocket");
            TurretSocket = other.gameObject;
        }
    }
}
