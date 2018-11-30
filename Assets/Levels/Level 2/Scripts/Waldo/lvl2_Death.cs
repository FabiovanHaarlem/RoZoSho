using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class lvl2_Death : MonoBehaviour
    {

        [SerializeField]
        private List<Transform> m_SpawnPos;



        [SerializeField]
        private GameObject m_Player, m_Bridge;

        [SerializeField]
        private int m_SpawnInt = 1;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Respawn();
            }

        }

        void Respawn()
        {
            switch(m_SpawnInt)
            {
                case 0:
                    m_Player.transform.position = m_SpawnPos[0].transform.position;
                    break;
                case 1:
                    GameObject bridge = GameObject.Find("Bridge");
                    if (bridge.activeInHierarchy)
                    {
                        Destroy(bridge);
                        Instantiate(m_Bridge);
                    }
                    break;
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Trigger")
            {

            }

        }
    }
}
