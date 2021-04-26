using UnityEngine;

namespace _Code.Toolbox.SimpleValues
{
    [CreateAssetMenu(fileName = "TimeAttackDifficulty", menuName = "CustomScriptables/StructValue/TimeAttackDifficulty")]
    public class DifficultySettings : ScriptableObject
    {
        public float StartingTime;
        public float Increment;
        public int MazeHeight;
        public int MazeWidth;
    }
}