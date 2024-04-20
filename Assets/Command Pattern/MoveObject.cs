using UnityEngine;
namespace Command_Pattern
{
    public class MoveObject : ICommand
    {
        private readonly Actor _object;
        private readonly CommandData _commandData;
        public MoveObject(Actor obj, CommandData commandData) { _object = obj;
            _commandData = commandData;
        }
        public void Execute()
        {
            MoveTo(_commandData.XMoveDir,_commandData.YMoveDir);
        }
        private void MoveTo( float xAxis, float yAxis)
        {
            var position = _object.actorTransform.transform.position;
            _object.actorTransform.position= new Vector3(position.x + xAxis, position.y + yAxis, position.z);
        }
    }
}