using Melanchall.DryWetMidi.Multimedia;
using System.Diagnostics;

namespace TestMidi;

public partial class MainPage : ContentPage
{


    public InputDevice inputDevice = InputDevice.GetByName("Keystation Mini 32");
    public OutputDevice outputDevice = OutputDevice.GetByName("Microsoft GS Wavetable Synth");
    public static DevicesConnector devicesConnector;

    public MainPage()
    {

        inputDevice.EventReceived += OnEventReceived;
        devicesConnector = new DevicesConnector(inputDevice, outputDevice);
        devicesConnector.Connect();
        inputDevice.StartEventsListening()

        InitializeComponent();

        if (inputDevice != null)
        {
            ConnectedInputDevices.Text = inputDevice.Name;
        }
        if (outputDevice != null)
        {
            ConnectedOutputDevices.Text = outputDevice.Name;
        }
    }

    private void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
    {
        var midiDevice = (MidiDevice)sender;
        Debug.WriteLine($"Event received from '{midiDevice.Name}' at {DateTime.Now}: {e.Event}");
    }
}

