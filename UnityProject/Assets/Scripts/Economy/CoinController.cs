using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    public EconomyManager Player;
    public float coinValue;

    void Start() {

    }

    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Player.AddMoney(coinValue);
            Destroy(gameObject);
        }
    }

}
