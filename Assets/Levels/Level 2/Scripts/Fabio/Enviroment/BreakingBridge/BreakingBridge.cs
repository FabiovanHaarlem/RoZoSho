using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class BreakingBridge : MonoBehaviour
    {
        [SerializeField]
        private List<BreakingPiece> m_BrokenPieces;

        private AudioSource m_AudioSource;

        public bool m_Breaking;

        public float m_BreakTime;

        private int m_Index;

        private void Start()
        {
            m_BreakTime = 1.5f;
            m_Index = 0;
            m_AudioSource = GetComponent<AudioSource>();

            for (int i = 0; i < m_BrokenPieces.Count; i++)
            {
                m_BrokenPieces[i].FreezeAllConstraints();
            }
        }

        private void Update()
        {
            if (m_Breaking)
            {
                m_BreakTime -= Time.deltaTime;
                if (m_BreakTime <= 0f)
                {
                    if (m_Index <= m_BrokenPieces.Count - 1)
                    {
                        m_BrokenPieces[m_Index].Break();
                        m_Index++;
                        m_BreakTime = 0.5f;
                    }
                    else
                    {
                        m_Breaking = false;
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Trigger")
            {
                m_AudioSource.Play();
                m_Breaking = true;
            }
        }
    }
}
