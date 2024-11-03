using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.LucidEditor;
using CYC;


    namespace Cainos.PixelArtPlatformer_VillageProps
{
        public class Chest : MonoBehaviour
    {

            public GameObject itemPrefab;
            public Transform spawnPoint;

            [FoldoutGroup("Reference")]
            public Animator animator;

        [FoldoutGroup("Runtime"), ShowInInspector, DisableInEditMode]
            public bool IsOpened
            {
                get { return isOpened; }
                set
                {
                    isOpened = value;
                    animator.SetBool("IsOpened", isOpened);
                }
            }
            private bool isOpened;

        [FoldoutGroup("Runtime"), Button("Open"), HorizontalGroup("Runtime/Button")]
            public void Open()
            {
                IsOpened = true;
                Debug.Log("상자가 열렸습니다!");

                // 아이템 생성
                Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);
        }

            [FoldoutGroup("Runtime"), Button("Close"), HorizontalGroup("Runtime/Button")]
            public void Close()
            {
                IsOpened = false;
            }

        
    }
    }
