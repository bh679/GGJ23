using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun;
using BNG;
using EqualReality.Networking;

namespace BrennanHatton.Networking.Events
{
	
	public class ReceivePlayerResetEventForScene : MonoBehaviour, IOnEventCallback
	{
		public UnityEvent onReceive;
		public PlayerSpawnPosition spawner;
		
		void Reset()
		{
			spawner = GameObject.FindObjectOfType<PlayerSpawnPosition>();
		}
		
		private void OnEnable()
		{
			PhotonNetwork.AddCallbackTarget(this);
		}
	
		private void OnDisable()
		{
			PhotonNetwork.RemoveCallbackTarget(this);
		}
	
		public void OnEvent(EventData photonEvent)
		{
			byte eventCode = photonEvent.Code;
			
			if(eventCode == SendPVPEventManager.PlayerResetEventCode)
			{
				object[] data = (object[])photonEvent.CustomData;
				int id = (int)data[0];
				
				//Debug.Log("RecieveDamageEvent id:" + id + " targetPlayerId:" + target+" damage:" +damage);
				if(id == PhotonNetwork.LocalPlayer.ActorNumber)
				{
					spawner.SetPosition();
					onReceive.Invoke();
				}
				
			}
		}
	}

}