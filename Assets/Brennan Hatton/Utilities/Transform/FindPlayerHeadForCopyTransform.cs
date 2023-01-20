using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(CopyTransform))]
public class FindPlayerHeadForCopyTransform : MonoBehaviour
{
	public void Reset()
	{
		
#if UNITY_EDITOR
		
		CopyTransform copy = this.GetComponent<CopyTransform>();
		var newserializedObject = new SerializedObject(copy);
		newserializedObject.Update();
		SerializedProperty _targetProperty = newserializedObject.FindProperty("target"); 
		
		GameObject head = GameObject.Find("CenterEyeAnchor");
				
		// We need to tell Unity we're changing the component object too.
		Undo.RecordObject(copy, "Connected head to copytranform");

		if(head != null)
		{
			_targetProperty.objectReferenceValue = head.transform;
			newserializedObject.ApplyModifiedProperties();
		}
#endif
	}
}
