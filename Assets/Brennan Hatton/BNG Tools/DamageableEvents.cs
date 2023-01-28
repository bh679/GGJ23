using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BNG;

/// <summary>
/// A UnityEvent with a float as a parameter
/// </summary>
[System.Serializable]
public class FloatGameObjectEvent : UnityEvent<float, GameObject> { }

public class DamageableEvents : Damageable
{
	[Header("Events")]
	[Tooltip("Optional Event to be called when receiving damage. Takes damage amount as a float parameter.")]
	public FloatGameObjectEvent onDamagedDetails;

	/*[Tooltip("Optional Event to be called once health is <= 0")]
	public LogEvent onDestroyedLog;

	[Tooltip("Optional Event to be called once the object has been respawned, if Respawn is true and after RespawnTime")]
	public LogEvent onRespawnLog;*/
	
	public override void DealDamage(float damageAmount, Vector3? hitPosition = null, Vector3? hitNormal = null, bool reactToHit = true, GameObject sender = null, GameObject receiver = null) {

		base.DealDamage(damageAmount, hitPosition , hitNormal, reactToHit, sender, receiver);
		
		onDamagedDetails.Invoke(damageAmount, sender);
	}
}

