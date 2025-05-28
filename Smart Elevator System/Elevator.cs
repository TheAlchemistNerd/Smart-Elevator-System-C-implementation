namespace Smart_Elevator_System
{
    public class Elevator
    {
        public int Id { get; }
        public int CurrentFloor { get; private set; } = 0;
        public bool IsMoving { get; private set; }

        public Direction CurrentDirection { get; private set; } = Direction.Up;

        private readonly PriorityQueue<int, int> _floorQueue = new();

        public Elevator(int id)
        {
            Id = id;
        }

        public void AddRequest(int floor)
        {
            _floorQueue.Enqueue(floor, floor);
            Console.WriteLine($"[Elevator {Id}] Request added for floor {floor}");
        }

        public void Step()
        {
            if (_floorQueue.TryDequeue(out var nextFloor, out _))
            {
                MoveToFloor(nextFloor);
            }
        }

        private void MoveToFloor(int floor)
        {
            IsMoving = true;
            Console.WriteLine($"[Elevator {Id}] Moving from {CurrentFloor} to {floor}");
            Thread.Sleep(Math.Abs(CurrentFloor - floor) * 500);
            CurrentFloor = floor;
            Console.WriteLine($"[Elevator {Id}] Arrived at floor {floor}");
            IsMoving = false;
        }
    }
}
