using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateROIEditor.Math
{
    public class Vector2 : Object
    {
        public const float kEpsilon = 1e-005f;

        // Summary:
        //     X component of the vector.
        public float x;
        //
        // Summary:
        //     Y component of the vector.
        public float y;

        public Vector2()
        {
            x = y = 0;
        }
        //
        // Summary:
        //     Constructs a new vector with given x, y components.
        //
        // Parameters:
        //   x:
        //
        //   y:
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 operator -(Vector2 a)
        {
            return new Vector2(-a.x, -a.y);
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(b.x - a.x, b.y - a.y);
        }
        public static bool operator !=(Vector2 lhs, Vector2 rhs)
        {
            return ((lhs.x != rhs.x) || (lhs.y != rhs.y));
        }
        public static Vector2 operator *(float d, Vector2 a)
        {
            return new Vector2(a.x * d, a.y * d);
        }
        public static Vector2 operator *(Vector2 a, float d)
        {
            return new Vector2(a.x * d, a.y * d);
        }
        public static Vector2 operator /(Vector2 a, float d)
        {
            return new Vector2(a.x / d, a.y / d);
        }
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
        public static bool operator ==(Vector2 lhs, Vector2 rhs)
        {
            return ((lhs.x == rhs.x) && (lhs.y == rhs.y));
        }
        //public static implicit operator Vector3(Vector2 v);
        //public static implicit operator Vector2(Vector3 v);

        // Summary:
        //     Shorthand for writing @@Vector2(0, -1)@@.
        public static Vector2 down { get { return new Vector2(0, -1); } }
        //
        // Summary:
        //     Shorthand for writing @@Vector2(-1, 0)@@.
        public static Vector2 left { get { return new Vector2(-1, 0); } }
        //
        // Summary:
        //     Returns the length of this vector (RO).
        public float magnitude 
        {
            get { return (float)System.Math.Sqrt(x*x + y*y);  }
        }
        //
        // Summary:
        //     Returns this vector with a ::ref::magnitude of 1 (RO).
        public Vector2 normalized
        {
            get { return (this / magnitude);  }
        }
        //
        // Summary:
        //     Shorthand for writing @@Vector2(1, 1)@@.
        public static Vector2 one { get { return new Vector2(1, 1); } }
        //
        // Summary:
        //     Shorthand for writing @@Vector2(1, 0)@@.
        public static Vector2 right { get { return new Vector2(1, 0); } }
        //
        // Summary:
        //     Returns the squared length of this vector (RO).
        public float sqrMagnitude
        {
            get { return (x * x + y * y); }
        }
        //
        // Summary:
        //     Shorthand for writing @@Vector2(0, 1)@@.
        public static Vector2 up { get { return new Vector2(0, 1); } }
        //
        // Summary:
        //     Shorthand for writing @@Vector2(0, 0)@@.
        public static Vector2 zero { get { return new Vector2(0, 0); } }

        public float this[int index]
        {
            get 
            {
                return (index == 0 ? x : y);
            }
            set 
            {
                if (index == 0)
                    x = value;
                else
                    y = value;
            }
        }

        // Summary:
        //     Returns the angle in degrees between /from/ and /to/.
        //
        // Parameters:
        //   from:
        //
        //   to:
        //public static float Angle(Vector2 from, Vector2 to); //TODO !!!
        //
        // Summary:
        //     Returns a copy of /vector/ with its magnitude clamped to /maxLength/.
        //
        // Parameters:
        //   vector:
        //
        //   maxLength:
        public static Vector2 ClampMagnitude(Vector2 vector, float maxLength) //TODO !!!
        {
            if (vector.magnitude <= maxLength)
                return vector;
            else
                return vector; /////!!!!!!!!!!!!!!!
        }
        //
        // Summary:
        //     Returns the distance between /a/ and /b/.
        //
        // Parameters:
        //   a:
        //
        //   b:
        public static float Distance(Vector2 a, Vector2 b)
        {
            return (b - a).magnitude;
        }
        //
        // Summary:
        //     Dot Product of two vectors.
        //
        // Parameters:
        //   lhs:
        //
        //   rhs:
        public static float Dot(Vector2 a, Vector2 b)
        { 
            return (a.x * b.x + a.y * b.y);
        }

        public override bool Equals(object other)
        {
            Vector2 vec = (Vector2)other;
            return (x == vec.x && y == vec.y);
        }

        public override int GetHashCode()
        {
            return 0;
        }
        //
        // Summary:
        //     Linearly interpolates between vectors /a/ and /b/ by /t/.
        //
        // Parameters:
        //   a:
        //
        //   b:
        //
        //   t:
        //public static Vector2 Lerp(Vector2 a, Vector2 b, float t); //TODO !!!
        //
        // Summary:
        //     Linearly interpolates between vectors /a/ and /b/ by /t/.
        //
        // Parameters:
        //   a:
        //
        //   b:
        //
        //   t:
        //public static Vector2 LerpUnclamped(Vector2 a, Vector2 b, float t); //TODO !!!
        //
        // Summary:
        //     Returns a vector that is made from the largest components of two vectors.
        //
        // Parameters:
        //   lhs:
        //
        //   rhs:
        public static Vector2 Max(Vector2 a, Vector2 b)
        {
            return new Vector2(System.Math.Max(a.x, b.x),
                                System.Math.Max(a.y, b.y));
        }
        //
        // Summary:
        //     Returns a vector that is made from the smallest components of two vectors.
        //
        // Parameters:
        //   lhs:
        //
        //   rhs:
        public static Vector2 Min(Vector2 a, Vector2 b)
        {
            return new Vector2(System.Math.Min(a.x, b.x), 
                                System.Math.Min(a.y, b.y));
        }
        //
        // Summary:
        //     Moves a point /current/ towards /target/.
        //
        // Parameters:
        //   current:
        //
        //   target:
        //
        //   maxDistanceDelta:
        //public static Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta); //TODO !!!
        //
        // Summary:
        //     Makes this vector have a ::ref::magnitude of 1.
        public void Normalize()
        {
            x /= magnitude;
            y /= magnitude;
        }
        //
        // Summary:
        //     Reflects a vector off the vector defined by a normal.
        //
        // Parameters:
        //   inDirection:
        //
        //   inNormal:
        //public static Vector2 Reflect(Vector2 inDirection, Vector2 inNormal); //TODO !!!
        //
        // Summary:
        //     Multiplies every component of this vector by the same component of /scale/.
        //
        // Parameters:
        //   scale:
        public void Scale(Vector2 scale)
        {
            x = x * scale.x;
            y = y * scale.y;
        }
        //
        // Summary:
        //     Multiplies two vectors component-wise.
        //
        // Parameters:
        //   a:
        //
        //   b:
        public static Vector2 Scale(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }
        //
        // Summary:
        //     Set x and y components of an existing Vector2.
        //
        // Parameters:
        //   new_x:
        //
        //   new_y:
        public void Set(float new_x, float new_y)
        {
            x = new_x;
            y = new_y;
        }
        
        //public static Vector2 SmoothDamp(Vector2 current, Vector2 target, ref Vector2 currentVelocity, float smoothTime);
        
        //public static Vector2 SmoothDamp(Vector2 current, Vector2 target, ref Vector2 currentVelocity, float smoothTime, float maxSpeed);
        //public static Vector2 SmoothDamp(Vector2 current, Vector2 target, ref Vector2 currentVelocity, float smoothTime, float maxSpeed, float deltaTime);
        public float SqrMagnitude()
        { 
            return (x * x + y * y);   
        }
        public static float SqrMagnitude(Vector2 a)
        { 
            return (a.x * a.x + a.y * a.y);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }
        //public string ToString(string format);
    }
}
