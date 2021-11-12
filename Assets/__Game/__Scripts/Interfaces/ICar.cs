namespace __Game.__Scripts.Interfaces
{
    public interface ICar
    {
        public void Accelerate(float vector);
        public void Break();
        public void Turn(float angle);
    }
}