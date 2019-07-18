using System;

namespace SBad.Visual.UI.Windows
{
    public static class WindowConstants
    {
        public static int ScreenWidth = 1920;
        public static int ScreenHeight = 1080;

        public static int Width75 { get { return ScreenWidth * 3 / 4; } } // 1440
        public static int Width70 { get { return (int)Math.Ceiling(ScreenWidth * .7); } } // 1344
        public static int Width50 { get { return (int)Math.Ceiling(ScreenWidth * .5); } } // 960
        public static int Width25 { get { return ScreenWidth / 4; } } // 480
        public static int Width20 { get { return (int)Math.Ceiling(ScreenWidth * .2); } } // 384
        public static int Width10 { get { return (int)Math.Ceiling(ScreenWidth * .1); } } // 162
        public static int Width05 { get { return ScreenWidth / 20; } } // 96
        public static int Width02 { get { return ScreenWidth / 50; } } // 38
        public static int Width01 { get { return ScreenWidth / 100; } } // 19

        public static int Height90 { get { return (int)Math.Ceiling(ScreenHeight * .9); } } // 972
        public static int Height75 { get { return ScreenHeight * 3 / 4; } } // 810
        public static int Height33 { get { return ScreenHeight / 3; } } // 360
        public static int Height25 { get { return ScreenHeight / 4; } } // 270
        public static int Height20 { get { return ScreenHeight / 5; } } // 216
        public static int Height10 { get { return ScreenHeight / 10; } } // 108
        public static int Height05 { get { return ScreenHeight / 20; } } // 54
        public static int Height02 { get { return ScreenHeight / 50; } } // 21
    }
}
