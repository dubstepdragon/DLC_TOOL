using System.Collections.Generic;
using DLC_TOOLS.Tools;
using UnityEditor.Animations;
using UnityEngine;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace DLC_TOOLS.Tools
{
    public class DUB_DLC : MonoBehaviour
    {
        public AnimatorController dlcFX;

        public VRCExpressionsMenu DLC_Menu;

        public VRCExpressionParameters DLC_Parameters;
        
        public List<GOToBone> gameObjectsToBones = new List<GOToBone>();
        
    }
    
    
}
