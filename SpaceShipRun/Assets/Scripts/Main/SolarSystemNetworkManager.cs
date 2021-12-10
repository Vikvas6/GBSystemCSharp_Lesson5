using System.Collections.Generic;
using Characters;
using UnityEngine;
using UnityEngine.Networking;


namespace Main
{
    public class SolarSystemNetworkManager : NetworkManager
    {
        public string playerName;

        public List<string> _playerNames = new List<string>();

        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
        {
            NetworkServer.AddPlayerForConnection(conn, InstantiatePlayer(), playerControllerId);
        }

        public GameObject InstantiatePlayer()
        {
            var spawnTransform = GetStartPosition();
            var player = Instantiate(playerPrefab, spawnTransform.position, spawnTransform.rotation);
            player.GetComponent<ShipController>().PlayerName = playerName;
            return player;
        }

        public void RecreateClient()
        {
            playerName = "%UPD%" + playerName;
            StopHost();
            StartClient();
        }
    }
}
