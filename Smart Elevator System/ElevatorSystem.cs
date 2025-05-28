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
        }

        public void OnNewRequest(FloorRequest request)
        {
            // Pick the first idle elevator
            var elevator = _elevators.FirstOrDefault(e => !e.IsMoving) ?? _elevators.First();
            elevator.AddRequest(request.FloorNumber);
        }
    }
}
