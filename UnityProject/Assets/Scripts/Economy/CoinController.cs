using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    public EconomyManager Player;
    public ParticleSystem Particles;
    public float coinValue;

    void Start() {
        Particles = gameObject.GetComponent<ParticleSystem>();
        Particles.Emit(1);
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
