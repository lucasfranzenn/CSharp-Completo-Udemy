using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DecimoQuarto_Projeto;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        mediaVideo.LoadedBehavior = MediaState.Manual;
        sliderVolume.Value = 50;
        mediaVideo.Volume = (sliderVolume.Value / 100);
    }

    private void sliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        mediaVideo.Volume = (sliderVolume.Value/100);
    }

    private void btnPlay_Click(object sender, RoutedEventArgs e)
    {
        mediaVideo.Play();
    }

    private void btnPause_Click(object sender, RoutedEventArgs e)
    {
        mediaVideo.Pause();
    }

    private void btnStop_Click(object sender, RoutedEventArgs e)
    {
        mediaVideo.Stop();
    }

    private void btnOpen_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog ofdVideo = new();
        ofdVideo.InitialDirectory = @"c:\";
        ofdVideo.Filter = "Mp4 video | *.mp4";

        if(ofdVideo.ShowDialog() == true)
        {
            mediaVideo.Source = new Uri(ofdVideo.FileName);
            mediaVideo.Play();
        }
    }
}