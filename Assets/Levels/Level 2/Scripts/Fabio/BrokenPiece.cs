using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class BrokenPiece : MonoBehaviour
    {
        private BoxCollider m_Collider;
   
        private float m_DisablePhysticsTimer;
        [SerializeField]
        private bool m_UseDisablePhysicsTimer;

        private void Start()
        {
            m_Collider = GetComponent<BoxCollider>();
            ChangeColliderSize();
            m_DisablePhysticsTimer = 3f;
        }

        private void Update()
        {
            if (m_UseDisablePhysicsTimer)
            {
                m_DisablePhysticsTimer -= Time.deltaTime;
                if (m_DisablePhysticsTimer <= 0f)
                {
                    m_Collider.enabled = false;

                    if (m_DisablePhysticsTimer <= -3f)
                    {
                        this.gameObject.SetActive(false);
                    }
                    //transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime, transform.position.z);
                }
            }
        }

        private void ChangeColliderSize()
        {
            m_Collider.size = m_Collider.size / 4f;
        }
    }
}
