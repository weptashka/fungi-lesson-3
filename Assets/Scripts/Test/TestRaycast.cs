using UnityEngine;

namespace Assets.Scripts
{
    public class TestRaycast : MonoBehaviour
    {
        [SerializeField] private Vector2 _direction;
        [SerializeField] private LayerMask _layerMask;


        public void Update()
        {
            Ray ray = new Ray(transform.position, _direction);
            RaycastHit2D raycastHit2D = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, _layerMask);


            if (raycastHit2D.transform)
            {
                Debug.Log(raycastHit2D.transform.gameObject.name);
            }
        }
    }
}
