using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class ShipEventTrigger : MonoBehaviour
    {
        private bool m_Activated;

        public void PlayMainAlarm()
        {
            GetComponent<AudioSource>().Play();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (m_Activated == false)
            {
                if (other.name == "Trigger")
                {
                    PlayMainAlarm();
                    m_Activated = true;
                    GameManager.m_Instance.GetEventHandler().CallShipCrashEvent();
                }
            }
        }
    }
}
