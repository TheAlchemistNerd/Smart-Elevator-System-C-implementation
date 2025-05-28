namespace Smart_Elevator_System
{
    public class SimpleElevatorSystem : IRequestObserver
    {
        private Elevator elevator = new(1);

        public void OnNewRequest(FloorRequest request)
        {
            elevator.AddRequest(request.FloorNumber);
            elevator.Step();
        }
    }
}
