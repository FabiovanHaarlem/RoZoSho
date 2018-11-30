using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class CraneElevatorV2 : MonoBehaviour
    {
        [SerializeField]
        private Transform m_ElevatorBottomPosition;
        [SerializeField]
        private Transform m_ElevatorTopPosition;

        private GameObject m_PlayerParentObject;
        private GameObject m_Player;

        [SerializeField]
        private BoxCollider m_ElevatorGoingDownCollider;

        [SerializeField]
        private float m_ElevatorSpeed;

        private ElevatorStatesV2 m_State;

        private float m_LerpTime;

        private bool m_ElevatorTop;
        private bool m_ElevatorGoingDown;
        private bool m_ElevatorGoingUp;

        private void Start()
        {
            m_State = ElevatorStatesV2.IdleTop;
            m_ElevatorTop = true;
            m_ElevatorGoingDown = false;
            m_ElevatorGoingUp = false;
            m_ElevatorSpeed = 0.1f;
            GameManager.m_Instance.GetEventHandler().m_ElevatorHoldOutEvent += CallElevator;
            m_PlayerParentObject = GameObject.Find("PlayerParentObject");
            m_Player = GameObject.Find("Player");
            m_ElevatorGoingDownCollider.enabled = true;
        }

        private void Update()
        {   
            if (m_State == ElevatorStatesV2.GoingDown)
            {      
                Move(m_ElevatorTopPosition, m_ElevatorBottomPosition);
            }
            else if (m_State == ElevatorStatesV2.GoingUp)
            {
                Move(m_ElevatorBottomPosition, m_ElevatorTopPosition);
            }

            if (m_State == ElevatorStatesV2.IdleBotton)
            {
                m_ElevatorGoingDownCollider.enabled = false;
            }
        }

        private void Move(Transform startPosition, Transform endPosition)
        {
            transform.position = Vector3.Lerp(startPosition.position, endPosition.position, m_LerpTime);
            m_PlayerParentObject.transform.position = transform.position;
            if (m_LerpTime < 1f)
            {
                m_LerpTime += Time.deltaTime * m_ElevatorSpeed;
                if (m_LerpTime > 1f)
                {
                    m_LerpTime = 1f;

                    if (m_State == ElevatorStatesV2.GoingDown)
                    {
                        m_State = ElevatorStatesV2.IdleBotton;
                    }
                    else if (m_State == ElevatorStatesV2.GoingUp)
                    {
                        m_State = ElevatorStatesV2.IdleTop;
                    }
                }
            }
            else
            {
                m_LerpTime = 0f;
            }
        }

        private void GoDown()
        {
            m_State = ElevatorStatesV2.GoingDown;
        }

        private void GoUp()
        {
            m_State = ElevatorStatesV2.GoingUp;
        }

        public void CallElevator()
        {
            if (m_State == ElevatorStatesV2.IdleTop)
            {
                GoDown();
            }
            else if (m_State == ElevatorStatesV2.IdleBotton)
            {
                GoUp();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Trigger")
            {
                m_PlayerParentObject.transform.position = transform.position;
                m_Player.transform.SetParent(m_PlayerParentObject.transform, true);
                GameManager.m_Instance.GetUIController().EnableInteractionText();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.name == "Trigger")
            {
                GameManager.m_Instance.GetUIController().EnableInteractionText();
                if (Input.GetKeyDown(KeyCode.F))
                {
                    GameManager.m_Instance.GetUIController().DisableInteractionText();
                    CallElevator();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.name == "Trigger")
            {
                m_Player.transform.SetParent(null, true);
                GameManager.m_Instance.GetUIController().DisableInteractionText();
            }
        }
    }

    public enum ElevatorStatesV2
    {
        GoingUp = 0,
        GoingDown,
        IdleBotton,
        IdleTop
    }

}

