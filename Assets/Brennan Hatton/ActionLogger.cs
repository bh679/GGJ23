using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.Logging
{
	[System.Serializable]
	public class LogAction
	{
		public string who = "Player", did, what, with, when;
		
		public LogAction()
		{
			when = Time.time.ToString();
		}
		
		public string GetString()
		{
			who + " " + did + " " + what + " with " + with + " at " + when;
		}
	}

	public class ActionLogger : MonoBehaviour
	{
		public List<LogAction> actions;
		public string output;
		
		//Singlton
		public static ActionLogger Instance { get; private set; }
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
		
		public void Add(LogAction log)
		{
			actions.Add(log);
			output += log.GetString();
		}
		
		public string GetString()
		{
			return output;/*
			
			string returnVal = "";
			for(int i = 0; i < actions.Count; i++)
				returnVal += actions[i].GetString() + "\n then ";
			return returnVal;*/
		}
	}
}