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
	
	public class SendAudioStream : MonoBehaviourPunCallbacks
	{
		public SpeechManager speechManager;
		
		// If you have multiple custom events, it is recommended to define them in the used class
		public const byte PlayerTakeDamage = 124;
		
		void Update()
		{
			//make it autosend
		}
		
		public static void SendStreamEvent(int id, Stream audioStream)
		{
			Debug.Log("SendUpdateHealthEvent id:" + id + " audioStream:" + audioStream);
			object[] content = new object[] { id, audioStream}; // Array contains the target position and the IDs of the selected units
			RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All }; // You would have to set the Receivers to All in order to receive this event on the local client as well
			PhotonNetwork.RaiseEvent(PlayerTakeDamage, content, raiseEventOptions, SendOptions.SendReliable);
		}
		
	
	}

}