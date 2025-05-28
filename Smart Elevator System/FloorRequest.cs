namespace Smart_Elevator_System
{
    public enum Direction
    {
        Up,
        Down
    }
    public class FloorRequest
    {
        public int FloorNumber { get; }
        public Direction Direction { get; }

        public FloorRequest(int floor, Direction direction)
        {
            FloorNumber = floor;
            Direction = direction;
        }

        public override string ToString() => $"Request to floor {FloorNumber} ({Direction})";
    }
}