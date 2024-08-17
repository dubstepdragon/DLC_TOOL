using System.Collections.Generic;
using DLC_TOOLS.Tools;
#if UNITY_EDITOR
using UnityEditor.Animations;
#endif
using UnityEngine;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace DLC_TOOLS.Tools
{
    public class DUB_DLC : MonoBehaviour
    {
        //TODO test runtime animator controller and merge later on. 
#if UNITY_EDITOR
        public AnimatorController dlcFX;
#endif
        public VRCExpressionsMenu DLC_Menu;

        public VRCExpressionParameters DLC_Parameters;
        
        public List<GOToBone> gameObjectsToBones = new List<GOToBone>();
        
    }
    
    
}
