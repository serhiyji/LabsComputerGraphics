using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public class BaseWindow : GameWindow
    {
        public BaseWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
            VSync = VSyncMode.On;
        }
        public BaseWindow((GameWindowSettings gws, NativeWindowSettings nws) settings) : base(settings.gws, settings.nws) { VSync = VSyncMode.On; }
        public BaseWindow():base(null, null) { VSync = VSyncMode.On; }

        public static (GameWindowSettings gws, NativeWindowSettings nws) DefaultSetupWindow()
        {
            GameWindowSettings gws = GameWindowSettings.Default;
            NativeWindowSettings nws = new NativeWindowSettings()
            {
                Size = new OpenTK.Mathematics.Vector2i(1024, 1024),

                IsEventDriven = false,
                API = ContextAPI.OpenGL,
                APIVersion = new Version(4, 6),
                AutoLoadBindings = true,
                StartFocused = true,
                Title = "Labs",
                WindowBorder = WindowBorder.Resizable,
                WindowState = WindowState.Normal,
                Flags = ContextFlags.Default,
                Profile = ContextProfile.Compatability,

                NumberOfSamples = 0
            };
            return (gws, nws);
        }

        protected override void OnLoad()
        {
            base.OnLoad();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, e.Size.X, e.Size.Y);
            base.OnResize(e);
        }
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
        }

        protected override void OnUnload()
        {
            base.OnUnload();
        }
    }
}
