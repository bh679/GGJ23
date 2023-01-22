// sample code by unitycoder.com
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityLibrary;

namespace BrennanHatton.Logging
{
	[System.Serializable]
	public class Narrrator
	{
		public string name;
		public TextAsset initalPrompt, followupPrompts, introduction, questions;
	}
	
	public class StoryMaker : MonoBehaviour
	{
		public GPT3 GPTAPI;
		public ActionLogger logger;
		public Narrrator[] narrators;
		public int id;
		
		
		
		/*public string GetStorySoFar()
		{
			string output = "";
			
			if(results.Count > 0)
				output = "The narration so far has been: " + GetRecentResults(3) + followupPrompts.text;
				
			Debug.LogError(output);
				
			return output;
		}*/
		
		public void Introduction()
		{
			GPTAPI.Execute(narrators[id].introduction.text);
		}
		
		public void NarrateActions()
		{
			GPTAPI.Execute(narrators[id].initalPrompt.text +/* GetStorySoFar() + */"{"+logger.GetString()+"}");
			logger.actions = new List<LogAction>();
			logger.output = "";
		}
		
		public void AskQuestion()
		{
			GPTAPI.Execute(narrators[id].questions.text);
		}

		

	}
}
