using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class EventTrigger : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_Ship;

        private void Start()
        {
            m_Ship.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Trigger")
            {
                GameManager.m_Instance.GetEventHandler().CallShipCrashEvent();
            }
        }

    }
}
