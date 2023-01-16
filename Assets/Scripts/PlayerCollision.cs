using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public GameObject deathEffect;

	private AudioSource audioSource;
	private PlayerController playerController;

	void Start() {
		audioSource = this.GetComponent<AudioSource>(); 
		playerController = this.GetComponent<PlayerController>();
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.collider.tag == "Meteor")
		{
			Instantiate(deathEffect, this.transform.position, this.transform.rotation);
			PlayerController movement = this.GetComponent<PlayerController>();
			GameManager.instance.EndGame();
			playerController.isDead = true;

			AudioManager.instance.Play("PlayerDeath");

			Destroy(gameObject);
		}
	}

}
