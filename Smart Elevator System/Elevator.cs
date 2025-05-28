namespace Smart_Elevator_System
{
    public class Elevator
    {
        public int Id { get; }
        public int CurrentFloor { get; private set; } = 0;
        public bool IsMoving { get; private set; }

        public Direction CurrentDirection { get; private set; } = Direction.Up;

        private readonly PriorityQueue<int, int> _floorQueue = new();
        
        private readonly object _lock = new();
        private bool _running = true;

        public Elevator(int id)
        {
            Id = id;
        }

        public void AddRequest(int floor)
        {
            lock (_lock)
            {
                _floorQueue.Enqueue(floor, floor);
                Console.WriteLine($"[Elevator {Id}] Request added for floor {floor}");
            }
        }

        public void Run()
        {
            while(_running)
            {
                int? nextFloor = null;
                lock (_lock)
                {
                    if (_floorQueue.TryDequeue(out var floor, out _))
                        nextFloor = floor;
                }

                if (nextFloor.HasValue)
                    MoveToFloor(nextFloor.Value);

                Thread.Sleep(100); // Small wait between checks
            }
        }

        public void Stop() => _running = false;
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

            if (floor > CurrentFloor)
                CurrentDirection = Direction.Up;
            else if (floor < CurrentFloor)
                CurrentDirection = Direction.Down;

            Console.WriteLine($"[Elevator {Id}] Moving from {CurrentFloor} to {floor}");
            Thread.Sleep(Math.Abs(CurrentFloor - floor) * 500);
            CurrentFloor = floor;
            Console.WriteLine($"[Elevator {Id}] Arrived at floor {floor}");
            IsMoving = false;
        }
    }
}
