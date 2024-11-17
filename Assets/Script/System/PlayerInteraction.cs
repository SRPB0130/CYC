using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class PlayerInteraction : MonoBehaviour
    {
        public float interactDistance = 2f; // 상호작용 가능한 거리
        public LayerMask interactableLayer; // 상호작용할 객체의 레이어

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F)) // 'F' 키를 눌렀을 때 상호작용 시도
            {
                Interact();
            }
        }

        private void Interact()
        {
            // 왼쪽 방향으로 Raycast
            RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, interactDistance, interactableLayer);
            // 오른쪽 방향으로 Raycast
            RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, interactDistance, interactableLayer);

            // 왼쪽 방향에서 상호작용 가능한 객체를 찾았다면
            if (hitLeft.collider != null)
            {
                IInteractable interactable = hitLeft.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact(); // 상호작용 메서드 호출
                }
            }
            // 오른쪽 방향에서 상호작용 가능한 객체를 찾았다면
            else if (hitRight.collider != null)
            {
                IInteractable interactable = hitRight.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact(); // 상호작용 메서드 호출
                }
            }
        }
    }
}
