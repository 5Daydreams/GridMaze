using _Code.MainCode;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.UIAndUX
{
    public class LargeInputBox : MonoBehaviour
    {
        [SerializeField] private Button _closeWindowButton;
        [SerializeField] private Button _confirmButton;
        [SerializeField] private MazeGenerator.MazeGenerator _maze;

        private void OnEnable()
        {
            if (!gameObject.activeInHierarchy)
                return;
            _closeWindowButton.onClick.AddListener(() => CloseThisWindow());
            _confirmButton.onClick.AddListener(() =>
            {
                _maze.NewMaze();
                CloseThisWindow();
            });
        }
    
        public void CloseThisWindow()
        {
            this.gameObject.SetActive(false);
        }

        public void OpenThisWindow()
        {
            this.gameObject.SetActive(true);
        }
    }
}