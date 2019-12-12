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
        Ray rayDirection = new Ray(transform.position, cam.transform.forward);
        Color RayColor = new Color(1, 0, 0, 1);
        Debug.DrawRay(transform.position, cam.transform.forward * range, RayColor);

        if (Physics.Raycast(rayDirection, out hit, range)) {
            if (hit.collider.gameObject == TurretSocket.TurretSocket) {
                //Debug.Log("RayCastTurret");
                if (!turretOn && !permanentTurretOn) {
                    turretOn = true;
                    Vector3 TurretPosition = TurretSocket.TurretSocket.transform.position;
                    //TurretSocket.TurretSocket.transform.position.x
                    Turret = Instantiate(TurretPrefab, new Vector3(TurretPosition.x, TurretPosition.y + 1,
                    TurretPosition.z), new Quaternion(0, 0, 0, 0), TurretSocket.TurretSocket.transform);
                    Debug.Log("TemporallyTurret");
                } if (Input.GetKey(KeyCode.Mouse0) && !permanentTurretOn) {
                    permanentTurretOn = true;
                    Vector3 TurretPosition = TurretSocket.TurretSocket.transform.position;
                    PermanentTurret = Instantiate(TurretPrefab, new Vector3(TurretPosition.x, TurretPosition.y + 1,
                    TurretPosition.z), new Quaternion(0, 0, 0, 0), TurretPrefab.transform);
                    Destroy(TurretSocket.TurretSocket);
                    permanentTurretOn = false;
                    turretOn = false;
                    Debug.Log("PermanentTurret");
                }
            }
        } else {
            Destroy(Turret);
            turretOn = false;
        }
    }
}
