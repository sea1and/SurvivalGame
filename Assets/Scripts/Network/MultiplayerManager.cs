using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using multi;
public class MultiplayerManager : MonoBehaviour
{	
	bool isHereAnotherPlayerSpawned = false;

	ClientServer clientServer;
	public string nick = "";
	public GameObject bodyPrefab;
	GameObject player;
	double one = 0;
	ArrayList temp = new ArrayList();

	void Start() 
	{
		clientServer = GameObject.FindGameObjectWithTag("ClientServer").GetComponent<ClientServer>();
		clientServer.Init (nick);
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update()
	{
		temp = clientServer.GetSessions();
		if (clientServer.HasJoinedSession())
		{
			clientServer.SendPlayerData (nick, (double)player.transform.position.x, (double)player.transform.position.y, (double)player.transform.position.z, (double)player.transform.rotation.eulerAngles.y, player.GetComponent<Animator>().GetBool("IsWalking"), player.GetComponentInChildren<PlayerShooting>().isShooting);
		}

		if (clientServer.GetSessions().Count > 0)
		{
			string name = clientServer.FoundNameToNick((string)temp[0]);
			if (!clientServer.HasJoinedSession())
			{
				clientServer.JoinSession((string)temp[0]);
			}

		}

		if (!isHereAnotherPlayerSpawned) {
			if (clientServer.multiplayerHandler.receivedName != "") {
				Quaternion rotat = new Quaternion();
				rotat.eulerAngles = new Vector3(0, (float)clientServer.multiplayerHandler.recD, 0);
				Instantiate (bodyPrefab, new Vector3 ((float)clientServer.multiplayerHandler.recA, (float)clientServer.multiplayerHandler.recB, (float)clientServer.multiplayerHandler.recC), rotat);
				isHereAnotherPlayerSpawned = true;
			}
		} 
		else {
				
			Rigidbody body;
			body = GameObject.FindGameObjectWithTag ("Body").GetComponent<Rigidbody>();
			body.MovePosition (new Vector3 ((float)clientServer.multiplayerHandler.recA, (float)clientServer.multiplayerHandler.recB, (float)clientServer.multiplayerHandler.recC));

			//body.MoveRotation (new Quaternion (0f, (float)clientServer.multiplayerHandler.recD, 0f, 0f));
			GameObject Body;
			Body = GameObject.FindGameObjectWithTag ("Body");

			Quaternion rot = new Quaternion();
			rot.eulerAngles = new Vector3(0, (float)clientServer.multiplayerHandler.recD, 0);
			Body.transform.rotation = rot;
			Body.GetComponent<Animator> ().SetBool ("IsWalking", clientServer.multiplayerHandler.IsWalking);
			Body.GetComponentInChildren<GunAnimation> ().isShooting = clientServer.multiplayerHandler.IsShooting;
		}
	
	}
}