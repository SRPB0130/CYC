using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class UserDataDTO { }
    [System.Serializable]
    public class PlayerSessionDTO : UserDataDTO
    {
        public Vector3 lastPosition;
        public float lastHP;
        public float lastMP;
    }
    [System.Serializable]
    public class PlayerDTO : UserDataDTO
    {
        public string nickname;
        public int level;
        public int money;
        public float exp;
    }

}
