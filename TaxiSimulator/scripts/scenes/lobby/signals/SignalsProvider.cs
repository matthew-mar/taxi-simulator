using TaxiSimulator.Scenes.Lobby.View;

namespace TaxiSimulator.Scenes.Lobby.Signals {
    public class SignalsProvider {
        private static DriveButtonPressedSignal driveButtonPressedSignal = null;

        private static QuitButtonPressedSignal quitButtonPressedSignal = null;

        private static MapButtonPressedSignal mapButtonPressedSignal = null;

        private static OrdersButtonPressedSignal ordersButtonPressedSignal = null;

        private static CompanyButtonPressedSignal companyButtonPressedSignal = null; 

        private static RealEstateButtonPressedSignal realEstateButtonPressedSignal = null;

        private static CarsButtonPressedSignal carsButtonPressedSignal = null;

        private static MailButtonPressedSignal mailButtonPressedSignal = null;

        private static SettingsButtonPressedSignal settingsButtonPressedSignal = null;

        public static DriveButtonPressedSignal DriveButtonPressedSignal {
            get {
                driveButtonPressedSignal ??= new();
                return driveButtonPressedSignal;
            }
        }

        public static QuitButtonPressedSignal QuitButtonPressedSignal {
            get {
                quitButtonPressedSignal ??= new();
                return quitButtonPressedSignal;
            }
        }

        public static MapButtonPressedSignal MapButtonPressedSignal {
            get {
                mapButtonPressedSignal ??= new();
                return mapButtonPressedSignal;
            }
        }

        public static OrdersButtonPressedSignal OrdersButtonPressedSignal {
            get {
                ordersButtonPressedSignal ??= new();
                return ordersButtonPressedSignal;
            }
        }

        public static CompanyButtonPressedSignal CompanyButtonPressedSignal {
            get {
                companyButtonPressedSignal ??= new();
                return companyButtonPressedSignal;
            }
        }

        public static RealEstateButtonPressedSignal RealEstateButtonPressedSignal {
            get {
                realEstateButtonPressedSignal ??= new();
                return realEstateButtonPressedSignal;
            }
        }

        public static CarsButtonPressedSignal CarsButtonPressedSignal {
            get {
                carsButtonPressedSignal ??= new();
                return carsButtonPressedSignal;
            }
        }

        public static MailButtonPressedSignal MailButtonPressedSignal {
            get {
                mailButtonPressedSignal ??= new();
                return mailButtonPressedSignal;
            }
        }

        public static SettingsButtonPressedSignal SettingsButtonPressedSignal {
            get {
                settingsButtonPressedSignal ??= new();
                return settingsButtonPressedSignal;
            }
        }

        public static void ClearSignals() {
            driveButtonPressedSignal = null;
            quitButtonPressedSignal = null;
            mapButtonPressedSignal = null;
            ordersButtonPressedSignal = null;
            companyButtonPressedSignal = null;
            realEstateButtonPressedSignal = null;
            carsButtonPressedSignal = null;
            mailButtonPressedSignal = null;
            settingsButtonPressedSignal = null;
        }
    }
}
