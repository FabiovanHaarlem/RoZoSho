using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class GasTank : Damageable
    {
        private Rigidbody m_Rigidbody;
        private Vector3 m_ForceDirection;
        private GameObject m_Particles;

        private float m_Force;
        private float m_ActiveTime;

        private bool m_Activated;

        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            m_ForceDirection = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
            m_Force = 40f;
            m_ActiveTime = 0f;
            m_Particles = transform.GetChild(0).gameObject;
            m_Particles.SetActive(false);
        }

        private void Activate()
        {
            m_Activated = true;
            GetComponent<AudioSource>().Play();
            m_Particles.SetActive(true);
        }


        private void Update()
        {
            if (m_Activated && m_ActiveTime <= 4f)
            {
                m_ActiveTime += Time.deltaTime;
            }

            if (m_Activated && m_ActiveTime <= 4f)
            {
                m_Rigidbody.AddRelativeForce(-Vector3.up * m_Force);
                transform.Rotate(m_ForceDirection);
            }
            else
            {
                m_Particles.SetActive(false);
            }
        }

        public override int Damage(int health)
        {
            if (!m_Activated)
            {
                Activate();
            }

            return 0;
        }

    }
}
