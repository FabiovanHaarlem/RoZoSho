using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class SpawnController : MonoBehaviour
    {
        private lvl2_Spawning m_Spawner;

        private void Start()
        {
            m_Spawner = GameObject.Find("Spawner").GetComponent<lvl2_Spawning>();
        }

        public void SpawnShipCrashZombies()
        {
            m_Spawner.SpawnZombies(0);
        }

        public void SpawnBreakingBridgeZombies()
        {
            m_Spawner.SpawnZombies(1);
        }

        public void SpawnHangarZombies()
        {
            m_Spawner.SpawnZombies(2);
        }

        public void SpawnHoldOutBridgeZombies()
        {
            m_Spawner.SpawnZombies(3);
        }
    }
}
