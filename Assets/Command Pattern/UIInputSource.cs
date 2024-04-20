using UnityEngine;
namespace Command_Pattern
{
    public class UIInputSource : MonoBehaviour
    {
        [SerializeField]private InputKeyCode inputKeyCode;
        public void OnClick()
        {
            UIInput.InvokeInput(inputKeyCode);
        }
    }
}
