using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField]
        private Transform m_PlatformStartPosition;

        private float m_XValue;

        private void Update()
        {
            m_XValue += Time.deltaTime * 4;
            float addedValue = Mathf.PingPong(m_XValue, 34f);
            transform.position = new Vector3(m_PlatformStartPosition.position.x + addedValue, m_PlatformStartPosition.position.y, m_PlatformStartPosition.position.z);
        }
    }
}
