namespace SpaceBattle.Lib;
{

    public struct Vector
    {
        public double X { get; set; }
        public double Y { get; set; }

        // Конструктор
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
    
    public interface IMovable
    {
        Vector Position { get; set; }
        Vector Velocity { get; }

        void StartMove(Vector velocity);
        void StopMove();
    }

    public interface IRotatable
    {
        double Angle { get; set; }

        double AngularVelocity { get; }

        void StartRotate(double angularVelocity);

        void StopRotate();
    }

    namespace SpaceBattle.Lib
{
    public class MoveCommand : ICommand
    {
        private IMovable _movable;

        public MoveCommand(IMovable movable)
        {
            _movable = movable;
        }

        public void Execute()
        {
            //логики
        }
    }

        public class RotateCommand : ICommand
    {
        private IRotatable _rotatable;

        public RotateCommand(IRotatable rotatable)
        {
            _rotatable = rotatable;
        }

        public void Execute()
        {
            //логика
        }
    }


}


}

