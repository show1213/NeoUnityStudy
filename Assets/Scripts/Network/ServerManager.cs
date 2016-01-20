using UnityEngine;
using System.Collections;

public class ServerManager : MonoBehaviour {
	private const string typeName = "UniqueGameName";
	private const string gameName = "RoomName";

	public Transform PlayerPrefab;
	// Use this for initialization
	void Start () {
		StartServer();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void StartServer()
	{
		Network.InitializeServer(4, 8837, !Network.HavePublicAddress());
	}

	void OnServerInitialized()
	{
		Debug.Log("Server Initilaized");
		Network.Instantiate(PlayerPrefab, new Vector3(0,0,0), transform.rotation, 0);
	}

	void OnConnectedToServer()
	{
		Debug.Log("connected");
	}

	//void On

	void OnPlayerConnected(NetworkPlayer player)
	{
		Debug.Log("player :" + player.ipAddress + ", player id:" + player);
	}

	void OnPlayerDisconnected(NetworkPlayer player)
	{
	 	Debug.Log("Clean up after player :" + player.ipAddress + ", player id: " + player);
        Network.RemoveRPCs(player);
	 	Network.DestroyPlayerObjects(player);
	}
}
