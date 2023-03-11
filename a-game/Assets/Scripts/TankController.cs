using System;
using UnityEngine;

namespace Forge.Controllers
{
    public class TankController : MonoBehaviour
    {
	    #region Variables

        [SerializeField]
        private GameObject projectilePrefab;

        [SerializeField]
        private Transform projectileSpawnPoint;

        [SerializeField]
        private float speed;

        private Rigidbody rgBody;

        private Vector3 moveInput;

        #endregion

        #region Properties

        #endregion

        #region Unity Methods

        private void Start()
        {
            rgBody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            LookAt();
            Move();
            TryToFire();
        }

        private void FixedUpdate()
        {
            rgBody.velocity = moveInput * speed;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if(collider.tag == "Wall" || collider.tag == "UnvisibleCollider")
            {
                UIController.Instance.ShowFailedText();
                speed = 0f;
            }
            else if(collider.tag == "Flag")
            {
                UIController.Instance.ShowWellDoneText();
                speed = 0f;
            }
        }

        #endregion

        #region Methods

        private void LookAt()
        {
            var mouseInput = Input.mousePosition;
            var ray = Camera.main.ScreenPointToRay(mouseInput);
            Physics.Raycast(ray, out RaycastHit hit, 200f);

            if(hit.collider != null)
            {
                var hitPoint = hit.point;
                hitPoint.y = 0f;

                if(Vector3.Distance(hitPoint, transform.position) > 0.5f)
                {
                    transform.LookAt(hitPoint);
                }
            }
        }

        private void Move()
        {
            moveInput = Vector3.zero;
            if(Input.GetKey(KeyCode.W))
            {
                moveInput = transform.forward;
            }
        }

        private void TryToFire()
        {
            if(Input.GetMouseButtonDown(0))
            {
                var projectileGo = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            }
        }


        #endregion

        #region Callbacks

        #endregion
    }
}
