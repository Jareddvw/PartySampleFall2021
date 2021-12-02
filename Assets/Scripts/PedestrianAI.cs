using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Rigidbody2D))]
public class PedestrianAI : MonoBehaviour {

	public AudioClip[] hitSfx;
	public AudioClip[] deathSfx;

	public float decisionInterval = .5f;
	public float runawaySpeed = 5f;
	public float calmDistance = 15f;

	public Rigidbody2D rigidbody;
	public SimpleWalk walk;
	public HealthScript health;
	public CrimeManager crimeManager;

	public bool dead;
	public bool runaway;
	public Transform from;
	public Vector3 direction;
	public float lastDecisionTime;

	public GameObject bloodSplash;
	public ParticleSystem bloodPlayer;
	public SpriteRenderer sprite;
	public Color originalColor;
	public Color panicColor;
	public GameObject corpse;
	
	private void Awake() {
		rigidbody = GetComponent<Rigidbody2D>();
		walk = GetComponent<SimpleWalk>();
		health = GetComponent<HealthScript>();
		if (health) {
			health.onDmgAction += OnHit;
			health.onDeathAction += (dir, tf) => {
				rigidbody.velocity = Vector2.zero;
				walk.enabled = false;
				if (corpse) Instantiate(corpse, transform.position, Quaternion.identity);
			};
		}

		if (sprite) {
			originalColor = sprite.color;
		}

		if (!crimeManager) crimeManager = GetComponent<CrimeManager>();
		if (crimeManager) {
			crimeManager.onCrimeHappen += Frighten;
		}
	}

	public void Update() {
		if (dead || !runaway || !from) {
			return;
		}
		
		var disp = transform.position - from.position;
		var dist = disp.magnitude;
		if (dist >= calmDistance) {
			runaway = false;
			from = null;
			if (walk) walk.enabled = true;
			if (sprite) sprite.color = originalColor;
		}
		var time = Time.timeSinceLevelLoad;
		if (time - lastDecisionTime >= decisionInterval) {
			lastDecisionTime = time;
			direction = disp / dist;
		}

		rigidbody.velocity = direction * runawaySpeed;
	}

	public void OnHit(Vector3 dir, Transform from) {
		// Debug.Log(transform.position.ToString("F3"));
		// bloodPlayer.Play();
		PlayBloodSplash(transform.position);
		PlayHitSfx();
		Frighten(dir, from);
	}

	public void Frighten(Vector3 dir, Transform from) {
		runaway = true;
		this.from = from;
		walk.enabled = false;
		direction = (transform.position - from.position).normalized;
		lastDecisionTime = Time.timeSinceLevelLoad;
		if (sprite) sprite.color = panicColor;
	}

	public void PlayBloodSplash(Vector3 position) {
		if (!bloodSplash) return;
		GameObject splash = Instantiate(bloodSplash);
		splash.transform.position = position;
		splash.GetComponent<ParticleSystem>()?.Play();
	}

	public void PlayHitSfx() {
		if (hitSfx.Length == 0 || deathSfx.Length == 0) return;
		var sfx = hitSfx[0];
		sfx = health.hp <= 0 ? deathSfx[Random.Range(0, deathSfx.Length)] : hitSfx[Random.Range(0, hitSfx.Length)];
		AudioManager.PlaySFX(sfx, transform.position);
	}
}
