using System.Collections.Generic;

namespace App {
    public enum TextureIdentifier {
        Purple,
        Golden,
        Silver
    }

    public enum LayerIdentifier {
        Top,
        Back,
        Left,
        Right,
        Front,
        Bottom
    }

    public enum LayerMovement {
        TopClockwise,
        BackClockwise,
        LeftClockwise,
        RightClockwise,
        FrontClockwise,
        BottomClockwise,
        TopAntiClockwise,
        BackAntiClockwise,
        LeftAntiClockwise,
        RightAntiClockwise,
        FrontAntiClockwise,
        BottomAntiClockwise
    }

    public enum Theme {
        DarkTheme,
        LightTheme
    }

    public class Messages {
        public static Dictionary<string, string> dictionary = new Dictionary<string, string> {
            { "LAYERLESS_MOVEMENT", "Esse movimento não está associado a uma camada." }
        };

        public static string getValue(string key) {
            return Messages.dictionary[key] ?? "";
        }
    }
}