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
        SpeechSynthesizer voz = new SpeechSynthesizer();

        bool arduinoConectado = false;

        public MonitorSerial()
        {
            InitializeComponent();
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
                    arduinoMega.Close();
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
        }

        private void MonitorSerial_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
        }
    }
}
