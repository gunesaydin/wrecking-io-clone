using UnityEngine;

namespace __Game.__Scripts.Interfaces
{
    public interface ICar
    {
        public float MoveSpeed { get; }
        
        public void Move();
        public void Turn();
    }
}