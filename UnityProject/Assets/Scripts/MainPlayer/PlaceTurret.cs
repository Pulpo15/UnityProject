using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTurret : MonoBehaviour
{
    public GameObject TurretPrefab;
    public TurretSocketCollider TurretSocket;
    GameObject Turret;
    GameObject PermanentTurret;

    public bool turretOn;
    public bool permanentTurretOn;
    public float range = 10f;

    void Update() {

        //Raycast collider detector
        RaycastHit hit;
        //Asign the rotation of the Camera to the RayCast
        Camera cam = GetComponentInChildren<Camera>();
        Ray rayDirection = new Ray(transform.position, transform.forward);
        Color RayColor = new Color(1, 0, 0, 1);
        Debug.DrawRay(transform.position, cam.transform.forward * range, RayColor);

        if (Physics.Raycast(rayDirection, out hit, range)) {
            if (hit.collider.gameObject == TurretSocket.TurretSocket) {
                //Debug.Log("RayCastTurret");
                if (!turretOn && !permanentTurretOn) {
                    turretOn = true;
                    Turret = Instantiate(TurretPrefab, new Vector3(TurretSocket.TurretSocket.transform.position.x, TurretSocket.TurretSocket.transform.position.y + 1,
                    TurretSocket.TurretSocket.transform.position.z), new Quaternion(0, 0, 0, 0), TurretSocket.TurretSocket.transform);
                }
                if (Input.GetKey(KeyCode.Mouse0) && !permanentTurretOn) {
                    permanentTurretOn = true;
                    PermanentTurret = Instantiate(TurretPrefab, new Vector3(TurretSocket.TurretSocket.transform.position.x, TurretSocket.TurretSocket.transform.position.y + 1,
                    TurretSocket.TurretSocket.transform.position.z), new Quaternion(0, 0, 0, 0), TurretSocket.TurretSocket.transform);
                    //Debug.Log("OnClick");
                }
            }
        }
        else {
            Destroy(Turret);
            turretOn = false;
        }
    }


}
