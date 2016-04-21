﻿using UnityEngine;
using System.Collections;
using multi;
using System.Collections.Generic;
public class BodyScript : MonoBehaviour {
	ClientServer clientServer;
	public string name = "";
	Rigidbody body;
	void Start () {
		clientServer = GameObject.FindGameObjectWithTag("ClientServer").GetComponent<ClientServer>();
	}
	void Update () {
		foreach (multi.MultiplayerHandler.PlayerData data in clientServer.multiplayerHandler.playerDB) {
			if (data.name == name) {
				body = gameObject.GetComponent<Rigidbody> ();
				body.MovePosition (new Vector3 ((float)data.posX, (float)data.posY, (float)data.posZ));

				//body.MoveRotation (new Quaternion (0f, (float)clientServer.multiplayerHandler.recD, 0f, 0f));

				Quaternion rot = new Quaternion ();
				rot.eulerAngles = new Vector3 (0, (float)data.angleY, 0);
				gameObject.transform.rotation = rot;
				gameObject.GetComponent<Animator> ().SetBool ("IsWalking", data.IsWalking);
				gameObject.GetComponentInChildren<GunAnimation> ().isShooting = data.IsShooting;             }
		}
	}
}