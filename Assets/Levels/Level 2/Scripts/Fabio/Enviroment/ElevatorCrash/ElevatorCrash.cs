using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class ElevatorCrash : MonoBehaviour
    {
        private Rigidbody m_ElevatorRigidbody;
        [SerializeField]
        private List<Rigidbody> m_Rubble;

        [SerializeField]
        private Transform m_DoorRight;
        [SerializeField]
        private Transform m_DoorRightOpenPosition;

        private Vector3 m_DoorRightClosedPosition;

        private AudioSource m_CrashSound;

        private float m_LerpTime;
        private float m_DoorSpeed;

        private bool m_OpenDoors;

        private void Start()
        {
            m_DoorRightClosedPosition = m_DoorRight.position;
            m_ElevatorRigidbody = GetComponent<Rigidbody>();
            m_ElevatorRigidbody.useGravity = false;
            m_ElevatorRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            m_DoorSpeed = 0.6f;
            //GameManager.m_Instance.GetEventHandler().m_BrokenElevatorEvent += LoseRubble;
            GameManager.m_Instance.GetEventHandler().m_BrokenElevatorEvent += CallBrokenElevator;
            m_CrashSound = GetComponent<AudioSource>();

            //for (int i = 0; i < m_Rubble.Count; i++)
            //{
            //    m_Rubble[i].useGravity = false;
            //    m_Rubble[i].constraints = RigidbodyConstraints.FreezeAll;
            //}
        }

        private void Update()
        {
            if (m_OpenDoors)
            {
                if (m_LerpTime > 1f)
                {
                    m_LerpTime = 1f;
                    m_OpenDoors = false;
                }
                else
                {
                    m_LerpTime += Time.deltaTime * m_DoorSpeed;
                }

                m_DoorRight.transform.position = Vector3.Lerp(m_DoorRightClosedPosition, m_DoorRightOpenPosition.position, m_LerpTime);
            }
        }

        public void CallBrokenElevator()
        {
            m_OpenDoors = true;
            m_ElevatorRigidbody.useGravity = true;
            m_ElevatorRigidbody.constraints = RigidbodyConstraints.None;
            m_CrashSound.Play();
        }

        public void LoseRubble()
        {
            for (int i = 0; i < m_Rubble.Count; i++)
            {
                m_Rubble[i].useGravity = true;
                m_Rubble[i].constraints = RigidbodyConstraints.None;
            }
        }
    }
}
