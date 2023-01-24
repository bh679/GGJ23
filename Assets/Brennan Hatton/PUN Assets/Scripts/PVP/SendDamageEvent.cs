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
		public DamageableEvents damageable;
		public int multiplier = 1;
		public bool dontChangeDmanagebale = true;
		
		void Reset()
		{
			damageable = this.GetComponent<DamageableEvents>();
			player = this.GetComponentInParent<PhotonView>();
		}
		
		void Start()
		{
			damageable.onDamagedDetails.AddListener(SendUpdateHealthEvent);//add send healthe event
		}
		
		public void SendUpdateHealthEvent(float damage, GameObject item)
		{
			SendPVPEventManager.SendUpdateHealthEvent(player.Owner.ActorNumber, (int)damage*multiplier, item.name);
			
			if(dontChangeDmanagebale)
				damageable.Health += damage;
		}
	}

}
