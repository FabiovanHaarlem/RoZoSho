using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Level2
{
    public class RespawnManager : MonoBehaviour
    {
        [SerializeField]
        private Player m_Player;

        [SerializeField]
        private AmmoTypeDefinition m_Ammo;

        //private AmmoArsenal m_AmmoArsenal;
        //m_AmmoArsenal.ChangeAmmo(m_Ammo, 20);

        private PlayerRespawnData m_PlayerRespawnData;
        private EnemysRespawnData m_EnemysRespawnData;
        private EnemyRespawnData m_EnemyRespawnData;
        private BrokenBridgeRespawnData m_BrokenBridgeRespawnData;

        private void Start()
        {
            
        }

        public void ReloadScene()
        {

        }

        public void LoadLastCheckpoint()
        {

        }

        private void SaveScene()
        {

        }

        private void LoadScene()
        {

        }
    }
}
