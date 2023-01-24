using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun;
using BNG;

namespace BrennanHatton.Networking.Events
{
	
	public class RecieveDamageEvent : MonoBehaviour, IOnEventCallback
	{
		public UnityEvent onReceive; 
		public PhotonView player;
		public Damageable health;
		
		void Reset()
		{
			health = this.GetComponent<Damageable>();
			player = this.GetComponentInParent<PhotonView>();
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
			Debug.Log("RecieveDamageEvent eventCode:" + eventCode);
			
			if(eventCode == SendPVPEventManager.PlayerTakeDamage)
			{
				object[] data = (object[])photonEvent.CustomData;
				int id = (int)data[0];
				int target = (int)data[1];
				int damage = (int)data[2];
				string item= (string)data[3];
				
				Debug.Log("RecieveDamageEvent id:" + id + " targetPlayerId:" + target+" damage:" +damage);
				if(target == player.Owner.ActorNumber)
				{
					health.DealDamage(damage);
				}
				
				onReceive.Invoke();
			}
		}
	}

}