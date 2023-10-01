using System.Collections.Generic;

namespace App {
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

    public class Messages {
        public static Dictionary<string, string> dictionary = new Dictionary<string, string> {
            { "LAYERLESS_MOVEMENT", "Esse movimento não está associado a uma camada." }
        };

        public static string getValue(string key) {
            return Messages.dictionary[key] ?? "";
        }
    }
}