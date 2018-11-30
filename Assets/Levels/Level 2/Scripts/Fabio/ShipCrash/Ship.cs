using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class Ship : MonoBehaviour
    {
        [SerializeField]
        private Transform m_ShipStartPosition;
        [SerializeField]
        private Transform m_ShipStopPosition;

        public float m_Time = 0.10f;

        private float m_LerpTime;

        private void Start()
        {
            this.gameObject.SetActive(false);
            m_LerpTime = 0f;
            GameManager.m_Instance.GetEventHandler().m_ShipCrashEvent += BeginShip;
        }

        private void Update()
        {
            if (m_LerpTime < 1f)
            {
                m_LerpTime += Time.deltaTime * m_Time;
                transform.position = Vector3.Lerp(m_ShipStartPosition.position, m_ShipStopPosition.position, m_LerpTime);
            }
            else if (m_LerpTime > 1f)
            {
                m_LerpTime = 1f;
            }
        }

        public void BeginShip()
        {
            this.gameObject.SetActive(true);
        }
    }
}
