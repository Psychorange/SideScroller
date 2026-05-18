using System.Collections.Generic;
using UnityEngine;

public class GravityTransferManager : MonoBehaviour
{
    [System.Serializable]
    public class RoomConnection
    {
        [Header("Connexion")]
        public string connectionName;

        [Tooltip("Salle A de la connexion.")]
        public newGravityManager roomA;

        [Tooltip("Porte qui relie la salle A.")]
        public doorScript doorA;

        [Tooltip("Cette salle est une source de gravité.")]
        public bool roomAIsSource;

        [Tooltip("Salle B de la connexion.")]
        public newGravityManager roomB;

        [Tooltip("Porte qui relie la salle B.")]
        public doorScript doorB;

        [Tooltip("Cette salle est une source de gravité.")]
        public bool roomBIsSource;

        public bool IsOpen => doorA != null && doorB != null && doorA.doorOpen && doorB.doorOpen;
    }

    [SerializeField]
    private List<RoomConnection> roomConnections = new List<RoomConnection>();

    private int lastDoorStateHash = int.MinValue;

    private void Start()
    {
        lastDoorStateHash = ComputeDoorStateHash();
        RefreshGravity();
    }

    private void Update()
    {
        int currentHash = ComputeDoorStateHash();
        if (currentHash != lastDoorStateHash)
        {
            lastDoorStateHash = currentHash;
            RefreshGravity();
        }
    }

    public void RefreshGravity()
    {
        var activeRooms = new HashSet<newGravityManager>();
        var allRooms = new HashSet<newGravityManager>();

        foreach (var connection in roomConnections)
        {
            if (connection == null)
                continue;

            if (connection.roomA != null)
                allRooms.Add(connection.roomA);
            if (connection.roomB != null)
                allRooms.Add(connection.roomB);

            if (connection.roomAIsSource && connection.roomA != null)
                activeRooms.Add(connection.roomA);
            if (connection.roomBIsSource && connection.roomB != null)
                activeRooms.Add(connection.roomB);
        }

        var queue = new Queue<newGravityManager>(activeRooms);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            foreach (var connection in roomConnections)
            {
                if (connection == null || !connection.IsOpen)
                    continue;

                if (connection.roomA == current && connection.roomB != null && !activeRooms.Contains(connection.roomB))
                {
                    activeRooms.Add(connection.roomB);
                    queue.Enqueue(connection.roomB);
                }
                else if (connection.roomB == current && connection.roomA != null && !activeRooms.Contains(connection.roomA))
                {
                    activeRooms.Add(connection.roomA);
                    queue.Enqueue(connection.roomA);
                }
            }
        }

        foreach (var room in allRooms)
        {
            if (room == null)
                continue;

            room.ActiveGravity(activeRooms.Contains(room));
        }
    }

    private int ComputeDoorStateHash()
    {
        int hash = 17;

        foreach (var connection in roomConnections)
        {
            if (connection == null)
            {
                hash = hash * 31;
                continue;
            }

            hash = hash * 31 + ((connection.doorA != null && connection.doorA.doorOpen) ? 1 : 0);
            hash = hash * 31 + ((connection.doorB != null && connection.doorB.doorOpen) ? 1 : 0);
        }

        return hash;
    }
}
