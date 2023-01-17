using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voyage_Engine.Rendere_Engine.Vector;

namespace Voyage_Engine.Physics_Engine.Collision
{
    internal class Line
    {
        private string _lineName;
        private Vector2 _pointA;
        private Vector2 _pointB;
        private float _distance;

        public string LineName => _lineName;
        public float Distance => _distance;

        public Line(string lineName, Vector2 pointA, Vector2 pointB) 
        { 
            _lineName = lineName;
            _pointA = pointA;
            _pointB = pointB;
            _distance = Vector2.Distance(_pointA, _pointB);
        }
    }
}
