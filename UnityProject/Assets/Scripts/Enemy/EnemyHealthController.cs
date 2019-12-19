using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour {

    public Slider HealthBar;
    public GameObject Coin;
    public float totalHealth;
    float curHealth;
    public float armor;

    void Start() {
        HealthBar = GetComponentInChildren<Slider>();
        curHealth = totalHealth;
    }

    void Update(){

        if (curHealth <= 0) {
            GameObject NewCoin;
            NewCoin = Instantiate(Coin, transform.position, Quaternion.identity);
            NewCoin.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void HealthUpdate(float bulletDamage) {
        bulletDamage -= armor;
        curHealth -= bulletDamage;
        HealthBar.value = curHealth;
    }
}
