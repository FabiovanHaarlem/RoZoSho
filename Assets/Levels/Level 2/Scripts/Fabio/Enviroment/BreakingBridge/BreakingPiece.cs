using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class BreakingPiece : MonoBehaviour
    {
        [SerializeField]
        private List<Rigidbody> m_Pieces;

        private List<BoxCollider> m_Colliders;
        private BoxCollider m_BoxCollider;

        private void SetObjects()
        {
            m_BoxCollider = GetComponent<BoxCollider>();
            m_Colliders = new List<BoxCollider>();

            for (int i = 0; i < m_Pieces.Count; i++)
            {
                m_Colliders.Add(m_Pieces[i].GetComponent<BoxCollider>());
            }
            ChangeCollidersSize();
        }

        public void FreezeAllConstraints()
        {
            SetObjects();
            
            for (int i = 0; i < m_Pieces.Count; i++)
            {
                m_Pieces[i].constraints = RigidbodyConstraints.FreezeAll;
                m_Pieces[i].useGravity = false;
            }
        }

        private void ChangeCollidersSize()
        {
            for (int i = 0; i < m_Colliders.Count; i++)
            {
                m_Colliders[i].size = m_Colliders[i].size / 2.5f;
            }
        }

        public void Break()
        {
            m_BoxCollider.enabled = false;
            for (int i = 0; i < m_Pieces.Count; i++)
            {
                m_Pieces[i].constraints = RigidbodyConstraints.None;
                m_Pieces[i].useGravity = true;
            }
        }
    }
}
