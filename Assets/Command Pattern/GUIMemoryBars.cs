using UnityEngine;
namespace Command_Pattern
{ 
    public class GUIMemoryBars : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] GUIStyle style = new GUIStyle();
        [SerializeField] private float boxSize;
        [SerializeField] private ActorController actorController;
        [SerializeField] private float lableHieght;
        private void OnGUI()
        {
            var numberOfBoxes = actorController.CommandsStorageCapacity;
            var stack = actorController.CommandsStack.ToArray();
            var ofBoxes = Screen.width/numberOfBoxes;
            var height = Screen.height /boxSize;
            GUI.Box(new Rect(ofBoxes -(ofBoxes), lableHieght, Screen.width, height), "List Of Inputs",style);
            for (int i = 0; i < actorController.CommandsList.Count; i++)
            {
                GUI.Box(new Rect((ofBoxes * i),  height/5 , ofBoxes , height), "X : " +actorController.CommandsList[i].XMoveDir + " Y : " +actorController.CommandsList[i].YMoveDir  ,style);
            }
            GUI.Box(new Rect(ofBoxes - (ofBoxes), height + (lableHieght *2) , Screen.width, height), "Stack",style);
            for (int i = 0; i < stack.Length; i++)
            {
                GUI.Box(new Rect((ofBoxes * i), (height * 1) + height/5, ofBoxes , height), "X : " +stack[(stack.Length - 1) -i].XMoveDir + " Y : " +stack[(stack.Length - 1) -i].YMoveDir ,style);
            }
           
        }
#endif
    }
}
