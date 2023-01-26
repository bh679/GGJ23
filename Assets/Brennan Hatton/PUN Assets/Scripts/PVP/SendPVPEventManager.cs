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
		public const byte PlayerTakeDamage = 124,
		PlayerResetEventCode = 125,
		PlayerShotHit = 126,
		PlayerShoot = 126;
		
		
		public static void SendUpdateHealthEvent(int targetPlayerId, int damage, string item)
		{
			Debug.Log("SendUpdateHealthEvent id:" + PhotonNetwork.LocalPlayer.ActorNumber + " targetPlayerId:" + targetPlayerId+" damage:" +damage);
			object[] content = new object[] { PhotonNetwork.LocalPlayer.ActorNumber, targetPlayerId, damage, item }; // Array contains the target position and the IDs of the selected units
			RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All }; // You would have to set the Receivers to All in order to receive this event on the local client as well
			PhotonNetwork.RaiseEvent(PlayerTakeDamage, content, raiseEventOptions, SendOptions.SendReliable);
		}
		
		public static void SendPlayerResetEvent()
		{
			Debug.Log("SendPlayerResetEvent id:" + PhotonNetwork.LocalPlayer.ActorNumber );
			object[] content = new object[] { PhotonNetwork.LocalPlayer.ActorNumber }; // Array contains the target position and the IDs of the selected units
			RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All }; // You would have to set the Receivers to All in order to receive this event on the local client as well
			PhotonNetwork.RaiseEvent(PlayerResetEventCode, content, raiseEventOptions, SendOptions.SendReliable);
		}
		
		public static void SendPlayerShotHit(int gunId, Vector3 position, Quaternion rotation)
		{
			Debug.Log("SendPlayerShotHit id:" + PhotonNetwork.LocalPlayer.ActorNumber );
			object[] content = new object[] { PhotonNetwork.LocalPlayer.ActorNumber, gunId, position, rotation }; // Array contains the target position and the IDs of the selected units
			RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All }; // You would have to set the Receivers to All in order to receive this event on the local client as well
			PhotonNetwork.RaiseEvent(PlayerShotHit, content, raiseEventOptions, SendOptions.SendReliable);
		}
		
		public static void SendPlayerShoot(int gunId, Vector3 position, Quaternion rotation)
		{
			Debug.Log("SendPlayerShoot id:" + PhotonNetwork.LocalPlayer.ActorNumber );
			object[] content = new object[] { PhotonNetwork.LocalPlayer.ActorNumber, gunId, position, rotation }; // Array contains the target position and the IDs of the selected units
			RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All }; // You would have to set the Receivers to All in order to receive this event on the local client as well
			PhotonNetwork.RaiseEvent(PlayerShoot, content, raiseEventOptions, SendOptions.SendReliable);
		}
	
	}

}