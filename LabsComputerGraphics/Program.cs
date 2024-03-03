using System;

using OpenTK;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Drawing;

namespace LabsComputerGraphics
{
    public class BaseWindow : GameWindow
    {
        public BaseWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
            VSync = VSyncMode.On;
        }
        public BaseWindow((GameWindowSettings gws, NativeWindowSettings nws) settings) :base(settings.gws, settings.nws) { }

        public static (GameWindowSettings gws, NativeWindowSettings nws) DefaultSetupWindow()
        {
            GameWindowSettings gws = GameWindowSettings.Default;
            NativeWindowSettings nws = new NativeWindowSettings()
            {
                Size = new OpenTK.Mathematics.Vector2i(512, 512),

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
    public static class Program
    {
        public static void Main()
        {
            using(BaseWindow window = new BaseWindow(BaseWindow.DefaultSetupWindow()))
            {
                window.Run();
            }
        }

    }
}