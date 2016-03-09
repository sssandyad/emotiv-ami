// Copyright © 2010 James Galasyn 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

using System.IO.Ports;

using Emotiv;
using EmoEngineClientLibrary;
using EmoEngineControlLibrary;
using System.Windows.Automation.Peers;
using System.Reflection;

namespace RawDataTestApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        EmoEngineClient _emoEngineClient;
        public AMLearning model;
        #region variables
        //Richtextbox
        FlowDocument mcFlowDoc = new FlowDocument();
        Paragraph para = new Paragraph();
        //Serial 
        //SerialPort serial = new SerialPort();
        //string recieved_data;
        #endregion

        public Window1()
        {
            InitializeComponent();

            this._emoEngineClient = this.FindResource( "emoEngineClient" ) as EmoEngineClient;
            this._emoEngineClient.ActivePort = EmoEngineClient.EmoComposerPort; // TBD: move to XAML
            //this._emoEngineClient.ActivePort = EmoEngineClient.ControlPanelPort;

            this._emoEngineClient.btnB = btnBackward;
            this._emoEngineClient.btnF = btnForward;
            this._emoEngineClient.btnN = btnNeutral;
            this._emoEngineClient.btnR = btnRight;
            this._emoEngineClient.btnL = btnLeft;
        }

        private void Connect_Comms(object sender, RoutedEventArgs e)
        {
            if (Connect_btn.Content == "Connect")
            {
                //Sets up serial port
                this._emoEngineClient.serial.PortName = Comm_Port_Names.Text;
                this._emoEngineClient.serial.BaudRate = Convert.ToInt32(Baud_Rates.Text);
                this._emoEngineClient.serial.Handshake = System.IO.Ports.Handshake.None;
                this._emoEngineClient.serial.Parity = Parity.None;
                this._emoEngineClient.serial.DataBits = 8;
                this._emoEngineClient.serial.StopBits = StopBits.One;
                this._emoEngineClient.serial.ReadTimeout = 200;
                this._emoEngineClient.serial.WriteTimeout = 50;
                this._emoEngineClient.serial.Open();

                //Sets button State and Creates function call on data recieved
                Connect_btn.Content = "Disconnect";
                //serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Recieve);

            }
            else
            {
                try // just in case serial port is not open could also be acheved using if(serial.IsOpen)
                {
                    this._emoEngineClient.serial.Close();
                    Connect_btn.Content = "Connect";
                }
                catch
                {
                }
            }
        }

        #region Sending

        //public void SerialCmdSend(string data)
        //{
        //    if (serial.IsOpen)
        //    {
        //        try
        //        {
        //            // Send the binary data out the port
        //            byte[] hexstring = Encoding.ASCII.GetBytes(data);
        //            //There is a intermitant problem that I came across
        //            //If I write more than one byte in succesion without a 
        //            //delay the PIC i'm communicating with will Crash
        //            //I expect this id due to PC timing issues ad they are
        //            //not directley connected to the COM port the solution
        //            //Is a ver small 1 millisecound delay between chracters
        //            foreach (byte hexval in hexstring)
        //            {
        //                byte[] _hexval = new byte[] { hexval }; // need to convert byte to byte[] to write
        //                serial.Write(_hexval, 0, 1);
        //                Thread.Sleep(1);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            para.Inlines.Add("Failed to SEND" + data + "\n" + ex + "\n");
        //            mcFlowDoc.Blocks.Add(para);
        //            //Commdata.Document = mcFlowDoc;
        //        }
        //    }
        //    else
        //    {
        //    }
        //}

        #endregion

        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
        }

        private void _startButton_Click( object sender, RoutedEventArgs e )
        {
            //MessageBox.Show("name: " + this._emoEngineClient.model.Name + " algo: " + this._emoEngineClient.model.Algo);
            this._emoEngineClient.StartDataPolling();

            //// TBD: declarative
            //ChannelList channelsToDisplay = new ChannelList();
            //channelsToDisplay.Add( EdkDll.EE_DataChannel_t.AF3 );
            ////channelsToDisplay.Add( EdkDll.EE_DataChannel_t.AF4 );
            ////channelsToDisplay.Add( EdkDll.EE_DataChannel_t.COUNTER );
            ////channelsToDisplay.Add( EdkDll.EE_DataChannel_t.F3 );
            ////channelsToDisplay.Add( EdkDll.EE_DataChannel_t.F4 );
            ////channelsToDisplay.Add( EdkDll.EE_DataChannel_t.F7 );
            ////channelsToDisplay.Add( EdkDll.EE_DataChannel_t.F8 );
            ////channelsToDisplay.Add( EdkDll.EE_DataChannel_t.FC5 );
            ////channelsToDisplay.Add( EdkDll.EE_DataChannel_t.FC6 );
            ////channelsToDisplay.Add( EdkDll.EE_DataChannel_t.O1 );
            ////channelsToDisplay.Add( EdkDll.EE_DataChannel_t.O2 );
            ////channelsToDisplay.Add( EdkDll.EE_DataChannel_t.P7 );
            ////channelsToDisplay.Add( EdkDll.EE_DataChannel_t.P8 );
            ////channelsToDisplay.Add( EdkDll.EE_DataChannel_t.T7 );
            ////channelsToDisplay.Add( EdkDll.EE_DataChannel_t.T8 );

            //this._neuroDataControl.ChannelsToDisplay = channelsToDisplay;

            this._neuroDataControl.Start();
        }

        private void _stopButton_Click( object sender, RoutedEventArgs e )
        {
            this._emoEngineClient.StopDataPolling();
        }

        private void _startEmoEngineButton_Click( object sender, RoutedEventArgs e )
        {
            var myRef = this.FindName("coba");
            //btnRight.Background = SolidColorBrush. myRef;

            this._emoEngineClient.model = this.model;
            this._emoEngineClient.StartEmoEngine();


            //int xx = this._emoEngineClient.xmax;
            //int yy = this._emoEngineClient.ymax;
            //Console.WriteLine("xmax : {0}, ymax : {1}", xx, yy);
        }

        //private FrameworkElement CreateNeuroDataControl()
        //{
        //    NeuroDataControl neuroDataControl = new NeuroDataControl();
        //    neuroDataControl.HorizontalAlignment = HorizontalAlignment.Stretch;
        //    neuroDataControl.VerticalAlignment = VerticalAlignment.Stretch;

        //    neuroDataControl.Width = Double.NaN;
        //    neuroDataControl.Height = 600;

        //    neuroDataControl.DataFrameSource = this._emoEngineClient;

        //    return neuroDataControl;
        //}

        private void Window_Closing( object sender, System.ComponentModel.CancelEventArgs e )
        {
            this._neuroDataControl.Shutdown();
        }

        private static AutoResetEvent s_event = new AutoResetEvent( false );

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            this._emoEngineClient.SerialCmdSend("W");
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            this._emoEngineClient.SerialCmdSend("D");
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            this._emoEngineClient.SerialCmdSend("A");
        }

        private void btnBackward_Click(object sender, RoutedEventArgs e)
        {
            //this._emoEngineClient.SerialCmdSend("X");
            MessageBox.Show("clicked");
        }

        private void btnNeutral_Click(object sender, RoutedEventArgs e)
        {
            this._emoEngineClient.SerialCmdSend("S");
        }

        private void _trainData_Click(object sender, RoutedEventArgs e)
        {
            //this._emoEngineClient.Coba();
            //MessageBox.Show(DbSettings.fullpath);

            ClassifyForm cf = new ClassifyForm(this);
            cf.Show();



            //TrainForm formTraining = new TrainForm();
            //formTraining.Show();
        }
    }
}
