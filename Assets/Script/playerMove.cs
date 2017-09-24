using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playerMove : NetworkBehaviour {

	
	public GameObject bulletPrefab;
	public GameObject bulletSpawn;

	//只会对当前创建的物体起作用
	public override void OnStartLocalPlayer(){
		GetComponent<Renderer>().material.color = Color.green;
	}

	
	void Update(){

		if (!isLocalPlayer)
			return;
		var h = Input.GetAxis ("Horizontal");
		var w = Input.GetAxis ("Vertical");
		transform.Rotate (Vector3.up,h);
		transform.Translate (0,0,w);
		
		if(Input.GetKeyDown(KeyCode.Space)){
			CmdFire();
		}
	} 
	[Command] //特性 说明这个函数 是客户端 在服务器上调用的 --是在服务器端 被客户端调用 创建的实例在服务器端
	private void CmdFire(){
		var bullet = (GameObject) GameObject.Instantiate(bulletPrefab,
		bulletSpawn.transform.position,bulletSpawn.transform.rotation);
		bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.forward * 6.0f;
		GameObject.Destroy(bullet,2.0f);
		NetworkServer.Spawn(bullet);
	}

}
