using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Executar_Aplicativos
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cts;

        public Form1()
        {
            InitializeComponent();
        }


        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            lstResultados.Items.Clear();
            lblStatus.Text = "Iniciando busca...";
            cts = new CancellationTokenSource();


            string nome = txtNome.Text.Trim();
            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("a caixa de texto ta vazia burro coloca um nome la ");
                return;
            }

            // Pastas para procurar
            var roots = new List<string>
{
    // Programas comuns (todos usuários)
    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
    Environment.GetFolderPath(Environment.SpecialFolder.Windows),

    // Programas só para o usuário
    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Programs"),

    // Área de Trabalho (atalhos)
    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
    Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory),

    // Menu Iniciar (atalhos)
    Environment.GetFolderPath(Environment.SpecialFolder.StartMenu),
    Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu)

};


            var pathEnv = Environment.GetEnvironmentVariable("PATH") ?? "";
            var pathDirs = pathEnv.Split(';', StringSplitOptions.RemoveEmptyEntries)
                                  .Select(p => p.Trim()).Where(p => p.Length > 0);
            roots.AddRange(pathDirs);

            try
            {
                var encontrados = await Task.Run(() => BuscarExecutaveis(nome, roots, cts.Token));
                lblStatus.Text = "Busca finalizada.";

                if (encontrados.Count == 0)
                {
                    MessageBox.Show("Nenhum executável encontrado.");
                }
                else
                {
                    foreach (var item in encontrados)
                        lstResultados.Items.Add(item);
                }
            }
            catch (OperationCanceledException)
            {
                lblStatus.Text = "Busca cancelada.";
            }
        }
        private List<string> BuscarExecutaveis(string nome, List<string> roots, CancellationToken token)
        {
            var resultados = new List<string>();

            foreach (var root in roots.Distinct())
            {
                if (string.IsNullOrWhiteSpace(root) || !Directory.Exists(root)) continue;

                var queue = new Queue<string>();
                queue.Enqueue(root);

                while (queue.Count > 0)
                {
                    token.ThrowIfCancellationRequested();
                    var dir = queue.Dequeue();

                    Invoke(new Action(() =>
                    {
                        lblStatus.Text = "Procurando em: " + dir;
                    }));

                    try
                    {
                        // Busca arquivos .exe e .lnk
                        foreach (var ext in new[] { "*.exe", "*.lnk" })
                        {
                            foreach (var file in Directory.EnumerateFiles(dir, ext, SearchOption.TopDirectoryOnly))
                            {
                                var baseName = Path.GetFileNameWithoutExtension(file);
                                if (baseName.IndexOf(nome, StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    resultados.Add(file);
                                }
                            }
                        }
                    }
                    catch { }

                    try
                    {
                        foreach (var sub in Directory.EnumerateDirectories(dir))
                            queue.Enqueue(sub);
                    }
                    catch { }
                }
            }

            return resultados;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
        }
        private void btnExecutar_Click(object sender, EventArgs e)
        {
            if (lstResultados.SelectedItem != null)
            {
                string caminho = lstResultados.SelectedItem.ToString();
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = caminho,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao executar: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione um arquivo para executar.");
            }
        }

       
    }
}
