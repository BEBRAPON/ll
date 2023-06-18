using static System.Net.Mime.MediaTypeNames;

namespace ThemLib
{
    public class Theme
    {
        public static void ApplyLightTheme()
        {
            var app = Application.Current;
            var resources = app.Resources;

            // Фоновый цвет
            resources["AppBackground"] = Brushes.White;

            // Цвет текста
            resources["AppText"] = Brushes.Black;

            // Цвет кнопок
            resources["ButtonBackground"] = Brushes.LightGray;
            resources["ButtonForeground"] = Brushes.Black;
        }

        public static void ApplyDarkTheme()
        {
            var app = Application.Current;
            var resources = app.Resources;

            // Фоновый цвет
            resources["AppBackground"] = Brushes.Black;

            // Цвет текста
            resources["AppText"] = Brushes.White;

            // Цвет кнопок
            resources["ButtonBackground"] = Brushes.DarkGray;
            resources["ButtonForeground"] = Brushes.White;
        }
    }
}