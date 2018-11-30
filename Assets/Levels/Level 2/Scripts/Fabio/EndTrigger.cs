using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Level2
{
    public class EndTrigger : MonoBehaviour
    {
        private LevelManager m_LevelManager;

        private void Start()
        {
            m_LevelManager = GetComponent<LevelManager>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F12))
            {
                DeleteJsonSaveData();
            }
        }

        private void DeleteJsonSaveData()
        {
            File.Delete(Application.persistentDataPath + "/SaveData.json");
        }

        private void LoadNextLevel()
        {
            m_LevelManager.LoadNextLevel();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Trigger")
            {
                DeleteJsonSaveData();
                LoadNextLevel();
            }
        }

        private void OnApplicationQuit()
        {
            DeleteJsonSaveData();
        }
    }
}
