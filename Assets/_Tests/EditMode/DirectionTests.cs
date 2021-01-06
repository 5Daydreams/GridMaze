using NUnit.Framework;
using UnityEngine;

namespace _Tests.EditMode
{
    public class DirectionTest
    {
        [Test]
        public void DirectionTestSimplePasses()
        {
            Assert.AreEqual(new Vector3(0,1,0), new Vector3(0,0,1));
        }
    }
}
