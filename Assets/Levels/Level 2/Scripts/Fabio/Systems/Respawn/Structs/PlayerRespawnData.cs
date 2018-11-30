using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public struct PlayerRespawnData
    {
        private Vector3 m_PlayerPositions;
        private Quaternion m_PlayerRotation;
        private int m_Ammo;
        private int m_Health;

        public Vector3 GetPlayerPosition { get { return m_PlayerPositions; } }
        public Quaternion GetPlayerRotation { get { return m_PlayerRotation; } }
        public int GetAmmo { get { return m_Ammo; } }
        public int GetHealth { get { return m_Health; } }

        //public PlayerRespawnData(Vector3 playerPosition, Quaternion playerRotation, int ammo)
        //{

        //}
    }
}
