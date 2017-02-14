﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
	private float speed = -0.2f; //キューブの移動速度
	private float deadLine=-10; //消滅位置

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//キューブを移動する
		transform.Translate (this.speed, 0, 0);
		//画面外に出たら破棄する
		if (transform.position.x < this.deadLine) {
			Destroy (gameObject);
		}	
	}
	//衝突時に呼ばれる関数
		void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "boxTag"||other.gameObject.tag == "GroundTag") {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
		}
	}

	}
