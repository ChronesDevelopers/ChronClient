using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Chrones.Cmr
{
    public static class cmr_math
    {
        public static Vector2? TargetPositionToAngle(Vector3? from, Vector3? to)
        {
            if (from == null || to == null)
            {
                return null;
            }
            if (from == to)
            {
                return null;
            }

            Vector3 _from = (Vector3)from;
            Vector3 _to = (Vector3)to;

            try
            {
                Vector2 _return = new Vector2();
                float dX = _from.X - _to.X;
                float dY = _from.Y - _to.Y;
                float dZ = _from.Z - _to.Z;
                double distance = Math.Sqrt((dX * dX) + (dY * dY) + (dZ + dZ));

                _return.X = ((float)Math.Atan2(dY, (float)distance) * (float)3.13810205 / (float)3.141592653589793);
                _return.Y = -((float)Math.Atan2(dZ, dX) * (float)3.13810205 / (float)3.141592653589793) + (float)1.569051027;
                
                return (Vector2?)_return;
            } catch { return null; }
        }
        public static Vector2? TargetPositionToAngle(Vector3 from, Vector3 to)
        {
            if (from == to)
            {
                return null;
            }

            Vector2 _return;

            Vector3 delta = from - to;
            float hyp = (float)Math.Sqrt((delta.X * delta.X) + (delta.Y * delta.Y) + (delta.Z * delta.Z));
            _return.X = (float)Math.Atan(delta.Z / hyp) * 180f / (float)Math.PI;
            _return.Y = (float)Math.Atan(delta.Y / delta.X) * 180f / (float)Math.PI;

            if (delta.X >= 0)
            {
                _return.Y += 180f;
            }

            return _return;
        }
        public static double GetDistance(Vector2 from, Vector2 to)
        {
            return Math.Sqrt((to.X - from.X) * (to.X - from.X) + (to.Y - from.Y) * (to.Y - from.Y));
        }
        public static double GetDistance(Vector3 from, Vector3 to)
        {
            return Math.Sqrt((to.X - from.X) * (to.X - from.X) + (to.Y - from.Y) * (to.Y - from.Y) + (to.Z - from.Z) * (to.Z - from.Z));
        }

        public static Vector2? WorldToScreen(Vector3 from, Vector3 target, Vector2 screen, Vector2 fov)
        {
            target -= from;

            float x = 0f; // Transform
            float y = 0f; // Transform
            float z = 0f; // Transform

            if (z > 0f) 
            {
                return null;
            }

            Vector2 mscreen = screen / 2f;

            Vector2 ret = new Vector2();
            ret.X = mscreen.X + (mscreen.X * x / -z * fov.X);
            ret.X = mscreen.Y + (mscreen.Y * y / -z * fov.Y);

            return ret;
        }
        public static float TransformX(Vector3 p, Vector4 v)
	    {
	    	return p.X* v.X + p.Y* v.Y + p.Z* v.Z + v.W;
	    }
        public static float TransformY(Vector3 p, Vector4 v)
        {
            return p.X * v.X + p.Y * v.Y + p.Z * v.Z + v.W;
        }
        public static float TransformZ(Vector3 p, Vector4 v)
        {
            return p.X * v.X + p.Y * v.Y + p.Z * v.Z + v.W;
        }
    }
}
