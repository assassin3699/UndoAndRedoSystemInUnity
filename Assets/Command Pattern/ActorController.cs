using System.Collections.Generic;
using UnityEngine;
namespace Command_Pattern
{
    public class ActorController : MonoBehaviour
    {
        [SerializeField]private Actor actor;
        [SerializeField] private int commandsStorageCapacity;
        private ICommand _currentInput;
        private List<CommandData> _commandsList;
        private Stack<CommandData> _commandsStack;
        private ICommand _nullCommand;
        private void Awake()
        {
            _nullCommand = new MoveObject(actor,new CommandData(0, 0));
            _commandsList = new List<CommandData>();
            _commandsStack = new Stack<CommandData>();
        }

        public void Update()
        {
            MoveTheActor();
        }

        private void MoveTheActor()
        {
            _currentInput = HandleInput();
            _currentInput.Execute();
        }
        private ICommand HandleInput()
        {
            if (UIInput.GetInputDown(InputKeyCode.Up))
            {
                ClearStack();
                return new MoveObject(actor, AddCommand(0, 1f));
            }
            if (UIInput.GetInputDown(InputKeyCode.Down))
            {
                ClearStack();
                return new MoveObject(actor, AddCommand(0, -1f));
            }
            if (UIInput.GetInputDown(InputKeyCode.Left))
            {
                ClearStack();
                return new MoveObject(actor, AddCommand(-1f, 0));
            }
            if (UIInput.GetInputDown(InputKeyCode.Right))
            {
                ClearStack();
                return new MoveObject(actor,AddCommand(1f, 0));
            }
            if (UIInput.GetInputDown(InputKeyCode.Undo))
            {
                if (_commandsList.Count <= 0) return _nullCommand;
                _commandsStack.Push(_commandsList[^1]);
                var command = new MoveObject(actor, new CommandData(-_commandsList[^1].XMoveDir, -_commandsList[^1].YMoveDir));
                _commandsList.RemoveAt(_commandsList.Count -1);
                return command;
            }
            if (UIInput.GetInputDown(InputKeyCode.Redo))
            {
                if (_commandsStack.Count <= 0) return _nullCommand;
                var commandData = _commandsStack.Pop();
                _commandsList.Add(commandData);
                return new MoveObject(actor, commandData);
            }
            return _nullCommand;
        }
        private void ClearStack()
        {
            _commandsStack.Clear();
        }
        private CommandData AddCommand(float x, float y)
        {
            var command = new CommandData(x, y);
            if (_commandsList.Count == commandsStorageCapacity) _commandsList.RemoveAt(0);
            _commandsList.Add(command);    
            return command;
        }
#if UNITY_EDITOR        
        public int CommandsStorageCapacity => commandsStorageCapacity;

        public List<CommandData> CommandsList => _commandsList;

        public Stack<CommandData> CommandsStack => _commandsStack;
#endif
    }
}
