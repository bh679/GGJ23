using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BNG;

namespace BrennanHatton.Logging
{
	
	public class DamageableWithLogging : Damageable
	{
		
		[Header("Events")]
		[Tooltip("Optional Event to be called when receiving damage. Takes damage amount as a float parameter.")]
		public LogEvent onDamagedLog;
	
		[Tooltip("Optional Event to be called once health is <= 0")]
		public LogEvent onDestroyedLog;
	
		[Tooltip("Optional Event to be called once the object has been respawned, if Respawn is true and after RespawnTime")]
		public LogEvent onRespawnLog;
		
		public override void DealDamage(float damageAmount, Vector3? hitPosition = null, Vector3? hitNormal = null, bool reactToHit = true, GameObject sender = null, GameObject receiver = null) {
	
			base.DealDamage(damageAmount, hitPosition , hitNormal, reactToHit, sender, receiver);
			
			LogAction log = new LogAction();
			log.did = "delt " + damageAmount + " damage to";
			log.with = sender.name;
			
			onDamagedLog.Invoke(log);
		}
	}

}