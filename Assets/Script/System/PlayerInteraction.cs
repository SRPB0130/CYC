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
            // �÷��̾��� ��ġ�� �������� ��ȣ�ۿ��� ��ü Ž��
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, interactDistance, interactableLayer);
            if (hit.collider != null)
            {
                // ��ȣ�ۿ��� ��ü�� ���� ���
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact(); // ��ȣ�ۿ� �޼��� ȣ��
                }
            }
        }
    }
}
