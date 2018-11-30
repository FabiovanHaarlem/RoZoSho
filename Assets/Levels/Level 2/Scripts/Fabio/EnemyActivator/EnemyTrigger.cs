using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Level2
{
    public class EnemyTrigger : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent m_SelectSpawns;

        private bool m_Activated;

        private void Start()
        {
            m_Activated = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Trigger" || other.name == "Ship")
            {
                if (!m_Activated)
                {
                    m_SelectSpawns.Invoke();
                    m_Activated = true;
                }
            }
        }
    }
}
