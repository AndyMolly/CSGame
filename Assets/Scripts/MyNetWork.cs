using UnityEngine;
using System.Collections;

public class MyNetWork : MonoBehaviour {
	public int connections=10;
	public int listenPort=8899;
	public bool useNat=false;
	public string ip="127.0.0.1";

	public GameObject player;

 void OnGUI()
	{
		if (Network.peerType == NetworkPeerType.Disconnected) {
						if (GUILayout.Button ("创建服务器")) {
								var error = Network.InitializeServer (connections, listenPort, useNat);
								print (error);
						}

						if (GUILayout.Button ("连接服务器")) {
								Network.Connect (ip, listenPort);
						}	
	
				} 
		else if (Network.peerType == NetworkPeerType.Server) {
						GUILayout.Label ("服务器创建完成");
				} 
		else if (Network.peerType == NetworkPeerType.Client) {
			GUILayout.Label("连接服务器成功");	
		}

	}
	void OnServerInitialized()
	{
		print("Server 初始化完成");

		Network.Instantiate (player, new Vector3 (0, 5, 0), Quaternion.identity, int.Parse(Network.player+""));
	}
	void OnPlayerConnected(NetworkPlayer player)
	{
		print ("一个客户端连接进来"+player);
	}

	void OnConnectedToServer()
	{
		print("我成功连接到服务器了");
		Network.Instantiate (player, new Vector3 (0, 5, 0), Quaternion.identity, int.Parse(Network.player+""));
	}
}
