using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLC_TOOLS.Tools
{
    [Serializable]
    public class GOToBone
    {
        public string TargetBoneName;
        public List<GameObject> GameObjects = new List<GameObject>();
    }
}
