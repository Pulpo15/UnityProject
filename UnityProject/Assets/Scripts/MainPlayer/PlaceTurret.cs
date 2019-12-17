using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTurret : MonoBehaviour
{
    public GameObject TemporallyTurretPrefab;
    public GameObject PermanentTurretPrefab;
    public GameObject TurretsContainer;
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
                if (!turretOn && !permanentTurretOn) {
                    turretOn = true;
                    Vector3 TurretPosition = TurretSocket.TurretSocket.transform.position;

                    Turret = Instantiate(TemporallyTurretPrefab, new Vector3(TurretPosition.x, TurretPosition.y + 1.8f,
                    TurretPosition.z), Quaternion.identity, TurretSocket.TurretSocket.transform);

                    Turret.SetActive(true);

                } if (Input.GetKey(KeyCode.Mouse0) && !permanentTurretOn) {
                    permanentTurretOn = true;
                    Vector3 TurretPosition = TurretSocket.TurretSocket.transform.position;

                    PermanentTurret = Instantiate(PermanentTurretPrefab, new Vector3(TurretPosition.x, TurretPosition.y + 1.8f,
                    TurretPosition.z), Quaternion.identity, TurretsContainer.transform);

                    PermanentTurret.SetActive(true);

                    Destroy(TurretSocket.TurretSocket);
                    permanentTurretOn = false;
                    turretOn = false;
                }
            }
        } else {
            Destroy(Turret);
            turretOn = false;
        }
    }
}
