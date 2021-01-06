using UnityEngine;

namespace _Code.MainCode
{
    public class SimpleMovePointController : MonoBehaviour, IMovePointBehavior
    {
        [SerializeField] private Transform _movePoint;
        [SerializeField] private LayerMask _layer;
        public Transform MovePoint => _movePoint;

        private void Start()
        {
            _movePoint.parent = null;
        }

        public void TryStepTowards(Vector3 dir)
        {
            if(CollisionCheck(dir))
                return;
            _movePoint.position += dir;
        }

        public void SetPosition(Vector3 pos)
        {
            _movePoint.position = pos;
        }

        private bool CollisionCheck(Vector3 collisionDirection)
        {
            return Physics2D.OverlapCircle(_movePoint.position + collisionDirection/2, 0.1f, _layer);
        }
    }
}