using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Cekilis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            sonuc.Clear();
            if (string.IsNullOrWhiteSpace(cekilisList.Text) || string.IsNullOrWhiteSpace(secilecekSayi.Text))
            {
                MessageBox.Show("Çekiliş Listesi veya seçilecek kişi sayısını düzgün doldur!");
                return;
            }
            try
            {
                Random r = new Random();
                List<int> list = new List<int>();
                var text = cekilisList.Text.Split(",");
                if (text.Length < Convert.ToInt16(secilecekSayi.Text))
                {
                    MessageBox.Show("O Kadar Kişiyi nasıl seçiyim!");
                    return;
                }
                for (int i = 0; i < Convert.ToInt16(secilecekSayi.Text); i++)
                {
                    bool durum = true;
                    while (durum)
                    {
                        var sayi = r.Next(Convert.ToInt16(text.Length));
                        if (!list.Contains(sayi))
                        {
                            list.Add(sayi);
                            durum = false;
                        }

                    }
                }

                foreach (var item in list)
                {
                    sonuc.Text += text[item]+" , ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir Hata Oluştu!");
            }


        }
    }
}
