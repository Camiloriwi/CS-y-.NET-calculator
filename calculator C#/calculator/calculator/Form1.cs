using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    /// <summary>
    /// Clase principal del formulario que representa la ventana de la calculadora.
    /// </summary>
    public partial class Form1 : Form
    {
        // Variables de clase
        private double resultado;
        private string operacion;

        /// <summary>
        /// Constructor de la clase Form1.
        /// Inicializa la calculadora y suscribe los botones a los eventos de click.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // Suscripción a eventos
            foreach (var control in Controls)
            {
                if (control is Button button)
                {
                    // Suscribe los botones a los eventos de click
                    button.Click += Button_Click;
                }
            }
        }

        // Manejador de evento para todos los botones
        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button boton)
            {
                switch (boton.Text)
                {
                    // Manejo de los botones de números
                    case string numero when int.TryParse(numero, out _):
                        textBox1.Text += numero;
                        break;

                    // Manejo de los botones de operaciones aritméticas
                    case "+":
                    case "-":
                    case "x":
                    case "/":
                        BotonOperacion_Click(sender, e);
                        break;

                    // Manejo del botón de igual
                    case "=":
                        BotonIgual_Click(sender, e);
                        break;

                    // Manejo del botón de limpiar
                    case "C":
                        BotonLimpiar_Click(sender, e);
                        break;
                }
            }
        }

        /// <summary>
        /// Maneja el evento de click para los botones de operaciones aritméticas.
        /// </summary>
        private void BotonOperacion_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            operacion = boton.Text;
            resultado = double.Parse(textBox1.Text);
            textBox1.Clear();
        }

        /// <summary>
        /// Maneja el evento de click para el botón "=".
        /// </summary>
        private void BotonIgual_Click(object sender, EventArgs e)
        {
            double numActual = double.Parse(textBox1.Text);
            switch (operacion)
            {
                case "+":
                    resultado += numActual;
                    break;
                case "-":
                    resultado -= numActual;
                    break;
                case "x":
                    resultado *= numActual;
                    break;
                case "/":
                    resultado /= numActual;
                    break;
            }
            textBox1.Text = resultado.ToString();
        }

        /// <summary>
        /// Maneja el evento de click para el botón "C".
        /// </summary>
        private void BotonLimpiar_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            resultado = 0;
            operacion = "";
        }

        // Documentación de botones adicionales

        /// <summary>
        /// Muestra información sobre clases en C#.
        /// </summary>
        private void button17_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clase: Una clase en C# es una plantilla que define un tipo de objeto. Proporciona la estructura para crear instancias de ese tipo, con sus propios datos y comportamiento. Una clase encapsula datos (atributos) y comportamiento (métodos) en una sola entidad y se utiliza para crear objetos.");
        }

        /// <summary>
        /// Muestra información sobre métodos en C#.
        /// </summary>
        private void button18_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Método: Un método es un bloque de código que contiene una serie de instrucciones diseñadas para realizar una operación. Cuando se llama a un método, se ejecutan estas instrucciones. Los métodos pueden devolver un valor y pueden tomar parámetros para realizar sus operaciones");
        }

        /// <summary>
        /// Muestra información sobre procedimientos en C#.
        /// </summary>
        private void button19_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Procedimiento: Un procedimiento es un bloque de código que realiza una tarea específica y no devuelve ningún valor (es decir, su tipo de retorno es void). En C#, los procedimientos son métodos que no devuelven un resultado");
        }

        /// <summary>
        /// Muestra información sobre eventos en C#.
        /// </summary>
        private void button20_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Evento: Un evento es un mecanismo que permite a una clase o un objeto notificar a otros objetos cuando ocurre algo de interés. La clase que emite el evento se llama publicador, y las clases que responden al evento se llaman suscriptores. Los eventos se utilizan comúnmente para responder a acciones del usuario, como clics de botones o entradas de teclado");
        }
    }
}
