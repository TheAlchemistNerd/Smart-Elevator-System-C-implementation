namespace Smart_Elevator_System
{
    
    public class ElevatorSystem : IRequestObserver
    {
        private readonly List<Elevator> _elevators;

        public ElevatorSystem(int numberOfElevators)
        {
            _elevators = Enumerable.Range(1, numberOfElevators)
                                   .Select(id => new Elevator(id))
                                   .ToList();

            // Start Elevators in parallel
            foreach(var elevator in _elevators)
            {
                Task.Run(() => elevator.Run());
            }
        }

        public void OnNewRequest(FloorRequest request)
        {
            /*
            // Pick the first idle elevator - Naive approach
            var elevator = _elevators.FirstOrDefault(e => !e.IsMoving) ?? _elevators.First();
            elevator.AddRequest(request.FloorNumber);
            */

            var bestElevator = _elevators
                .Where(e => !e.IsMoving || (e.CurrentDirection == request.Direction &&
                                            ((e.CurrentDirection == Direction.Up && e.CurrentFloor <= request.FloorNumber) ||
                                             (e.CurrentDirection == Direction.Down && e.CurrentFloor >= request.FloorNumber))))
                .OrderBy(e => Math.Abs(e.CurrentFloor - request.FloorNumber))
                .FirstOrDefault();

            // Fallback if none matched: 
            (bestElevator ??= _elevators.First()).AddRequest(request.FloorNumber);
        }
    }
}
