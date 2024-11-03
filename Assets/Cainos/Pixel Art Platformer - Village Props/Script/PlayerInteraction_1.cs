using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtPlatformer_VillageProps
{
    public class PlayerInteraction_1 : MonoBehaviour
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
            // 플레이어의 위치를 기준으로 상호작용할 객체 탐색
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, interactDistance, interactableLayer);
            if (hit.collider != null)
            {
                // 상호작용할 객체가 있을 경우
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact(); // 상호작용 메서드 호출
                }
            }
        }
    }
}
