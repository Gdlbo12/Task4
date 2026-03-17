using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.IO;
using AvaloniaApp.Properties;

namespace AvaloniaApp;

public partial class Calculator : Window
{
    public Calculator()
    {
        InitializeComponent();
        
        try
        {
            TextBox1.Text = Settings.Default.SavedText;
        }
        catch
        {
        }
    }

    protected override void OnClosing(WindowClosingEventArgs e)
    {
        try
        {
            Settings.Default.SavedText = TextBox1.Text ?? "";
        }
        catch
        {
        }
        base.OnClosing(e);
    }

    private void Button1_OnClick(object? sender, RoutedEventArgs e)
    {
        ResultLabel.Text = Logic.GetMaxNum(TextBox1.Text);
    }
}