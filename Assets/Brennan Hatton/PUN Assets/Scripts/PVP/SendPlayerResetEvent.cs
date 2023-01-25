using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace BrennanHatton.Networking.Events
{
	
	public class SendPlayerResetEvent : MonoBehaviour
	{
		public void SendPlayerResetEventPlz()
		{
			SendPVPEventManager.SendPlayerResetEvent();
		}
	}

}
