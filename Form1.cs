using System.IO.Ports;
using System.Net;
using System.Net.Sockets;

namespace GeniEthSerialServer
{
    public partial class Form1 : Form
    {
        // UDP
        private UdpClient? _udp1;
        private UdpClient? _udp2;
        private CancellationTokenSource? _udpCts1;
        private CancellationTokenSource? _udpCts2;
        private Task? _udpTask1;
        private Task? _udpTask2;

        // Serial
        private SerialPort? _sp1;
        private SerialPort? _sp2;
        private string? _sp1Name;
        private string? _sp2Name;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            // Initialize defaults
            RefreshSerialPortAssignments();
            UpdateUdpStatusLabels();
            AppendLog("Application started. Configure ports and enable servers.");
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // Ensure clean shutdown
            try
            {
                StopUdp1();
            }
            catch { }
            try
            {
                StopUdp2();
            }
            catch { }
            try
            {
                StopSerial1();
            }
            catch { }
            try
            {
                StopSerial2();
            }
            catch { }
        }

        #region Logging helpers
        private void AppendLog(string message)
        {
            if (txtLog.IsDisposed) return;
            var line = $"[{DateTime.Now:HH:mm:ss}] {message}";
            if (txtLog.InvokeRequired)
            {
                txtLog.BeginInvoke(new Action(() =>
                {
                    txtLog.AppendText(line + Environment.NewLine);
                }));
            }
            else
            {
                txtLog.AppendText(line + Environment.NewLine);
            }
        }
        #endregion

        #region UDP Echo Servers
        private void chkUdp1_CheckedChanged(object? sender, EventArgs e)
        {
            if (chkUdp1.Checked) StartUdp1(); else StopUdp1();
        }

        private void chkUdp2_CheckedChanged(object? sender, EventArgs e)
        {
            if (chkUdp2.Checked) StartUdp2(); else StopUdp2();
        }

        private void StartUdp1()
        {
            int port = (int)numUdpPort1.Value;
            try
            {
                _udpCts1 = new CancellationTokenSource();
                _udp1 = new UdpClient(new IPEndPoint(IPAddress.Any, port));
                _udpTask1 = Task.Run(() => UdpEchoLoop(_udp1, _udpCts1.Token, 1));
                numUdpPort1.Enabled = false;
                lblUdp1Status.Text = $"Listening : {port}";
                AppendLog($"UDP#1 listening on 0.0.0.0:{port}");
            }
            catch (Exception ex)
            {
                AppendLog($"UDP#1 start failed: {ex.Message}");
                chkUdp1.Checked = false;
            }
        }

        private void StopUdp1()
        {
            try { _udpCts1?.Cancel(); } catch { }
            try { _udp1?.Close(); } catch { }
            try { _udp1?.Dispose(); } catch { }
            _udp1 = null;
            _udpCts1 = null;
            _udpTask1 = null;
            numUdpPort1.Enabled = true;
            lblUdp1Status.Text = "Stopped";
            AppendLog("UDP#1 stopped.");
        }

        private void StartUdp2()
        {
            int port = (int)numUdpPort2.Value;
            try
            {
                _udpCts2 = new CancellationTokenSource();
                _udp2 = new UdpClient(new IPEndPoint(IPAddress.Any, port));
                _udpTask2 = Task.Run(() => UdpEchoLoop(_udp2, _udpCts2.Token, 2));
                numUdpPort2.Enabled = false;
                lblUdp2Status.Text = $"Listening : {port}";
                AppendLog($"UDP#2 listening on 0.0.0.0:{port}");
            }
            catch (Exception ex)
            {
                AppendLog($"UDP#2 start failed: {ex.Message}");
                chkUdp2.Checked = false;
            }
        }

        private void StopUdp2()
        {
            try { _udpCts2?.Cancel(); } catch { }
            try { _udp2?.Close(); } catch { }
            try { _udp2?.Dispose(); } catch { }
            _udp2 = null;
            _udpCts2 = null;
            _udpTask2 = null;
            numUdpPort2.Enabled = true;
            lblUdp2Status.Text = "Stopped";
            AppendLog("UDP#2 stopped.");
        }

