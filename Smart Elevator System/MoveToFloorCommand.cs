using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Elevator_System
{
    public class MoveToFloorCommand : IElevatorCommand
    {
        private readonly int _targetFloor;

        public MoveToFloorCommand(int targetFloor)
        {
            _targetFloor = targetFloor;
        }

        public void Execute(Elevator elevator)
        {
            elevator.AddRequest(_targetFloor);
        }
    }
}
