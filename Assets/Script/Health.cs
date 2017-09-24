using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

	public const int MaxHealth = 100;

	[SyncVar (hook = "OnChangeValue")]
	public int currentHealth = MaxHealth; 
	public Slider healthBar;

	void OnChangeValue(int health){
		healthBar.value =  health /(float) MaxHealth;
	}

	[ClientRpc]
	void RpcRespawn(){
		transform.position = Vector3.zero;
	}

	public void TakeDemage(int demage){
		currentHealth -= demage;
		if(currentHealth <= 0){
			currentHealth = MaxHealth;
			RpcRespawn();
		}
	}
	
}
