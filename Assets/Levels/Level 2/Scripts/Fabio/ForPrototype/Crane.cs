using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class Crane : MonoBehaviour
    {
        [SerializeField]
        private Transform m_PlayerCranePosition;
        [SerializeField]
        private GameObject m_Player;

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Trigger")
            {
                m_Player.transform.position = m_PlayerCranePosition.position;
            }
        }
    }
}
