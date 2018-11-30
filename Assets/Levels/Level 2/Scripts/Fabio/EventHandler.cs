using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class EventHandler : MonoBehaviour
    {
        public delegate void ShipCrashEvent();
        public ShipCrashEvent m_ShipCrashEvent;

        public delegate void ShipCrashEventEnd();
        public ShipCrashEventEnd m_ShipCrashEventEnd;

        public delegate void ElevatorHoldOutEvent();
        public ElevatorHoldOutEvent m_ElevatorHoldOutEvent;

        public delegate void BridgeBreakingEvent();
        public BridgeBreakingEvent m_BridgeBreakingEvent;

        public delegate void BridgeHoldOutEvent();
        public BridgeHoldOutEvent m_BridgeHoldOutEvent;

        public delegate void BrokenElevatorEvent();
        public BrokenElevatorEvent m_BrokenElevatorEvent;

        public void CallShipCrashEvent()
        {
            if (m_ShipCrashEvent != null)
            {
                m_ShipCrashEvent();
            }
        }

        public void CallShipCrashEventEnd()
        {
            if (m_ShipCrashEventEnd != null)
            {
                m_ShipCrashEventEnd();
            }
        }

        public void CallElevatorHoldOutEvent()
        {
            if (m_ElevatorHoldOutEvent != null)
            {
                m_ElevatorHoldOutEvent();
            }
        }

        public void CallBridgeBreakingEvent()
        {
            if (m_BridgeBreakingEvent != null)
            {
                m_BridgeBreakingEvent();
            }
        }

        public void CallBridgeHoldOutEvent()
        {
            if (m_BridgeHoldOutEvent != null)
            {
                m_BridgeHoldOutEvent();
            }
        }

        public void CallBrokenElevatorEvent()
        {
            if (m_BrokenElevatorEvent != null)
            {
                m_BrokenElevatorEvent();
            }
        }
    }
}
