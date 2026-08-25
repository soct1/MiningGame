using UnityEngine;

namespace Minner.UI
{
    public sealed class AdminPanel: MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField]
        private GameObject[] panels;

        private GameObject currentPanel;

        private void Start()
        {
            CloseAllPanels();
        }

        public void OpenPanel(GameObject panel)
        {
            if (panel == null)
                return;

            CloseAllPanels();

            panel.SetActive(true);
            currentPanel = panel;
        }

        public void CloseCurrentPanel()
        {
            if (currentPanel == null)
                return;

            currentPanel.SetActive(false);
            currentPanel = null;
        }

        public void CloseAllPanels()
        {
            if (panels == null)
                return;

            foreach (GameObject panel in panels)
            {
                if (panel != null)
                    panel.SetActive(false);
            }

            currentPanel = null;
        }
    }
}