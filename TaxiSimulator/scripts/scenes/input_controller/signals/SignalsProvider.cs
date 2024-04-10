namespace TaxiSimulator.Scenes.InputController.Signlas {
    public class SignalsProvider {
        private static EscapePressedSignal escapePressedSignal = null;

        private static HorizontalPressedSignal horizontalPressedSignal = null;

        private static VerticalPressedSignal verticalPressedSignal = null;

        private static MouseScrolledUpSignal mouseScrolledUpSignal = null;

        private static MouseScrolledDownSignal mouseScrolledDownSignal = null;

        private static ActionMPressedSignal actionMPressedSignal = null;

        private static MouseLeftClickedSignal mouseLeftClickedSignal = null;

        private static ActionCPressedSignal actionCPressedSignal = null;

        public static EscapePressedSignal EscapePressedSignal {
            get {
                escapePressedSignal ??= new();
                return escapePressedSignal;
            }
        }

        public static HorizontalPressedSignal HorizontalPressedSignal {
            get {
                horizontalPressedSignal ??= new();
                return horizontalPressedSignal;
            }
        }

        public static VerticalPressedSignal VerticalPressedSignal {
            get {
                verticalPressedSignal ??= new();
                return verticalPressedSignal;
            }
        }

        public static MouseScrolledUpSignal MouseScrolledUpSignal {
            get {
                mouseScrolledUpSignal ??= new();
                return mouseScrolledUpSignal;
            }
        }

        public static MouseScrolledDownSignal MouseScrolledDownSignal {
            get {
                mouseScrolledDownSignal ??= new();
                return mouseScrolledDownSignal;
            }
        }

        public static ActionMPressedSignal ActionMPressedSignal {
            get {
                actionMPressedSignal ??= new();
                return actionMPressedSignal;
            }
        }

        public static MouseLeftClickedSignal MouseLeftClickedSignal {
            get {
                mouseLeftClickedSignal ??= new();
                return mouseLeftClickedSignal;
            }
        }

        public static ActionCPressedSignal ActionCPressedSignal {
            get {
                actionCPressedSignal ??= new();
                return actionCPressedSignal;
            }
        }

        public static void ClearSignals() {
            escapePressedSignal = null;
            horizontalPressedSignal = null;
            verticalPressedSignal = null;
            mouseScrolledUpSignal = null;
            mouseScrolledDownSignal = null;
            actionMPressedSignal = null;
            mouseLeftClickedSignal = null;
            actionCPressedSignal = null;
        }
    }
}
