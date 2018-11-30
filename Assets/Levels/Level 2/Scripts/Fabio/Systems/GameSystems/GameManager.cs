using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    [RequireComponent(typeof(UIController))]
    [RequireComponent(typeof(EventHandler))]
    [RequireComponent(typeof(SpawnController))]
    public class GameManager : MonoBehaviour
    {
        public static GameManager m_Instance;

        private UIController m_UIController;
        private EventHandler m_EventHandler;
        private SpawnController m_SpawnController;

        private GameObject m_PlayerTrigger;
        private GameObject m_PlayerParentObject;

        private void Awake()
        {
            m_Instance = this;
            m_UIController = GetComponent<UIController>();
            m_EventHandler = GetComponent<EventHandler>();
            m_SpawnController = GetComponent<SpawnController>();
            CreatePlayerTrigger();
            CreatePlayerParentObject();
        }

        private void CreatePlayerTrigger()
        {
            m_PlayerTrigger = new GameObject("Trigger");
            m_PlayerTrigger.AddComponent<TriggerObject>();
        }

        private void CreatePlayerParentObject()
        {
            m_PlayerParentObject = new GameObject("PlayerParentObject");
            m_PlayerParentObject.transform.position = Vector3.zero;
            m_PlayerParentObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        public UIController GetUIController()
        {
            return m_UIController;
        }

        public EventHandler GetEventHandler()
        {
            return m_EventHandler;
        }

        public SpawnController GetSpawnController()
        {
            return m_SpawnController;
        }
    }
}
