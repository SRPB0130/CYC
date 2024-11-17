using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CYC
{
    public class SceneChange : MonoBehaviour
    {
        public string targetSceneName = "TargetScene";  // 전환할 씬 이름

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // 충돌한 오브젝트의 태그가 "Player"일 경우 씬 전환
            if (collision.gameObject.CompareTag("Player"))
            {
                // 씬을 전환합니다.
                SceneManager.LoadScene(targetSceneName);
            }
        }

        // 또는 트리거로 감지하고 싶다면 OnTriggerEnter2D로 변경할 수 있습니다.
        private void OnTriggerEnter2D(Collider2D collider)
        {
            // 충돌한 오브젝트의 태그가 "Player"일 경우 씬 전환
            if (collider.CompareTag("Player"))
            {
                // 씬을 전환합니다.
                SceneManager.LoadScene(targetSceneName);
            }
        }
    }
}
