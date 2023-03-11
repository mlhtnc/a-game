using UnityEngine;

namespace Forge.Controllers
{
    public class Projectile : MonoBehaviour
    {
	    #region Variables

        private Rigidbody rgBody;

        #endregion

        #region Properties

        #endregion

        #region Unity Methods
	
        private void Start()
        {
            rgBody = GetComponent<Rigidbody>();
            rgBody.AddForce(transform.forward * 10f, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider collider)
        {
            if(collider.tag == "Wall")
            {
                collider.GetComponent<MeshRenderer>().enabled = true;
            }

            Destroy(gameObject);
        }

        #endregion

        #region Methods

        #endregion

        #region Callbacks

        #endregion
    }
}
