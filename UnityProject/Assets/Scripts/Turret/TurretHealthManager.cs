using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretHealthManager : MonoBehaviour
{
    public Slider HealthBar;
    public float totalHealth;
    float curHealth;
    public float armor;

    void Start() {
        HealthBar = GetComponentInChildren<Slider>();
        curHealth = totalHealth;
    }

    void Update(){

        if (curHealth <= 0) {
            Destroy(gameObject);
        }
    }

    public void HealthUpdate(float EnemyDamage) {
        EnemyDamage -= armor;
        curHealth -= EnemyDamage;
        HealthBar.value = curHealth;
    }
}
