using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class EmergencyLighting : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_LightsRotator;
        [SerializeField]
        private List<Light> m_Lights;

        private float m_RotationSpeed;
        private float m_LightIntensity;
        private bool m_Activated;

        private void Start()
        {
            m_RotationSpeed = 3f;
            m_Activated = false;
            m_LightIntensity = m_Lights[0].intensity;

            for (int i = 0; i < m_Lights.Count; i++)
            {
                m_Lights[i].intensity = 0f;
            }

            GameManager.m_Instance.GetEventHandler().m_ShipCrashEvent += Activate;
        }

        private void Update()
        {
            if (m_Activated)
            {
                m_LightsRotator.gameObject.transform.Rotate(new Vector3(0, 0, 60 * m_RotationSpeed * Time.deltaTime));
                for (int i = 0; i < m_Lights.Count; i++)
                {
                    m_Lights[i].intensity = m_LightIntensity;
                }
            }
        }

        private void Activate()
        {
            m_Activated = true;
            for (int i = 0; i < m_Lights.Count; i++)
            {
                m_Lights[i].intensity = m_LightIntensity;
            }
        }
    }
}
