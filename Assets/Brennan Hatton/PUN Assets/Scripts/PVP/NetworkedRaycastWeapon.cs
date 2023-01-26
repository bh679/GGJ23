using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

namespace BrennanHatton.Networking.Events
{
	
	public class NetworkedRaycastWeapon : MonoBehaviour
	{	
		public RaycastWeapon weapon;
		
		public GunId gunId;
		
		void Reset()
		{
			weapon	= this.GetComponent<RaycastWeapon>();
		}
		
		void Start()
		{
			weapon.onShootEvent.AddListener(SendShootEvent);
			weapon.onRaycastHitEvent.AddListener(SendHitEvent);
		}
		
		void SendShootEvent()
		{
			SendPVPEventManager.SendPlayerShoot((int)gunId, weapon.EjectPointTransform.position, weapon.EjectPointTransform.rotation);
		}
		
		void SendHitEvent(RaycastHit hit)
		{
			SendPVPEventManager.SendPlayerShoot((int)gunId, hit.point, Quaternion.EulerAngles(hit.normal));
		}
	}
}