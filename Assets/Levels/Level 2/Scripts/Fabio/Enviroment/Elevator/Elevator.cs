using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class Elevator : MonoBehaviour
    {
        [SerializeField]
        private Transform m_LeftDoor;
        [SerializeField]
        private Transform m_LeftDoorOpenPosition;
        [SerializeField]
        private Transform m_LeftDoorClosedPosition;

        [SerializeField]
        private Transform m_RightDoor;
        [SerializeField]
        private Transform m_RightDoorOpenPosition;
        [SerializeField]
        private Transform m_RightDoorClosedPosition;

        [SerializeField]
        private Transform m_ElevatorBottomPosition;
        [SerializeField]
        private Transform m_ElevatorTopPosition;

        private GameObject m_PlayerParentObject;
        private GameObject m_Player;

        [SerializeField]
        private float m_DoorSpeed;
        [SerializeField]
        private float m_ElevatorSpeed;

        private ElevatorStates m_State;

        private float m_LerpTime;

        private int m_Index;

        private bool m_ElevatorTop;
        private bool m_ElevatorGoingDown;
        private bool m_ElevatorGoingUp;

        private void Start()
        {
            m_State = ElevatorStates.IdleTop;
            m_ElevatorTop = true;
            m_ElevatorGoingDown = false;
            m_ElevatorGoingUp = false;
            m_Index = 0;
            m_DoorSpeed = 0.5f;
            m_ElevatorSpeed = 0.1f;
            GameManager.m_Instance.GetEventHandler().m_ElevatorHoldOutEvent += CallElevator;
            m_PlayerParentObject = GameObject.Find("PlayerParentObject");
            m_Player = GameObject.Find("Player");
        }

        private void Update()
        {
            if (m_ElevatorGoingDown)
            {
                switch (m_Index)
                {
                    case 0:
                        m_State = ElevatorStates.DoorsClosing;
                        break;
                    case 1:
                        m_State = ElevatorStates.GoingDown;
                        break;
                    case 2:
                        m_State = ElevatorStates.DoorsOpening;
                        break;
                }

            }
            else if (m_ElevatorGoingUp)
            {
                switch (m_Index)
                {
                    case 0:
                        m_State = ElevatorStates.DoorsClosing;
                        break;
                    case 1:
                        m_State = ElevatorStates.GoingUp;
                        break;
                    case 2:
                        m_State = ElevatorStates.DoorsOpening;
                        break;
                }
            }

            switch (m_State)
            {
                case ElevatorStates.GoingUp:
                    Move(m_ElevatorBottomPosition, m_ElevatorTopPosition);
                    break;
                case ElevatorStates.GoingDown:
                    Move(m_ElevatorTopPosition, m_ElevatorBottomPosition);
                    break;
                case ElevatorStates.DoorsClosing:
                    MoveDoors(m_LeftDoorOpenPosition, m_LeftDoorClosedPosition, m_RightDoorOpenPosition, m_RightDoorClosedPosition);
                    break;
                case ElevatorStates.DoorsOpening:
                    MoveDoors(m_LeftDoorClosedPosition, m_LeftDoorOpenPosition, m_RightDoorClosedPosition, m_RightDoorOpenPosition);
                    break;
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
                }
            }
            else
            {
                m_Index++;
                m_LerpTime = 0f;
            }

            
        }

        private void MoveDoors(Transform leftDoorStartingPoint, Transform leftDoorEndPoint, Transform rightDoorStartingPoint, Transform rightDoorEndPoint)
        {
            m_LeftDoor.position = Vector3.Lerp(leftDoorStartingPoint.position, leftDoorEndPoint.position, m_LerpTime);
            m_RightDoor.position = Vector3.Lerp(rightDoorStartingPoint.position, rightDoorEndPoint.position, m_LerpTime);

            if (m_LerpTime < 1f)
            {
                m_LerpTime += Time.deltaTime * m_DoorSpeed;
                if (m_LerpTime > 1f)
                {
                    m_LerpTime = 1f;
                }
            }
            else
            {
                m_Index++;
                if (m_ElevatorTop)
                {
                    m_ElevatorTop = false;
                    m_LerpTime = 0f;
                }
                else
                {
                    m_ElevatorTop = true;
                    m_LerpTime = 0f;
                }
            }

            if (m_Index == 3)
            {
                if (m_ElevatorGoingDown)
                {
                    m_State = ElevatorStates.IdleBotton;
                    m_ElevatorGoingDown = false;
                    m_Index = 0;
                }
                else if (m_ElevatorGoingUp)
                {
                    m_State = ElevatorStates.IdleTop;
                    m_ElevatorGoingUp = false;
                    m_Index = 0;
                }
            }
        }

        private void GoDown()
        {
            m_ElevatorGoingDown = true;
        }

        private void GoUp()
        {
            m_ElevatorGoingUp = true;
        }

        public void CallElevator()
        {
            if (m_State == ElevatorStates.IdleTop)
            {
                GoDown();
            }
            else if (m_State == ElevatorStates.IdleBotton)
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

    public enum ElevatorStates
    {
        GoingUp = 0,
        GoingDown,
        DoorsClosing,
        DoorsOpening,
        IdleBotton,
        IdleTop
    }
}
