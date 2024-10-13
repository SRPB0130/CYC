using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CYC
{
    public class CamaraSystem : MonoBehaviour
    {
        public float cameraSpeed = 10f;
        public Transform character;

        private Vector3 targetposition;


        //private void Start()
        //{
        //    // 카메라의 초기 위치를 캐릭터 위치에 맞추고 Z축을 고정
        //    targetposition = new Vector3(character.position.x, character.position.y, -10);
        //}

        private void Update()
        {
            // 기본적으로 카메라의 목표 위치를 캐릭터의 위치로 설정
            targetposition = new Vector3(character.position.x, character.position.y, -10);

            // LeftControl 키를 누르면 카메라가 왼쪽으로 이동
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    targetposition += new Vector3(-9, 0, -10);  // 왼쪽으로 이동
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    targetposition += new Vector3(9, 0, -10);  // 오른쪽으로 이동
                }
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    targetposition += new Vector3(0, 6, -10);  // 위쪽으로 이동
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    targetposition += new Vector3(0, -6, -10);  // 아래쪽으로 이동
                }
            }


            MoveCamera();
        }

        void MoveCamera()
        {
            //카메라가 지정 방향으로 움직임
            transform.position = Vector3.Lerp(transform.position, targetposition, cameraSpeed * Time.deltaTime);
        }
    }
}