using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

namespace BrennanHatton.Networking.Events
{
	
	public class SendAudioStreamEventManager : MonoBehaviourPunCallbacks
	{
		// If you have multiple custom events, it is recommended to define them in the used class
		public const byte SteamEventCode = 124;
		
		
		public static void SendUpdateHealthEvent(Stream audioStream)
		{
			Debug.Log("SendUpdateHealthEvent id:" + PhotonNetwork.LocalPlayer.ActorNumber + " audioStream:" + audioStream);
			object[] content = new object[] { PhotonNetwork.LocalPlayer.ActorNumber, audioStream }; // Array contains the target position and the IDs of the selected units
			RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All }; // You would have to set the Receivers to All in order to receive this event on the local client as well
			PhotonNetwork.RaiseEvent(SteamEventCode, content, raiseEventOptions, SendOptions.SendReliable);
		}
		
	
	}

}