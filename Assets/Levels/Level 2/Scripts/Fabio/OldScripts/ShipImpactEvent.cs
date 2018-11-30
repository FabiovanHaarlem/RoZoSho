using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class ShipImpactEvent : MonoBehaviour
    {

        [SerializeField]
        private GameObject m_WallNotBroken;
        [SerializeField]
        private GameObject m_WallBroken;
        [SerializeField]
        private GameObject m_BridgeNotBroken;
        [SerializeField]
        private GameObject m_BridgeBroken;
        [SerializeField]
        private GameObject m_WallNotBrokenZombies;
        [SerializeField]
        private GameObject m_WallBrokenZombies;

        [SerializeField]
        private Transform m_ShipStartPosition;
        [SerializeField]
        private Transform m_ShipStopPosition;

        private float m_LerpTime;

        private void Start()
        {
            m_WallNotBroken.SetActive(true);
            m_WallBroken.SetActive(false);
            m_BridgeNotBroken.SetActive(true);
            m_BridgeBroken.SetActive(false);
            m_WallNotBrokenZombies.SetActive(true);
            m_WallBrokenZombies.SetActive(false);
            GameManager.m_Instance.GetEventHandler().m_ShipCrashEvent += StartShip;
        }

        private void StartShip()
        {
            this.gameObject.SetActive(true);
        }

        private void Update()
        {
            if (m_LerpTime <= 1)
            {
                m_LerpTime += Time.deltaTime * 0.10f;
                transform.position = Vector3.Lerp(m_ShipStartPosition.position, m_ShipStopPosition.position, m_LerpTime);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "WallImpactTrigger")
            {
                m_WallNotBroken.SetActive(false);
                m_WallBroken.SetActive(true);
            }

            if (other.name == "TowerBridgeImpactTrigger")
            {
                m_BridgeNotBroken.SetActive(false);
                m_BridgeBroken.SetActive(true);
            }

            if (other.name == "WallImpactTriggerZombies")
            {
                m_WallNotBrokenZombies.SetActive(false);
                m_WallBrokenZombies.SetActive(true);
            }

        }
    }
}
