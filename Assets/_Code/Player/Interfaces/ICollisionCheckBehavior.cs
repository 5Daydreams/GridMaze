using UnityEngine;

namespace _Code.MainCode
{
    public interface ICollisionCheckBehavior
    {
        bool CollisionCheck(Vector3 direction, float cellScale);
    }
}