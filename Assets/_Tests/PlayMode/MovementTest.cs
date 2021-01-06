using System.Collections;
using _Code.MainCode;
using UnityEngine;
using UnityEngine.TestTools;

namespace _Tests.PlayMode
{
    public class MovementTest
    {
        [UnityTest]
        public IEnumerator Movement()
        {
            var gameObject = new GameObject();
            var player = gameObject.AddComponent<Player>();
            
            
            yield return null;
        }
    }
}
