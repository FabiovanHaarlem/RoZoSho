using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class Drone : MonoBehaviour
    {
        private Rigidbody m_Rigidbody;

        [SerializeField]
        private Transform m_DroneEndPosition;

        private Vector3 m_DroneStartPosition;

        private GameObject m_PlayerParentObject;
        private GameObject m_Player;

        private float m_DroneSpeed;
        private float m_LerpTime;

        private bool m_Move;
        private bool m_Broken;

        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            m_DroneStartPosition = transform.position;
            m_Move = false;
            m_Broken = false;
            m_LerpTime = 0f;
            m_DroneSpeed = 0.2f;
            m_Rigidbody.useGravity = false;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            m_PlayerParentObject = GameObject.Find("PlayerParentObject");
            m_Player = GameObject.Find("Player");
        }

        private void Update()
        {
            if (m_Move)
            {
                if (m_LerpTime > 1f)
                {
                    m_Move = false;
                    m_LerpTime = 1f;
                    Break();
                }
                else
                {
                    m_PlayerParentObject.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                    m_LerpTime += Time.deltaTime * m_DroneSpeed;
                }

                transform.position = Vector3.Lerp(m_DroneStartPosition, m_DroneEndPosition.position, m_LerpTime);
            }
        }

        private void Break()
        {
            m_Broken = true;
            m_Rigidbody.useGravity = true;
            m_Player.transform.SetParent(null, true);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!m_Broken)
            {
                if (other.name == "Trigger")
                {
                    m_PlayerParentObject.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                    m_Player.transform.SetParent(m_PlayerParentObject.transform, true);
                    m_Move = true;
                    m_Rigidbody.constraints = RigidbodyConstraints.None;
                    m_Rigidbody.velocity = Vector3.zero;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.name == "Trigger")
            {
                if (!m_Broken)
                {
                    m_Player.transform.SetParent(null, true);
                }
            }
        }
    }
}
