using UnityEngine;

namespace _Code.MainCode
{
    public class SimpleMovePointController : MonoBehaviour, IMovePointBehavior
    {
        [SerializeField] private Transform _movePoint;
        public Transform MovePoint => _movePoint;

        private void Start()
        {
            _movePoint.parent = null;
        }

        public void StepTowards(Vector2 dir)
        {
            _movePoint.position += new Vector3(dir.x, dir.y, 0);
        }
    }
}