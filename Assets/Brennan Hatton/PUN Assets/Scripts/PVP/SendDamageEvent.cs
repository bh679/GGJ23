using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using BNG;

namespace BrennanHatton.Networking.Events
{
	
	public class SendDamageEvent : MonoBehaviour
	{
		public PhotonView player;
		public Damageable damageable;
		public int multiplier = 1;
		public bool dontChangeDmanagebale = true;
		
		void Reset()
		{
			damageable = this.GetComponent<Damageable>();
			player = this.GetComponentInParent<PhotonView>();
		}
		
		void Start()
		{
			damageable.onDamaged.AddListener(SendUpdateHealthEvent);//add send healthe event
		}
		
		public void SendUpdateHealthEvent(float damage)
		{
			SendPVPEventManager.SendUpdateHealthEvent(PhotonNetwork.LocalPlayer.ActorNumber, player.Owner.ActorNumber, (int)damage*multiplier);
			
			if(dontChangeDmanagebale)
				damageable.Health += damage;
		}
	}

}
