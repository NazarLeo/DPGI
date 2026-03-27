using System;
using System.Windows;
using System.Windows.Input;

namespace lab2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Реєстрація команд та прив'язка обробників
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, Execute_Save, CanExecute_Save));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, Execute_Open, CanExecute_Always));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Delete, Execute_Clear, CanExecute_Always));
        }

        // Логіка для команди Save (кнопка OK)
        private void CanExecute_Save(object sender, CanExecuteRoutedEventArgs e)
        {
            // Команда доступна тільки якщо в полі є текст
            e.CanExecute = MainTextBox != null && MainTextBox.Text.Trim().Length > 0;
        }

        private void Execute_Save(object sender, ExecutedRoutedEventArgs e)
        {
            // Імітація збереження
            MessageBox.Show("Файл успішно збережено!", "Save Command", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Загальний дозвіл для команд, що доступні завжди
        private void CanExecute_Always(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Execute_Open(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Відкриття файлу...", "Open Command");
        }

        private void Execute_Clear(object sender, ExecutedRoutedEventArgs e)
        {
            MainTextBox.Clear();
        }
    }
}