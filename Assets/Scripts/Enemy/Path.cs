using UnityEngine;

namespace Assets.Scripts
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private Vector2[] _movementPoints;

        private Vector2[] _localMovementPoints;

        public Vector2[] LocalMovementPoints => _localMovementPoints;

        public void ToLocal()
        {
            _localMovementPoints = new Vector2[_movementPoints.Length];
            for (int i = 0; i < _movementPoints.Length; i++)
            {
                _localMovementPoints[i] = GetLocalPoint(i);
            }
        }

        private Vector2 GetLocalPoint(int index)
        {
            return new Vector2(_movementPoints[index].x + transform.position.x, _movementPoints[index].y + transform.position.y);
        }

#if UNITY_EDITOR
        public void OnDrawGizmos()
        {
            // Draws four lines making a square
            Gizmos.color = Color.white;


            if (_localMovementPoints == null || _localMovementPoints.Length <= 0)
            {
                for (int i = 0; i < _movementPoints.Length - 1; i++)
                {
                    Gizmos.DrawLine(GetLocalPoint(i), GetLocalPoint(i + 1));
                    if (i == _movementPoints.Length - 2)
                    {
                        Gizmos.DrawLine(GetLocalPoint(i + 1), GetLocalPoint(0));
                    }
                }
                return;
            }

            for (int i = 0; i < _movementPoints.Length - 1; i++)
            {
                Gizmos.DrawLine(_localMovementPoints[i], _localMovementPoints[i + 1]);
                if (i == _movementPoints.Length - 2)
                {
                    Gizmos.DrawLine(_localMovementPoints[i + 1], _localMovementPoints[0]);
                }
            }

        }
#endif
    }
}


