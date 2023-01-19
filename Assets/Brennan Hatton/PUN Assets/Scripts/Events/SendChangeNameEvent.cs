using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.Networking.Events
{
	
	public class SendChangeNameEvent : MonoBehaviour
	{
		public void SendNameChangeEvent()
		{
			SendEventManager.SendNameChangeEvent();
		}
	}

}