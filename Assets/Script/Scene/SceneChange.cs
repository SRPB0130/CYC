using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CYC
{
    public class SceneChange : MonoBehaviour
    {
        public string targetSceneName = "TargetScene";  // ��ȯ�� �� �̸�

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // �浹�� ������Ʈ�� �±װ� "Player"�� ��� �� ��ȯ
            if (collision.gameObject.CompareTag("Player"))
            {
                // ���� ��ȯ�մϴ�.
                SceneManager.LoadScene(targetSceneName);
            }
        }

        // �Ǵ� Ʈ���ŷ� �����ϰ� �ʹٸ� OnTriggerEnter2D�� ������ �� �ֽ��ϴ�.
        private void OnTriggerEnter2D(Collider2D collider)
        {
            // �浹�� ������Ʈ�� �±װ� "Player"�� ��� �� ��ȯ
            if (collider.CompareTag("Player"))
            {
                // ���� ��ȯ�մϴ�.
                SceneManager.LoadScene(targetSceneName);
            }
        }
    }
}
