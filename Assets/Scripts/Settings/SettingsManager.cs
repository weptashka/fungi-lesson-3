using Assets.Scripts.Enemy;
using UnityEngine;

namespace Assets.Scripts.Settings
{
    public class SettingsManager : MonoBehaviour
    {
        public static SettingsManager Instance;

        [SerializeField] private EnemySettings _enemySettings;
        public EnemySettings EnemySettings => _enemySettings;

        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
    }
}
