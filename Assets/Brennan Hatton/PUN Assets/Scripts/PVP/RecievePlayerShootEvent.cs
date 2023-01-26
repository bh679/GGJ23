using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun;
using BNG;

namespace BrennanHatton.Networking.Events
{
	
	public class RecievePlayerShootEvent : MonoBehaviour, IOnEventCallback
	{
		
		public PhotonView playerView;
		public AudioSource source;
		public bool fromMe = false;
		
		void Reset()
		{
			source = this.GetComponentInChildren<AudioSource>();
			playerView = this.GetComponentInParent<PhotonView>();
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
			
			if(eventCode == SendPVPEventManager.PlayerShoot)
			{
				object[] data = (object[])photonEvent.CustomData;
				int id = (int)data[0];
				int gunId = (int)data[1];
				Vector3 position = (Vector3)data[2];
				Quaternion rotation = (Quaternion)data[3];
				
				if(playerView.OwnerActorNr == id || fromMe)
				{
					if(GunNetworkManager.Instance.weapons[gunId].fireSound != null)
						source.PlayOneShot(GunNetworkManager.Instance.weapons[gunId].fireSound);
				}
			}else if(eventCode == SendPVPEventManager.PlayerShotHit)
			{
				object[] data = (object[])photonEvent.CustomData;
				int id = (int)data[0];
				int gunId = (int)data[1];
				Vector3 position = (Vector3)data[2];
				Quaternion rotation = (Quaternion)data[3];
				
				if(playerView.OwnerActorNr == id || fromMe)
				{
					
					if(GunNetworkManager.Instance.weapons[gunId].hit != null)
					{
						GameObject impact = Instantiate(GunNetworkManager.Instance.weapons[gunId].hit, position, rotation) as GameObject;
					}
				}
			}
		}
	}
}