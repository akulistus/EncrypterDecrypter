using EncrypterDecrypter.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EncrypterDecrypter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileIOService fileIOService = new FileIOService();
        private EncrypterDecrypterService encrypterDecrypterService = new EncrypterDecrypterService();
        private Regex regex = new Regex(@"[A-Za-z^0-9\s\p{P}]");
        OpenFileDialog ofd = new OpenFileDialog()
        {
            Filter = "Text files(*.txt) | *.txt|Docx files(*.docx) | *.docx"
        };

        SaveFileDialog sfd = new SaveFileDialog()
        {
            FileName = "Document",
            DefaultExt = ".txt",
            Filter = "Text files(*.txt) | *.txt|Docx files(*.docx) | *.docx"
        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Encrypt(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxKey.Text) || regex.IsMatch(TextBoxKey.Text))
            {
                MessageBox.Show("Ключ может содержать ТОЛЬКО кириллицу!");
                return;
            }
            else
            {
                TextBoxOutput.Text = encrypterDecrypterService.EncryptData(TextBoxInput.Text, TextBoxKey.Text);
            }
        }

        private void Button_Decrypt(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxKey.Text) || regex.IsMatch(TextBoxKey.Text))
            {
                MessageBox.Show("Ключ может содержать ТОЛЬКО кириллицу!");
                return;
            }
            else
            {
                TextBoxOutput.Text = encrypterDecrypterService.DecryptData(TextBoxInput.Text, TextBoxKey.Text);
            }

        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            TextBoxInput.Text = "Input";
            TextBoxOutput.Text = "Output";
            TextBoxKey.Clear();
        }

        private void Button_Load(object sender, RoutedEventArgs e)
        {
            bool? result = ofd.ShowDialog();
            if (result != true)
            {
                return;
            }
            else
            {
                TextBoxInput.Text = fileIOService.LoadData(ofd.FileName);
            }
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            bool? result = sfd.ShowDialog();

            if (result != true)
            {
                return;
            }
            else
            {
                fileIOService.SaveData(TextBoxOutput.Text, sfd.FileName);
            }
        }
    }
}
