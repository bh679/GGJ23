using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityLibrary;

namespace BrennanHatton.Networking.Events
{
	
	public class SendNarrationEvent : MonoBehaviour
	{	
			
		public void SendNarrationEventPlz(string text)
		{
			SendNarrationEventManager.SendNarrationTextEvent(text);
		}
	
	}

}
