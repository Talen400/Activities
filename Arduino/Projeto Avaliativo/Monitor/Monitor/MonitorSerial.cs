using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Speech.Synthesis; 

namespace Monitor
{
    public partial class MonitorSerial : Form
    {
        SerialPort arduinoMega = new SerialPort();
        string recebeBackGround;
        SpeechSynthesizer voz = new SpeechSynthesizer();

        public delegate void funcaoDelegate(string a);

        bool arduinoConectado = false;

        public MonitorSerial()
        {
            InitializeComponent();
            arduinoMega.DataReceived += new SerialDataReceivedEventHandler(funcaoBackGround);
        }
        void funcaoBackGround(object sender, SerialDataReceivedEventArgs e)
        {
            recebeBackGround = arduinoMega.ReadExisting();
            this.BeginInvoke(new funcaoDelegate(funcaoPrimeiroPlano), new object[] {recebeBackGround});
        }
        
        int b = 0;
        int c = 0;
        int d = 0;
        int e = 0;
        int f = 0;

        bool Ler = false;

        string Analog;
        string Analog2;
        string Analog3;
        string Analog4;

        void funcaoPrimeiroPlano(string a)
        {
            textBox2.Text += "Dado recebido: " + a ;
            textBox2.SelectionStart = textBox2.Text.Length;
            textBox2.ScrollToCaret();
            textBox2.Multiline = true;     
            textBox2.ScrollBars = ScrollBars.Vertical;     
            textBox2.AcceptsReturn = true;          
            textBox2.AcceptsTab = true;        
            textBox2.WordWrap = true;          

            if (Ler)
            {
                b = a.IndexOf("@");
                c = a.IndexOf("#");
                d = a.IndexOf("$");
                e = a.IndexOf("%");
                f = a.IndexOf("*");

                
                Analog = a.Substring(b + 1, (c - b) - 1);
                aquaGauge1.Value = int.Parse(Analog);
                label6.Text = "Poten " + Analog;
                Analog2 = a.Substring(c + 1, (d - c) - 1);
                aquaGauge2.Value = int.Parse(Analog2);
                label7.Text = Analog2 + "ºC";
                Analog3 = a.Substring(d + 1, (e - d) - 1);
                aquaGauge3.Value = int.Parse(Analog3);
                label8.Text = Analog3 + " cm";
                Analog4 = a.Substring(e + 1, (f - e) - 1);
                aquaGauge4.Value = int.Parse(Analog4); ;
                label10.Text = "Lum." + Analog4;
                
                /*
                 
                 Analog = pont;             aquaGauge1
                 Analog2 = Temp;           aquaGAuge2
                 Analog3 = Ultrassonic;    aquaGauge3
                 Analog4 = Lum.;           aquaGauge4
                 */
            }

            }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void arquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este aplicativo faz comunicação serial com o Arduino");
            
        }

        private void conectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "" && comboBox2.Text != "")
                {
                    arduinoMega.PortName = comboBox1.Text;
                    arduinoMega.BaudRate = Convert.ToInt32(comboBox2.Text);
                    arduinoMega.Open(); // try { arduinoMega.Open() }  catch { message }
                    arduinoConectado = true;
                }
                else
                {
                    MessageBox.Show("Favor, setar os valores da Configuração Inicial", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label1.Text = "Desconectado";
                }


                if (arduinoConectado)
                {
                    label1.Text = "Conectado";
                    label1.ForeColor = Color.Green;
                }
            }

            catch
            {
                MessageBox.Show("Porta e Baud Rate não compativeis", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (arduinoConectado == true)
            {
                arduinoMega.WriteLine(textBox1.Text);

                if (textBox1.Text == "1")
                {
                    voz.Speak("O Led foi Ligado");
                }
                else if(textBox1.Text == "0")
                {
                    voz.Speak("O led foi desligado");
                }
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Favor Abrir a Porta Serial", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void desconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            arduinoMega.Close();
            arduinoConectado = false;
            if (arduinoConectado == false) {
                label1.Text = "Desconectado";
                label1.ForeColor = Color.Black;
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
            timer1.Enabled = false;
        }

        private void MonitorSerial_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
            voz.SetOutputToDefaultAudioDevice();
            foreach (string lerPortasDisponiveis in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(lerPortasDisponiveis); 
            }
            
        }

        private void ferramentasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        
        private void button5_Click(object sender, EventArgs e)
        {

            if (arduinoConectado == true && timer1.Enabled == false)
            {
                timer1.Enabled = true;
               
                         
            }
        }

        private void aquaGauge1_Load(object sender, EventArgs e)
        {
          
        }
        String AquaGauge;
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label9.Text = trackBar3.Value.ToString();
            AquaGauge = (trackBar3.Value + 1000).ToString();
        }

        private void aquaGauge4_Load(object sender, EventArgs e)
        {

        }

        private void aquaGauge2_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (arduinoConectado == true)
            {
                arduinoMega.Write("d" + AquaGauge + ";");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void aquaGauge3_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (arduinoConectado == true)
            {
                arduinoMega.Write("");
                Ler = !Ler;
                if (Ler == true)
                {
                    label4.Text = "ler: sim";
                    label4.ForeColor = Color.Green;
                }
                else
                {
                    label4.Text = "ler: não";
                    label4.ForeColor = Color.Black;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (arduinoConectado == true)
            {
                timer1.Enabled = false;
                
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
