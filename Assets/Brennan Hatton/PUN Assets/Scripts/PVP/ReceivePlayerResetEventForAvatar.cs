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
	
	public class ReceivePlayerResetEventForAvatar : MonoBehaviour, IOnEventCallback
	{
		public UnityEvent onReceive; 
		public PhotonView player;
		public Damageable health;
		public ScrollbarHealthbar healthBar;
		
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
			
			if(eventCode == SendPVPEventManager.PlayerResetEventCode)
			{
				object[] data = (object[])photonEvent.CustomData;
				int id = (int)data[0];
				
				//Debug.Log("RecieveDamageEvent id:" + id + " targetPlayerId:" + target+" damage:" +damage);
				if(id == player.Owner.ActorNumber)
				{
					health.Health = 100f;
					healthBar.UpdateHealth(100f);
					onReceive.Invoke();
				}
				
			}
		}
	}

}