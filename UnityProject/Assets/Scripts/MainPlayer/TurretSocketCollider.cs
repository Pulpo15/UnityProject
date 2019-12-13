using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSocketCollider : MonoBehaviour {

    public GameObject TurretSocket;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "TurretSocketTag") 
            TurretSocket = other.gameObject;
    }
}
