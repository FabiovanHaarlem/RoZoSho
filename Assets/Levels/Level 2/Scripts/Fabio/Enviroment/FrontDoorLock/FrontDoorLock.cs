using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class FrontDoorLock : MonoBehaviour
    {
        [SerializeField]
        private Transform m_UpperDoor;
        [SerializeField]
        private Transform m_UpperDoorClosedPosition;
        private Vector3 m_UpperDoorOpenPosition;

        [SerializeField]
        private Transform m_LowerDoor;
        [SerializeField]
        private Transform m_LowerDoorClosedPosition;
        private Vector3 m_LowerDoorOpenPosition;

        [SerializeField]
        private float m_DoorSpeed;

        private float m_LerpTime;

        private bool m_CloseDoor;
        private bool m_DoorClosed;

        private void Start()
        {
            m_DoorSpeed = 0.5f;
            m_UpperDoorOpenPosition = m_UpperDoor.transform.position;
            m_LowerDoorOpenPosition = m_LowerDoor.transform.position;
            m_CloseDoor = false;
            m_DoorClosed = false;
            GameManager.m_Instance.GetEventHandler().m_ShipCrashEvent += CloseDoor;
        }

        private void Update()
        {
            if (m_CloseDoor && !m_DoorClosed)
            {
                if (m_LerpTime > 1f)
                {
                    m_DoorClosed = true;
                    m_CloseDoor = false;
                    m_LerpTime = 1f;
                }
                else
                {
                    m_LerpTime += Time.deltaTime * m_DoorSpeed;
                }

                m_UpperDoor.transform.position = Vector3.Lerp(m_UpperDoorOpenPosition, m_UpperDoorClosedPosition.position, m_LerpTime);
                m_LowerDoor.transform.position = Vector3.Lerp(m_LowerDoorOpenPosition, m_LowerDoorClosedPosition.position, m_LerpTime);
            }

        }

        public void CloseDoor()
        {
            m_CloseDoor = true;
        }
    }
}
