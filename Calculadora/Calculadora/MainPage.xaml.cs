using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        private string NumeroTexto1 = "";
        private string NumeroTexto2 = "";
        private double NumeroOperador1 = 0;
        private double NumeroOperador2 = 0;
        private string ResultadoFinal = "";
        private string Operador = "";

        public MainPage()
        {
            InitializeComponent();
        }


        private void BotonEliminar(object sender, EventArgs e)
        {
            NumeroTexto1 = "";
            NumeroTexto2 = "";
            NumeroOperador1 = 0;
            NumeroOperador2 = 0;
            ResultadoFinal = "";
            Operador = "";
            Pantalla.Text = "0";
    }

        private void BotonResultado(object sender, EventArgs e)
        {
            if(Operador != "")
            {
                switch (Operador)
                {
                    case "+":
                        ResultadoFinal = Convert.ToString(NumeroOperador1 + NumeroOperador2);
                        break;
                    case "-":
                        ResultadoFinal = Convert.ToString(NumeroOperador1 - NumeroOperador2);
                        break;
                    case "*":
                        ResultadoFinal = Convert.ToString(NumeroOperador1 * NumeroOperador2);
                        break;
                    case "/":
                        ResultadoFinal = Convert.ToString(NumeroOperador1 / NumeroOperador2);
                        break;
                }
            }
            NumeroTexto1 = ResultadoFinal;
            NumeroOperador1 = double.Parse(NumeroTexto1);
            
            NumeroTexto2 = "";
            NumeroOperador2 = 0;
            Operador = "";
            ResultadoFinal = "";

            ImprimirPantalla(NumeroTexto1, NumeroTexto2);
        }

        private void BotonOperadores(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(NumeroTexto2 == "" && Operador == "")
            {
                Operador = btn.Text;
                ImprimirPantalla(NumeroTexto1);
            }
        }

        private void BotonNumero(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (Operador == "" && NumeroTexto2 == "")
            {
                NumeroTexto1 = NumeroTexto1 + btn.Text;
                NumeroOperador1 = double.Parse(NumeroTexto1);
                ImprimirPantalla(NumeroTexto1);
            }
            else
            {
                NumeroTexto2 = NumeroTexto2 + btn.Text;
                NumeroOperador2 = double.Parse(NumeroTexto2);
                ImprimirPantalla(NumeroTexto1, NumeroTexto2);
            }
            
        }

        private void BotonDecimal(object sender, EventArgs e)
        {
            if (Operador == "" && NumeroTexto1 != "" && NumeroOperador1 % 1 == 0)
            {
                NumeroTexto1 = NumeroTexto1 + ".";
                ImprimirPantalla(NumeroTexto1);
            }
            if (Operador != "" && NumeroTexto2 != "" && NumeroOperador2 % 1 == 0)
            {
                NumeroTexto2 = NumeroTexto2 + ".";
                ImprimirPantalla(NumeroTexto1, NumeroTexto2);
            }
            
        }

        private void ImprimirPantalla(Object Numero, Object Numero2 = null)
        {
            if(ResultadoFinal != "")
            {
                Pantalla.Text = ResultadoFinal;
            }
            else
            {
                if(Operador == "")
                {
                    Pantalla.Text = Convert.ToString(Numero);
                }
                else
                {
                    Pantalla.Text = Convert.ToString(Numero) + Operador + Convert.ToString(Numero2);
                }
            }
        } 

    }
}
