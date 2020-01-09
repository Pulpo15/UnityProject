using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretHealthManager : MonoBehaviour
{
    public Slider HealthBar;
    public GameObject TurretSocket;
    public float totalHealth;
    public float curHealth;
    public float armor;


    void Start() {
        HealthBar = GetComponentInChildren<Slider>();
        curHealth = totalHealth;
    }

    void Update(){

        HealthBar.value = curHealth;

        if (curHealth <= 0) {
            GameObject NewTurretSocket = Instantiate(TurretSocket, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y -1f, 
            gameObject.transform.position.z), Quaternion.identity, gameObject.transform.parent);

            NewTurretSocket.transform.localScale = gameObject.transform.localScale;
            NewTurretSocket.SetActive(true);

            Destroy(gameObject);
        }
    }

    public void HealthUpdate(float EnemyDamage) {
        EnemyDamage -= armor;
        curHealth -= EnemyDamage;
        HealthBar.value = curHealth;
    }
}
