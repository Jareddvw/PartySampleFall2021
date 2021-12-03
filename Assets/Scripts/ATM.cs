using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ATM : MonoBehaviour {
    public AudioClip[] hitSfx;
    public AudioClip[] explosionSfx;
    public GameObject explosionVfx;
    public GameObject moneyPrefab;
    public int moneyAmount;

    public HealthScript health;
    // Start is called before the first frame update
    private void Awake() {
        health = GetComponent<HealthScript>();
        health.onDmgAction += (vector3, transform1) => PlayHitSfx();
        health.onDeathAction += OnHit;
    }

    private void OnHit(Vector3 dir, Transform from) {
        PlayExplosionVfx();
        var amount = Random.Range(1, moneyAmount + 1);
        for(int i=0; i < amount; i++) Instantiate(moneyPrefab, transform.position + new Vector3(Random.Range(-2.5f,2.5f), Random.Range(-2.5f, 2.5f), 0), moneyPrefab.transform.rotation);
    }

    public void PlayHitSfx() {
        if (hitSfx.Length == 0 || explosionSfx.Length == 0) return;
        var sfx = hitSfx[0];
        sfx = health.hp <= 0 ? explosionSfx[Random.Range(0, explosionSfx.Length)] : hitSfx[Random.Range(0, hitSfx.Length)];
        AudioManager.PlaySFX(sfx, transform.position);
    }
    
    public void PlayExplosionVfx() {
        if (explosionVfx) {
            var explosion = Instantiate(explosionVfx);
            explosion.transform.position = transform.position;
        }
    }
}
