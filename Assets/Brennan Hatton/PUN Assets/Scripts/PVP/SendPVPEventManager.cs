using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

namespace BrennanHatton.Networking.Events
{
	
	public class SendPVPEventManager : MonoBehaviourPunCallbacks
	{
		// If you have multiple custom events, it is recommended to define them in the used class
		public const byte PlayerTakeDamage = 124;
		
		
		public static void SendUpdateHealthEvent(int id, int targetPlayerId, int damage)
		{
			Debug.Log("SendUpdateHealthEvent id:" + id + " targetPlayerId:" + targetPlayerId+" damage:" +damage);
			object[] content = new object[] { id, targetPlayerId, damage }; // Array contains the target position and the IDs of the selected units
			RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All }; // You would have to set the Receivers to All in order to receive this event on the local client as well
			PhotonNetwork.RaiseEvent(PlayerTakeDamage, content, raiseEventOptions, SendOptions.SendReliable);
		}
		
	
	}

}