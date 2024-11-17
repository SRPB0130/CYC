using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class PlayerAttacks : MonoBehaviour
    {
        [SerializeField] GameObject bulletPref;

        [SerializeField] private float firePower = 15f; // �߻� ��
        [SerializeField] private float fireDelay = 0.1f; // �߻� ������
        private float lastFireTime = 0; // ������ �߻� �ð�


        public void Fire()
        {

            if (Time.time - lastFireTime >= fireDelay)
            {
                Vector3 direction = transform.right * transform.localScale.x; // �÷��̾��� ���⿡ ���� �߻� ���� ����
                GameObject bullet = Instantiate(bulletPref, transform.position + direction, Quaternion.identity);

                // �÷��̾��� ���⿡ ���� ����ü ��������Ʈ ������ ����
                float bulletDirection = transform.localScale.x > 0 ? 1f : -1f;
                bullet.transform.localScale = new Vector3(bulletDirection, 1f, 1f);

                bullet.GetComponent<Rigidbody2D>().AddForce(direction * firePower, ForceMode2D.Impulse);

                lastFireTime = Time.time; // ������ �߻� �ð� ������Ʈ
            }
        }
    }
}
