using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using VRC.SDK3.Avatars.ScriptableObjects;
using XRDUB_VRC_TOOLS.Scripts;
using UnityEditor.Animations;
using XRDUB.AMP.Core;

namespace XRDUB_VRC_TOOLS.Editor
{
    [CustomEditor(typeof(DLC), true)]
    public class DLC_INSPECTOR : UnityEditor.Editor
    {
        private int selectedAvatar = 0;

        private VRCAvatarDescriptor[] avatarsInScene;

        public static string dlcMenuLocation = "Assets/ironicsoap/DLC/";

        public void OnEnable()
        {
            avatarsInScene = FindObjectsOfType<VRCAvatarDescriptor>();
            
        }

        public override void OnInspectorGUI()
        {
            var dlc = target as DLC;

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Tool Made by DubstepDragon if you have any questions click the button!");
            if (GUILayout.Button("Click Me!"))
            {
                Application.OpenURL("dubby.dev");
            }
            EditorGUILayout.EndHorizontal();
            
            base.OnInspectorGUI();

            EditorGUILayout.BeginHorizontal();

            GUI.enabled = avatarsInScene.Length != 0;
            string[] avatars = avatarsInScene.Select(i => i.gameObject.name).ToArray();
            selectedAvatar = EditorGUILayout.Popup(selectedAvatar, avatars);
            
            if (GUILayout.Button("Add DLC"))
            {
                
                if(!Directory.Exists(dlcMenuLocation))
                {	
                    //if it doesn't, create it
                    Directory.CreateDirectory(dlcMenuLocation);
                    AssetDatabase.Refresh();
                }
                
                PrefabUtility.UnpackPrefabInstance(dlc.gameObject, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
                
                HandleAnimatorMenuParameters(dlc);
                MoveGameObjects(dlc);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                DestroyImmediate(dlc.gameObject);
            }
            GUI.enabled = true;
            
            EditorGUILayout.EndHorizontal();
        }

        private void HandleAnimatorMenuParameters(DLC dlc)
        {
            AnimatorController AvatarAnimator = avatarsInScene[selectedAvatar]
                .baseAnimationLayers.FirstOrDefault(i => i.type == VRCAvatarDescriptor.AnimLayerType.FX)
                .animatorController as AnimatorController;
            VRCExpressionsMenu AvatarMenu = avatarsInScene[selectedAvatar].expressionsMenu;
            VRCExpressionParameters AvatarParameters = avatarsInScene[selectedAvatar].expressionParameters;
                
            //Merge Animator, menu and parameters
            XRDUB.AMP.Core.XRDUB.HandleAnimatorComp(dlc.dlcFX, AvatarAnimator);
            XRDUB.AMP.Core.XRDUB.HandleMenu(dlc.DLC_Menu, AvatarMenu, "DLC", dlcMenuLocation);
            XRDUB.AMP.Core.XRDUB.HandleParameters(dlc.DLC_Parameters, AvatarParameters);
        }

        private void MoveGameObjects(DLC dlc)
        {
            //Get Armature and move Game Objects
            List<GameObject> ArmatureGOs = new List<GameObject>();

            Transform Armature = avatarsInScene[selectedAvatar].gameObject.transform.Find("Armature");
            XRDUB_UTILS.TraverseHierarchy(Armature, ArmatureGOs);

            foreach (var GOToBone in dlc.gameObjectsToBones)
            {
                GameObject bone = ArmatureGOs.Find(bone => bone.name == GOToBone.TargetBoneName);
                if (bone)
                {
                    foreach (var toMove in GOToBone.GameObjects)
                    {
                        toMove.transform.parent = bone.transform;
                    }
                }
            }
        }
    }
}
