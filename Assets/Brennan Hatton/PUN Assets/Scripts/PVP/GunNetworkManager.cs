using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.Networking.Events
{	
	public enum GunId
	{
		Pistol = 0,
		BannanaGun = 1,
		Rifle = 2,
		Shotgun = 3,
		Bow = 4
	}

	public class GunNetworkManager : MonoBehaviour
	{
		
		[System.Serializable]
		public class WeaponNetworkEvent
		{
			public GunId id;
			public GameObject hit;
			public AudioClip fireSound;
			public GameObject projectile;
			public float shootForce;
		}
		
		public WeaponNetworkEvent[] weapons;
		
		void Reset()
		{
			weapons = new WeaponNetworkEvent[5];
			for(int i = 0 ;i < weapons.Length; i++)
			{
				weapons[i].id = (GunId)i;
			}
		}
		
		//Singlton
		public static GunNetworkManager Instance { get; private set; }
		private void Awake() 
		{ 
			// If there is an instance, and it's not me, delete myself.
		    
			if (Instance != null && Instance != this) 
			{ 
				Destroy(this); 
			} 
			else 
			{ 
				Instance = this; 
			} 
		}
	}
}