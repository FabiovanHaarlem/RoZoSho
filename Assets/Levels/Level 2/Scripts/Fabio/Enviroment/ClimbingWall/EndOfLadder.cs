using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class EndOfLadder : MonoBehaviour
    {
        [SerializeField]
        private BoxCollider m_StandGround;
        [SerializeField]
        private GameObject m_Ladder;

        private void OnTriggerStay(Collider other)
        {
            m_Ladder.SetActive(false);
            m_StandGround.enabled = true;
        }

        private void OnTriggerExit(Collider other)
        {
            m_Ladder.SetActive(true);
            m_StandGround.enabled = false;
        }
    }
}
