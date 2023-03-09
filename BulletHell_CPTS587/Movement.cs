using CPTS587.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell_CPTS587
{
    public class Movement
    {
        private Vector2 _position;
        private float _elapsedTime;
        private float _speed;
        public bool Istrue { get; set; }

        public Movement()
        {
        }

        public void updatePosition(Vector2 position, float elapsedTime, float speed)
        {
            _position = position;
            _elapsedTime = elapsedTime;
            _speed = speed;
        }

        public float moveRight(float X)
        {
            X = _position.X + _speed * _elapsedTime;

            return X;
        }


        public float moveLeft(float X)
        {
            X = _position.X - _speed * _elapsedTime;

            return X;
        }

    }
}
