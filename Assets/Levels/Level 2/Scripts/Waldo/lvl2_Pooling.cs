using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level2;
using UnityEngine.AI;

namespace Level2
{
    public class lvl2_Pooling : MonoBehaviour
    {

        [SerializeField]
        private List<PoolingObject> m_PoolObjects;

        [SerializeField]
        private List<GameObject> m_Objects;
        public List<GameObject> Object
        {
            get { return m_Objects; }
        }

        [SerializeField]
        private List<GameObject> m_Zombies;
        public List<GameObject> Zombie
        {
            get { return m_Zombies; }
        }

        GameObject m_PoolName;

        void Start()
        {


            m_Objects = new List<GameObject>();

            //m_PoolObjects = new List<PoolingObject>();
            for (int p = 0; p < m_PoolObjects.Count; p++)
            {
                m_PoolName = new GameObject("Pool" + " " + m_PoolObjects[p].ObjectType.name);
                m_PoolName.transform.parent = gameObject.transform;
                for (int i = 0; i < m_PoolObjects[p].Amount; i++)
                {
                    if (m_PoolObjects[p].ObjectType.name == "Zombie")
                    {
                        GameObject obj = (GameObject)Instantiate(m_PoolObjects[p].ObjectType);
                        obj.transform.parent = m_PoolName.transform;
                        obj.SetActive(false);
                        m_Zombies.Add(obj);
                    }
                    else
                    {
                        GameObject obj = (GameObject)Instantiate(m_PoolObjects[p].ObjectType);
                        obj.transform.parent = m_PoolName.transform;
                        obj.SetActive(false);
                        m_Objects.Add(obj);
                    }
                }
            }
        }
    }
}
