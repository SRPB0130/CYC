using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class PlayerInteraction : MonoBehaviour
    {
        public float interactDistance = 2f; // ��ȣ�ۿ� ������ �Ÿ�
        public LayerMask interactableLayer; // ��ȣ�ۿ��� ��ü�� ���̾�

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F)) // 'F' Ű�� ������ �� ��ȣ�ۿ� �õ�
            {
                Interact();
            }
        }

        private void Interact()
        {
            // ���� �������� Raycast
            RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, interactDistance, interactableLayer);
            // ������ �������� Raycast
            RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, interactDistance, interactableLayer);

            // ���� ���⿡�� ��ȣ�ۿ� ������ ��ü�� ã�Ҵٸ�
            if (hitLeft.collider != null)
            {
                IInteractable interactable = hitLeft.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact(); // ��ȣ�ۿ� �޼��� ȣ��
                }
            }
            // ������ ���⿡�� ��ȣ�ۿ� ������ ��ü�� ã�Ҵٸ�
            else if (hitRight.collider != null)
            {
                IInteractable interactable = hitRight.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact(); // ��ȣ�ۿ� �޼��� ȣ��
                }
            }
        }
    }
}
