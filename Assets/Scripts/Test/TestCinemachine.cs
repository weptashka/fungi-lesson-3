using Cinemachine;
using UnityEngine;

namespace Assets.Scripts
{
    public class TestCinemachine : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _camera;

        private void Start()
        {
            _camera.AddCinemachineComponent<CinemachineTransposer>().m_YDamping = 0;
        }
    }
}