        private async Task UdpEchoLoop(UdpClient client, CancellationToken ct, int id)
        {
            try
            {
                while (!ct.IsCancellationRequested)
                {
                    UdpReceiveResult res;
                    try
                    {
                        res = await client.ReceiveAsync(ct).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (ObjectDisposedException)
                    {
                        break;
                    }
                    catch (Exception ex)
                    {
                        AppendLog($"UDP#{id} receive error: {ex.Message}");
                        continue;
                    }

                    // Echo back
                    try
                    {
                        await client.SendAsync(res.Buffer, res.Buffer.Length, res.RemoteEndPoint).ConfigureAwait(false);
                        AppendLog($"UDP#{id} {res.RemoteEndPoint} {res.Buffer.Length} bytes echoed.");
                    }
                    catch (Exception ex)
                    {
                        AppendLog($"UDP#{id} send error: {ex.Message}");
                    }
                }
            }
            finally
            {
                try { client.Close(); } catch { }
            }
        }

        private void UpdateUdpStatusLabels()
        {
            lblUdp1Status.Text = chkUdp1.Checked ? $"Listening : {(int)numUdpPort1.Value}" : "Stopped";
            lblUdp2Status.Text = chkUdp2.Checked ? $"Listening : {(int)numUdpPort2.Value}" : "Stopped";
        }
        #endregion

        #region Serial Echo Servers
        private void btnRefreshSerial_Click(object? sender, EventArgs e)
        {
            RefreshSerialPortAssignments();
        }

        private void chkSer1_CheckedChanged(object? sender, EventArgs e)
        {
            if (chkSer1.Checked) StartSerial1(); else StopSerial1();
        }

        private void chkSer2_CheckedChanged(object? sender, EventArgs e)
        {
            if (chkSer2.Checked) StartSerial2(); else StopSerial2();
        }

        private void RefreshSerialPortAssignments()
        {
            var ports = SerialPort.GetPortNames()
                .OrderBy(p =>
                {
                    // Natural sort by number inside COMx
                    if (p.StartsWith("COM", StringComparison.OrdinalIgnoreCase) && int.TryParse(p[3..], out int n))
                        return n;
                    return int.MaxValue;
                })
                .ThenBy(p => p)
                .ToArray();

            _sp1Name = ports.ElementAtOrDefault(0);
            _sp2Name = ports.ElementAtOrDefault(1);

            lblSer1Port.Text = $"Port: {(_sp1Name ?? "(none)")}";
            lblSer2Port.Text = $"Port: {(_sp2Name ?? "(none)")}";

            // Prevent enabling when no port available
            chkSer1.Enabled = _sp1Name != null || (_sp1?.IsOpen ?? false);
            chkSer2.Enabled = _sp2Name != null || (_sp2?.IsOpen ?? false);
        }

        private void StartSerial1()
        {
            if (_sp1?.IsOpen == true) return;
            if (string.IsNullOrWhiteSpace(_sp1Name))
            {
                AppendLog("Serial#1 not available.");
                chkSer1.Checked = false;
                return;
            }

            try
            {
                _sp1 = CreateAndOpenSerial(_sp1Name);
                _sp1.DataReceived += Sp1_DataReceived;
                AppendLog($"Serial#1 opened {_sp1Name} @115200");
            }
            catch (Exception ex)
            {
                AppendLog($"Serial#1 open failed: {ex.Message}");
                chkSer1.Checked = false;
            }
        }

        private void StopSerial1()
        {
            if (_sp1 != null)
            {
                try { _sp1.DataReceived -= Sp1_DataReceived; } catch { }
                try { _sp1.Close(); } catch { }
                try { _sp1.Dispose(); } catch { }
                _sp1 = null;
                AppendLog("Serial#1 closed.");
            }
        }

        private void StartSerial2()
        {
            if (_sp2?.IsOpen == true) return;
            if (string.IsNullOrWhiteSpace(_sp2Name))
            {
                AppendLog("Serial#2 not available.");
                chkSer2.Checked = false;
                return;
            }

            try
            {
                _sp2 = CreateAndOpenSerial(_sp2Name);
                _sp2.DataReceived += Sp2_DataReceived;
                AppendLog($"Serial#2 opened {_sp2Name} @115200");
            }
            catch (Exception ex)
            {
                AppendLog($"Serial#2 open failed: {ex.Message}");
                chkSer2.Checked = false;
            }
        }

        private void StopSerial2()
        {
            if (_sp2 != null)
            {
                try { _sp2.DataReceived -= Sp2_DataReceived; } catch { }
                try { _sp2.Close(); } catch { }
                try { _sp2.Dispose(); } catch { }
                _sp2 = null;
                AppendLog("Serial#2 closed.");
            }
        }

        private static SerialPort CreateAndOpenSerial(string portName)
        {
            var sp = new SerialPort(portName)
            {
                BaudRate = 115200,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One,
                Handshake = Handshake.None,
                ReadTimeout = 500,
                WriteTimeout = 500,
                DtrEnable = false,
                RtsEnable = false,
                ReceivedBytesThreshold = 1
            };
            sp.Open();
            return sp;
        }

        private void Sp1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            HandleSerialEcho(_sp1, 1);
        }

        private void Sp2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            HandleSerialEcho(_sp2, 2);
        }

        private void HandleSerialEcho(SerialPort? sp, int id)
        {
            if (sp == null) return;
            try
            {
                int toRead = sp.BytesToRead;
                if (toRead <= 0) return;
                byte[] buffer = new byte[toRead];
                int read = sp.Read(buffer, 0, buffer.Length);
                if (read > 0)
                {
                    sp.Write(buffer, 0, read);
                    AppendLog($"SER#{id} {_GetPortName(sp)} {read} bytes echoed.");
                }
            }
            catch (Exception ex)
            {
                AppendLog($"SER#{id} error: {ex.Message}");
            }
        }

        private static string _GetPortName(SerialPort sp) => sp.PortName;
        #endregion
    }
}
