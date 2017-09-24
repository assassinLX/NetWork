using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	private void OnCollisionEnter(Collision info){
		GameObject go = info.collider.gameObject;
		var health = go.GetComponent<Health>();
		if(health != null){
			health.TakeDemage(10);
		}
		Destroy(this.gameObject);
	}
}
