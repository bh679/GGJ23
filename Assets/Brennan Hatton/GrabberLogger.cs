﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

namespace BrennanHatton.Logging
{
	public class GrabberLogger : MonoBehaviour
	{
		public Grabber grabber;
		public string handSide;
		
		void Reset()
		{
			grabber = this.GetComponent<Grabber>();
			handSide = grabber.HandSide.ToString() + " hand";
				
		}
		
		void Start()
		{
			grabber.onGrabEvent.AddListener(OnGrab);
			grabber.onReleaseEvent.AddListener(OnRelease);
		}
	
		public void OnGrab(Grabbable grabbable) {
			Debug.LogError("Grab Log");
			LogAction log = new LogAction();
			log.did = "Grabbed";
			log.what = grabbable.name;
			log.with = handSide;
			ActionLogger.Instance.Add(log);
		}

		public void OnRelease(Grabbable grabbable) {

			LogAction log = new LogAction();
			log.did = "Released";
			log.what = grabbable.name;
			log.with = handSide;
			
			ActionLogger.Instance.Add(log);
		}
	}
	
}