using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.Modules
{
    public static class OnLoad
    {
        public static void Start()
        {
            Module.Airjump.OnLoad();
            Module.AirWalk.OnLoad();
            Module.Antivoid.OnLoad();
            Module.BlockReach.OnLoad();
            Module.ClickTp.OnLoad(); //!
            Module.CubecraftFly.OnLoad();
            Module.CustomTime.OnLoad();
            Module.DirectionalBoost.OnLoad();
            Module.Fly.OnLoad();
            Module.FreeView.OnLoad();
            Module.Fullbright.OnLoad();
            Module.Glide.OnLoad();
            Module.Highjump.OnLoad();
            Module.Hitbox.OnLoad();
            Module.Instabreak.OnLoad();
            Module.Jetpack.OnLoad();
            Module.Killaura.OnLoad();
            Module.LongJump.OnLoad();
            Module.NoFall.OnLoad();
            Module.NoHungerSlowDown.OnLoad();
            Module.NoJumpDelay.OnLoad();
            Module.NoKnockBack.OnLoad();
            Module.NoSwing.OnLoad();
            Module.NoWater.OnLoad();
            Module.NoWeb.OnLoad();
            Module.RapidHit.OnLoad();
            Module.Reach.OnLoad();
            Module.Reverse.OnLoad();
            Module.Scaffold.OnLoad();
            Module.Speed.OnLoad();
            Module.SpeedFall.OnLoad();
            Module.Step.OnLoad();
            Module.TpAura.OnLoad(); //!

            Module.NOKEYBINDS.OnLoad();
        }
    }
}
