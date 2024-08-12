using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace XRDUB_VRC_TOOLS.Scripts
{
    public class DLC : MonoBehaviour
    {
        public AnimatorController dlcFX;

        public VRCExpressionsMenu DLC_Menu;

        public VRCExpressionParameters DLC_Parameters;
        
        public List<GOToBone> gameObjectsToBones = new List<GOToBone>();
        
    }
    
    
}
