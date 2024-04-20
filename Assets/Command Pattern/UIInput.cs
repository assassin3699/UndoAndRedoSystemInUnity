using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command_Pattern
{
    public class UIInput : MonoBehaviour
    {
        private static int NumberOfInputs =>  Enum.GetNames(typeof(InputKeyCode)).Length;
        private static List<bool> _inputs;
        private static List<bool> _lastFrameInputs;

        public UIInput()
        {
            _inputs = new List<bool>();
            _lastFrameInputs =  new List<bool>();
            for (int i = 0; i < NumberOfInputs; i++)
            {
                _inputs.Add(false); 
                _lastFrameInputs.Add(false);
            }
           
        }

        private void Awake()
        {
            StartCoroutine(UpdateLoop());
        }

        public static void InvokeInput(InputKeyCode keyCode)
        {
            _lastFrameInputs[(int)keyCode] = true;
        }
        
        public static bool GetInputDown(InputKeyCode keyCode)
        {
            return _inputs[(int)keyCode];
        }

        private static void UpdateTheInputs()
        {
            for (int i = 0; i < _inputs.Count; i++)
            {
                _inputs[i] = _lastFrameInputs[i];
                _lastFrameInputs[i] = false;
            }
        }

        private IEnumerator UpdateLoop()
        {
            while (this.gameObject.activeSelf)
            {
                UpdateTheInputs(); 
                yield return new WaitForEndOfFrame();
            }
            yield return null;

        }
    }
}
