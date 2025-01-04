using System;
using System.Windows.Forms;
using AdminSERMAC.Forms;
using AdminSERMAC.Core.Interfaces;
using AdminSERMAC.Services;
using System.Drawing;
using AdminSERMAC.Core.Theme; // Asegurando la referencia correcta al ThemeManager

namespace AdminSERMAC
{
    public class MainForm : Form
    {
        private readonly IClienteService _clienteService;
        private readonly string connectionString;

        private Button mostrarClientesButton;
        private Button mostrarVentasButton;
        private Button mostrarInventarioButton;
        private Button visualizarProductoButton;
        private Button reiniciarBaseDatosButton;
        private Button importarProductosButton;
        private Button cambiarTemaButton;

        public MainForm(IClienteService clienteService, string connectionString)
        {
            _clienteService = clienteService;
            this.connectionString = connectionString;
            InitializeComponents();
            ThemeManager.ApplyTheme(this);
        }

        private void InitializeComponents()
        {
            // Configuración del formulario
            this.Text = "Menú Principal - SERMAC";
            this.Width = 800;
            this.Height = 600;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Panel principal
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };
            this.Controls.Add(mainPanel);

            // Título
            Label titleLabel = new Label
            {
                Text = "Sistema de Gestión SERMAC",
                Font = new Font("Arial", 20, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(50, 20)
            };
            mainPanel.Controls.Add(titleLabel);

            // Botones principales
            mostrarClientesButton = CreateMenuButton("Gestión de Clientes", 100);
            mostrarVentasButton = CreateMenuButton("Gestión de Ventas", 170);
            mostrarInventarioButton = CreateMenuButton("Gestión de Inventario", 240);
            visualizarProductoButton = CreateMenuButton("Visualizar Producto", 310);
            cambiarTemaButton = CreateMenuButton(ThemeManager.IsDarkMode ? "Tema Claro" : "Tema Oscuro", 380);
            importarProductosButton = CreateDangerButton("Importar Productos", 430);
            reiniciarBaseDatosButton = CreateDangerButton("Reiniciar Base de Datos", 500);

            cambiarTemaButton.Tag = "primary";

            // Agregar botones al panel
            mainPanel.Controls.Add(mostrarClientesButton);
            mainPanel.Controls.Add(mostrarVentasButton);
            mainPanel.Controls.Add(mostrarInventarioButton);
            mainPanel.Controls.Add(visualizarProductoButton);
            mainPanel.Controls.Add(reiniciarBaseDatosButton);
            mainPanel.Controls.Add(importarProductosButton);
            mainPanel.Controls.Add(cambiarTemaButton);

            // Eventos
            mostrarClientesButton.Click += MostrarClientesButton_Click;
            mostrarVentasButton.Click += MostrarVentasButton_Click;
            mostrarInventarioButton.Click += MostrarInventarioButton_Click;
            visualizarProductoButton.Click += VisualizarProductoButton_Click;
            reiniciarBaseDatosButton.Click += ReiniciarBaseDatosButton_Click;
            importarProductosButton.Click += ImportarProductosButton_Click;
            cambiarTemaButton.Click += CambiarTemaButton_Click;
        }

        private Button CreateMenuButton(string text, int top)
        {
            return new Button
            {
                Text = text,
                Top = top,
                Left = 50,
                Width = 200,
                Height = 40,
                Font = new Font("Arial", 10),
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
        }

        private Button CreateDangerButton(string text, int top)
        {
            return new Button
            {
                Text = text,
                Top = top,
                Left = 50,
                Width = 200,
                Height = 40,
                Font = new Font("Arial", 10),
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
        }

        private void CambiarTemaButton_Click(object sender, EventArgs e)
        {
            ThemeManager.IsDarkMode = !ThemeManager.IsDarkMode;
            ThemeManager.ApplyTheme(this);
            cambiarTemaButton.Text = ThemeManager.IsDarkMode ? "Tema Claro" : "Tema Oscuro";
        }

        private void MostrarClientesButton_Click(object sender, EventArgs e)
        {
            try
            {
                var clientesForm = new ClientesForm(_clienteService);
                clientesForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario de clientes: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarVentasButton_Click(object sender, EventArgs e)
        {
            try
            {
                var ventasForm = new VentasForm();
                ventasForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario de ventas: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarInventarioButton_Click(object sender, EventArgs e)
        {
            try
            {
                var inventarioForm = new InventarioForm();
                inventarioForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario de inventario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VisualizarProductoButton_Click(object sender, EventArgs e)
        {
            try
            {
                var visualizarProductoForm = new VisualizarProductoForm();
                visualizarProductoForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario de productos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportarProductosButton_Click(object sender, EventArgs e)
        {
            // (Mantén el código existente para importar productos)
        }

        private void ReiniciarBaseDatosButton_Click(object sender, EventArgs e)
        {
            // (Mantén el código existente para reiniciar la base de datos)
        }
    }
}
