using TMPro;
using UnityEngine;

namespace Forge.Controllers
{
    public class UIController : MonoBehaviour
    {
	    #region Variables

        public static UIController Instance;

        [SerializeField]
        private TextMeshProUGUI wellDoneText;

        [SerializeField]
        private TextMeshProUGUI failedText;
        
        #endregion

        #region Properties

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
	
        private void Start()
        {
        
        }

        private void Update()
        {
        
        }

        #endregion

        #region Methods

        public void ShowFailedText()
        {
            failedText.gameObject.SetActive(true);
        }

        public void ShowWellDoneText()
        {
            wellDoneText.gameObject.SetActive(true);
        }

        #endregion

        #region Callbacks

        #endregion
    }
}
