using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
	
	public string PlayerPrebName = "Network Player";
	public static List<PhotonView> spawnedPlayerPrefabs = new List<PhotonView>();
	
	public override void OnJoinedRoom()
	{
		
		base.OnJoinedRoom();
		spawnedPlayerPrefabs.Add(PhotonNetwork.Instantiate(PlayerPrebName, transform.position, transform.rotation).GetComponent<PhotonView>());
	}
	
	public override void OnLeftRoom()
	{
		base.OnLeftRoom();
		
		for (int i = 0; i < spawnedPlayerPrefabs.Count; i++)
		{
			if(spawnedPlayerPrefabs[i] != null)
				PhotonNetwork.Destroy(spawnedPlayerPrefabs[i].gameObject);
		}
	}
}
