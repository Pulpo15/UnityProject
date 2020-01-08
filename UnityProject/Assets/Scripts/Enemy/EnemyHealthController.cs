using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour {

    public Slider HealthBar;
    public GameObject Coin;
    
    public Text RemainingEnemiesText;
    public float totalHealth;
    float curHealth;
    public float armor;
    int remainignEnemies;

    void Start() {
        HealthBar = GetComponentInChildren<Slider>();
        curHealth = totalHealth;
        
    }

    void Update(){
        if (curHealth <= 0) {
            GameObject NewCoin;
            NewCoin = Instantiate(Coin, transform.position, Quaternion.identity);
            NewCoin.transform.position = new Vector3(transform.position.x, transform.position.y -0.5f, transform.position.z);
            NewCoin.SetActive(true);
            remainignEnemies = int.Parse(RemainingEnemiesText.text);
            remainignEnemies--;
            RemainingEnemiesText.text = remainignEnemies.ToString();
            
            Destroy(gameObject);
        }
    }

    public void HealthUpdate(float bulletDamage) {
        bulletDamage -= armor;
        curHealth -= bulletDamage;
        HealthBar.value = curHealth;
    }
}
