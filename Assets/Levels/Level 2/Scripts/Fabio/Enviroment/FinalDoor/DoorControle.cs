using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class DoorControle : MonoBehaviour
    {
        [SerializeField]
        private lvl2_Spawning m_Spawner;

        [SerializeField]
        private Transform m_SpaceportDoorLeft;
        [SerializeField]
        private Transform m_SpaceportDoorLeftOpenPosition;
        private Vector3 m_SpaceportDoorLeftClosedPosition;

        [SerializeField]
        private Transform m_SpaceportDoorRight;
        [SerializeField]
        private Transform m_SpaceportDoorRightOpenPosition;
        private Vector3 m_SpaceportDoorRightClosedPosition;

        [SerializeField]
        private Transform m_WallDoorLeft;
        [SerializeField]
        private Transform m_WallDoorLeftOpenPosition;
        private Vector3 m_WallDoorLeftClosedPosition;

        [SerializeField]
        private Transform m_WallDoorRight;
        [SerializeField]
        private Transform m_WallDoorRightOpenPosition;
        private Vector3 m_WallDoorRightClosedPosition;

        [SerializeField]
        private float m_SpaceportDoorSpeed;
        [SerializeField]
        private float m_WallDoorSpeed;

        private float m_LerpTimeSpaceportDoor;
        private float m_LerpTimeWallDoor;

        private bool m_OpenSpaceportDoor;
        private bool m_OpenWallDoor;

        void Start()
        {
            m_SpaceportDoorLeftClosedPosition = m_SpaceportDoorLeft.transform.position;
            m_SpaceportDoorRightClosedPosition = m_SpaceportDoorRight.transform.position;
            m_WallDoorLeftClosedPosition = m_WallDoorLeft.transform.position;
            m_WallDoorRightClosedPosition = m_WallDoorRight.transform.position;
            m_SpaceportDoorSpeed = 0.05f;
            m_WallDoorSpeed = 0.7f;
            GameManager.m_Instance.GetEventHandler().m_BridgeHoldOutEvent += OpenDoors;
            GameManager.m_Instance.GetEventHandler().m_BridgeHoldOutEvent += GameManager.m_Instance.GetSpawnController().SpawnHoldOutBridgeZombies;
        }


        void Update()
        {
            if (m_OpenSpaceportDoor)
            {
                if (m_LerpTimeSpaceportDoor > 1f)
                {
                    m_LerpTimeSpaceportDoor = 1f;
                    m_OpenSpaceportDoor = false;
                }
                else
                {
                    m_LerpTimeSpaceportDoor += Time.deltaTime * m_SpaceportDoorSpeed;
                }

                m_SpaceportDoorLeft.transform.position = Vector3.Lerp(m_SpaceportDoorLeftClosedPosition, m_SpaceportDoorLeftOpenPosition.position, m_LerpTimeSpaceportDoor);
                m_SpaceportDoorRight.transform.position = Vector3.Lerp(m_SpaceportDoorRightClosedPosition, m_SpaceportDoorRightOpenPosition.position, m_LerpTimeSpaceportDoor);
            }

            if (m_OpenWallDoor)
            {
                if (m_LerpTimeWallDoor > 1f)
                {
                    m_LerpTimeWallDoor = 1f;
                    m_OpenWallDoor = false;
                }
                else
                {
                    m_LerpTimeWallDoor += Time.deltaTime * m_WallDoorSpeed;
                }

                m_WallDoorLeft.transform.position = Vector3.Lerp(m_WallDoorLeftClosedPosition, m_WallDoorLeftOpenPosition.position, m_LerpTimeWallDoor);
                m_WallDoorRight.transform.position = Vector3.Lerp(m_WallDoorRightClosedPosition, m_WallDoorRightOpenPosition.position, m_LerpTimeWallDoor);
            }
        }

        public void OpenDoors()
        {
            if (!m_OpenSpaceportDoor)
            {
                m_OpenSpaceportDoor = true;
                m_OpenWallDoor = true;
            }
        }
    }
}
