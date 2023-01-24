using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BrennanHatton.Logging
{

	/// <summary>
	/// A UnityEvent with a float as a parameter
	/// </summary>
	[System.Serializable]
	public class LogEvent : UnityEvent<LogAction> { }
	
	[System.Serializable]
	public enum Importance
	{
		Critical,
		Important,
		SlightlyImportant,
		Unimportant,
	}
	
	[System.Serializable]
	public class LogAction
	{
		public string who = "Player", did, what, with, when;
		public Importance importance = Importance.SlightlyImportant;
		
		public LogAction()
		{
			when = Time.time.ToString();
			when = when.Substring(0, when.LastIndexOf(".")+2);
		}
		
		public string GetString()
		{
			return "("+importance.ToString() +") "+ who + " " + did + " " + what + (with==""?"":" with " + with) + " at " + when;
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
			output += log.GetString() + "\n";
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