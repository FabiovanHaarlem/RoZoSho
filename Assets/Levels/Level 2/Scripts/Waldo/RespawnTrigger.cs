using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class RespawnTrigger : MonoBehaviour
    {
        [SerializeField]private int m_SpawnPoint;
        [SerializeField] private GameObject m_Trigger;
        //private DeathTrigger m_DeathTrigger = new DeathTrigger();
        [SerializeField]
        private Respawn m_Respawn;

        private void Update()
        {
            if (m_Respawn.m_SpawnPoint < 0 && m_Trigger.GetComponent<BoxCollider>().enabled == false)
                ActivateTrigger();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Trigger" && m_SpawnPoint == 1 )
            {
                ActivateTrigger();
                m_Respawn.m_SpawnPoint = 1;
                m_Respawn.Save();
            }
            if (other.name == "Trigger" && m_SpawnPoint == 2)
            {
                m_Respawn.m_SpawnPoint = 2;
                m_Respawn.Save();
            }
            if (other.name == "Trigger" && m_SpawnPoint == 3)
            {
                m_Respawn.m_SpawnPoint = 3;
                m_Respawn.Save();
            }

            //ActivateTrigger();
        }
        public void ActivateTrigger()
        {
            m_Trigger.GetComponent<BoxCollider>().enabled = true;
        }
    }
}

