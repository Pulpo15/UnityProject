using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTurret : MonoBehaviour
{
    public GameObject TurretPrefab;
    
    GameObject TurretSocket;
    public float range = 10f;
    
    void Update() {

        RaycastHit hit;
        Camera cam = GetComponentInChildren<Camera>();
        Ray rayDirection = new Ray(transform.position, transform.forward);

        Debug.DrawRay(transform.position, cam.transform.forward * range);

        if (Physics.Raycast(rayDirection, out hit, range)) {
            if (hit.collider.gameObject == TurretSocket) {

                GameObject Turret = Instantiate(TurretPrefab, TurretSocket.transform);

                Debug.Log("RayCastTurret");
                if (Input.GetKey(KeyCode.Mouse0)) {
                    Debug.Log("OnClick");
                }
            }
        }
    }

    private void OnTriggerStay(Collider other) {
        Debug.Log("Trigger");
        if (other.gameObject.tag == "TurretSocketTag") {
            Debug.Log("Correct Trigger With TurretSocket");
        }
    }

    //TurretSocket = collision.gameObject;/*GameObject.FindGameObjectWithTag("TurretPlace");*/

}
