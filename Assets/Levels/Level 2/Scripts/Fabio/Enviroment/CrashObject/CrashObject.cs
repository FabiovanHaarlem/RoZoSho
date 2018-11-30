using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class CrashObject : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_CompleteObject;
        [SerializeField]
        private GameObject m_BrokenObject;
        [SerializeField]
        private GameObject m_CrashParticals;

        private void Start()
        {
            m_CompleteObject.SetActive(true);
            m_BrokenObject.SetActive(false);
            m_CrashParticals.SetActive(false);
        }

        private void Break()
        {
            m_CompleteObject.SetActive(false);
            m_BrokenObject.SetActive(true);
            m_CrashParticals.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Ship")
            {
                Break();

                if (this.gameObject.name == "WallTriggerSecondWall")
                {
                    GameManager.m_Instance.GetEventHandler().CallShipCrashEventEnd();
                }
            }
        }
    }
}
