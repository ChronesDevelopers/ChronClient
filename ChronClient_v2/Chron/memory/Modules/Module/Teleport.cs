using ChronClient.Instance;
using ChronClient.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChronClient.Module
{
    public static class Teleport
    {
        public static void Tp(float? X, float? Y, float? Z)
        {
            Entity entity = LocalPlayer.entity;

            entity.X = X;
            entity.Y = Y;
            entity.Z = Z;
        }
    }
}
