﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour {

	public AudioSource source;
	public AudioClip clip;

	public void Awake() {
		source = GetComponent<AudioSource> ();
	}

	public void OnCollisionEnter(Collision other) {
		source.Play ();
	}
}
