using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceTurret : MonoBehaviour
{
    public GameObject TemporallyTurretPrefab;
    public GameObject PermanentTurretPrefab;
    GameObject TurretsContainer;
    public TurretSocketCollider TurretSocket;
    public EconomyManager Economy;
    GameObject Turret;
    GameObject PermanentTurret;

    public bool turretOn;
    public bool permanentTurretOn;
    public float range = 10f;
    public float cost;

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

                TurretsContainer = hit.collider.transform.parent.gameObject;

                if (!turretOn && !permanentTurretOn) {
                    turretOn = true;
                    Vector3 TurretPosition = TurretSocket.TurretSocket.transform.position;

                    Turret = Instantiate(TemporallyTurretPrefab, new Vector3(TurretPosition.x, TurretPosition.y + 1f,
                    TurretPosition.z), Quaternion.identity, TurretSocket.TurretSocket.transform);

                    Turret.SetActive(true);

                    Economy.ShowCost(cost);

                }

                if (Input.GetKey(KeyCode.Mouse1) && !permanentTurretOn && Economy.money >= cost) {
                    permanentTurretOn = true;
                    Vector3 TurretPosition = TurretSocket.TurretSocket.transform.position;

                    PermanentTurret = Instantiate(PermanentTurretPrefab, new Vector3(TurretPosition.x, TurretPosition.y + 1f,
                    TurretPosition.z), Quaternion.identity, TurretsContainer.transform);

                    PermanentTurret.transform.localScale = TurretSocket.TurretSocket.transform.localScale;

                    PermanentTurret.SetActive(true);

                    Economy.RemoveMoney(cost);
                    Economy.RemoveShowCost();

                    Destroy(TurretSocket.TurretSocket);
                    permanentTurretOn = false;
                    turretOn = false;
                }
            }
        } else {
            Economy.RemoveShowCost();
            Destroy(Turret);
            turretOn = false;
        }
    }
}
