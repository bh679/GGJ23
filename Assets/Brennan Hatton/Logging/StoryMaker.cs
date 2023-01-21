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
		const string url = "https://api.openai.com/v1/completions";

		public string modelName = "text-davinci-003";

		public InputField inputPrompt;
		public ActionLogger logger;
		public InputField inputResults;
		public GameObject loadingIcon;
		public TextAsset apiKeytext;
		public TextAsset initalPrompt, followupPrompts;
		string _prompt;
		public string Prompt{
			get{
				return _prompt;
			}
		}

		string apiKey = null;
		bool isRunning = false;
		
		
		public List<string> results = new List<string>();
		public string GetRecentResults(int n)
		{
			string output = "";
			for(int i = 0; i < Mathf.Min(results.Count,n); i++)
			{
				output += results[i];
			}
			
			return output;
		}
		
		public string GetStorySoFar()
		{
			string output = "";
			
			if(results.Count > 0)
				output = "The story so far has been: " + GetRecentResults(3) + followupPrompts.text;
				
			Debug.LogError(output);
				
			return output;
		}
		
		
		void Start()
		{
			_prompt = initalPrompt.text;
			LoadAPIKey();
		}

		public void Execute()
		{
			if (isRunning)
			{
				Debug.LogError("Already running");
				return;
			}
			isRunning = true;
			loadingIcon.SetActive(true);
            
			// fill in request data
			RequestData requestData = new RequestData()
			{
				model = modelName,
				prompt = _prompt + GetStorySoFar() + "{"+logger.GetString()+"}",
				temperature = 0.7f,
				max_tokens = 256,
				top_p = 1,
				frequency_penalty = 0,
				presence_penalty = 0
            };
			Debug.Log(requestData.prompt);
            
			inputPrompt.text = requestData.prompt;

			string jsonData = JsonUtility.ToJson(requestData);

			byte[] postData = System.Text.Encoding.UTF8.GetBytes(jsonData);

			UnityWebRequest request = UnityWebRequest.Post(url, jsonData);
			request.uploadHandler = new UploadHandlerRaw(postData);
			request.downloadHandler = new DownloadHandlerBuffer();
			request.SetRequestHeader("Content-Type", "application/json");
			request.SetRequestHeader("Authorization", "Bearer " + apiKey);

			UnityWebRequestAsyncOperation async = request.SendWebRequest();

			async.completed += (op) =>
			{
				if (request.result == UnityWebRequest.Result.ConnectionError)
				{
					Debug.LogError(request.error);
				}
				else
				{
					Debug.Log(request.downloadHandler.text);
					// parse the results to get values 
					OpenAIAPI responseData = JsonUtility.FromJson<OpenAIAPI>(request.downloadHandler.text);
					// sometimes contains 2 empty lines at start?
					string generatedText = responseData.choices[0].text.TrimStart('\n').TrimStart('\n');

					inputResults.text = generatedText;
					results.Insert(0,generatedText);
				}
				loadingIcon.SetActive(false);
				isRunning = false;
			};
			
			//_prompt += followupPrompts.text;

		} // execute

		void LoadAPIKey()
		{
			// TODO optionally use from env.variable

			// MODIFY path to API key if needed
			/*var keypath = Path.Combine(Application.streamingAssetsPath, "secretkey.txt");
			if (File.Exists(keypath) == false)
			{
			Debug.LogError("Apikey missing: " + keypath);
			}

			//Debug.Log("Load apikey: " + keypath);
			apiKey = File.ReadAllText(keypath).Trim();*/
			apiKey = apiKeytext.text;
			Debug.Log("API key loaded, len= " + apiKey.Length);
		}
	}
}
