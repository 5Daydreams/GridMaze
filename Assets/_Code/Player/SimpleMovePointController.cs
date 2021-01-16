using UnityEngine;

namespace _Code.MainCode
{
    public class SimpleMovePointController : MonoBehaviour, IMovePointBehavior, ICollisionCheckBehavior
    {
        [SerializeField] private Transform _movePoint;
        [SerializeField] private VoidEvent _onMove;
        [SerializeField] private LayerMask _collisionLayer;
        public Transform MovePoint => _movePoint;

        private void Start()
        {
            _movePoint.parent = null;
        }

        public void StepTowards(Vector3 dir)
        {
            _movePoint.position += dir;
            _onMove.Raise();
        }

        public void SetPosition(Vector3 pos)
        {
            _movePoint.position = pos;
        }

        public bool CollisionCheck(Vector3 collisionDirection)
        {
            return Physics2D.OverlapCircle(_movePoint.position + collisionDirection/2, 0.1f, _collisionLayer);
        }
    }
}