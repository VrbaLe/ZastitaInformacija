using System.Data;
using System.Security.Cryptography;
using ZastitaInformacija.Algoritmi;

namespace ZastitaInformacija
{
    public partial class Form1 : Form
    {
        private string generatedKey;
        private string generatedKey2;
        private FoursquareCipher foursquareCipher;
        private LEACipher leaCipher;
        private FileSystemWatcher fsw;
        private bool isWatching = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key1 = GenerateRandomKey();
            string key2 = GenerateRandomKey();
            txtKey1.Text = key1;
            txtKey2.Text = key2;

            // Možeš koristiti te klju?eve u FoursquareCipher
            foursquareCipher = new FoursquareCipher(key1, key2);
        }

        private string GenerateRandomKey()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIKLMNOPQRSTUVWXYZ";

            return new string(chars.OrderBy(c => random.Next()).ToArray());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = textBox3.Text;
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Molimo odaberite fajl!");
                return;
            }

            byte[] fileBytes = File.ReadAllBytes(filePath);
            //uint[] fileUint= Binary.ByteArrayToUintArray(fileBytes);
            //string filestring = Binary.UintArrayToString(fileUint);
            //string filestring2= null;
            byte[] processedBytes = null;
            string tekst = File.ReadAllText(filePath);
            if (checkBox1.Checked)
            {
                if (radioButton1.Checked)
                {
                    // Šifrovanje fajla
                    processedBytes = foursquareCipher.EncryptBytes(fileBytes);
                }
                else if (radioButton2.Checked)
                {
                    // Dešifrovanje fajla
                    processedBytes = foursquareCipher.DecryptBytes(fileBytes);
                }
                else
                {
                    MessageBox.Show("Molimo izaberite opciju za kodiranje ili dekodiranje.");
                    return;
                }
            }
            else if (checkBox2.Checked)
            {
                // LEA algoritam
                /* if (string.IsNullOrEmpty(txtLea.Text))
                 {
                     MessageBox.Show("Molimo unesite klju? za LEA algoritam!");
                     return;
                 }*/
                leaCipher = new LEACipher("0f1e2d3c4b5a69788796a5b4c3d2e1f0");

                if (radioButton1.Checked)
                {
                    processedBytes = leaCipher.EncryptBytes(fileBytes);
                }
                else if (radioButton2.Checked)
                {
                    processedBytes = leaCipher.DecryptBytes(fileBytes);
                }
                else
                {
                    MessageBox.Show("Molimo izaberite opciju za kodiranje ili dekodiranje.");
                    return;
                }
                //processedBytes = Binary.StringToByteArray(filestring2);
            }

            // Spasi obra?eni fajl
            string processedFilePath = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + "_processed" + Path.GetExtension(filePath));
            File.WriteAllBytes(processedFilePath, processedBytes);

            MessageBox.Show("Fajl je obra?en i sa?uvan: " + processedFilePath);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = openFileDialog.FileName;
            }
        }
        private string GenerateRandomHexKey(int keySizeInBytes)
        {
            byte[] key = new byte[keySizeInBytes];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            // Konvertovanje u hex string
            return BitConverter.ToString(key).Replace("-", "");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string hexKey = GenerateRandomHexKey(16);
            txtLea.Text = hexKey;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtTargetDir.Text = fbd.SelectedPath;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtOutputDir.Text = fbd.SelectedPath;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTargetDir.Text) || string.IsNullOrEmpty(txtOutputDir.Text))
            {
                MessageBox.Show("Molimo izaberite direktorijume.");
                return;
            }

            fsw = new FileSystemWatcher(txtTargetDir.Text)
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
                Filter = "*.*",
                EnableRaisingEvents = true
            };

            fsw.Created += OnFileCreated;
            isWatching = true;
            btnStartWatching.Enabled = false;
            btnStopWatching.Enabled = true;
        }

        private void btnStopWatching_Click(object sender, EventArgs e)
        {
            if (fsw != null)
            {
                fsw.EnableRaisingEvents = false;
                fsw.Dispose();
            }
            isWatching = false;
            btnStartWatching.Enabled = true;
            btnStopWatching.Enabled = false;
        }

        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            try
            {
                byte[] fileBytes = File.ReadAllBytes(e.FullPath);
                byte[] processedBytes = null;

                if (checkBox1.Checked)
                {
                    if (radioButton3.Checked)
                        processedBytes = foursquareCipher.EncryptBytes(fileBytes);
                    else if (radioButton4.Checked)
                        processedBytes = foursquareCipher.DecryptBytes(fileBytes);
                }
                else if (checkBox2.Checked)
                {
                    if (radioButton3.Checked)
                        processedBytes = leaCipher.EncryptBytes(fileBytes);
                    else if (radioButton4.Checked)
                        processedBytes = leaCipher.DecryptBytes(fileBytes);
                }

                if (processedBytes != null)
                {
                    string outputFilePath = Path.Combine(txtOutputDir.Text, Path.GetFileName(e.FullPath));
                    File.WriteAllBytes(outputFilePath, processedBytes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom obrade fajla: {ex.Message}");
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Form2 novaForma = new Form2();
            novaForma.Show();
        }


    }
}
