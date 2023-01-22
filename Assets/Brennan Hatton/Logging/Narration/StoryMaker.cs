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
	public class StoryMaker : MonoBehaviour
	{
		public GPT3 GPTAPI;
		public ActionLogger logger;
		public TextAsset initalPrompt, followupPrompts, introduction, questions;
		
		
		
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
			GPTAPI.Execute(introduction.text);
		}
		
		public void NarrateActions()
		{
			GPTAPI.Execute(initalPrompt.text +/* GetStorySoFar() + */"{"+logger.GetString()+"}");
			logger.actions = new List<LogAction>();
			logger.output = "";
		}
		
		public void AskQuestion()
		{
			GPTAPI.Execute(questions.text);
		}

		

	}
}
