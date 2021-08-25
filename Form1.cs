using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Juego_2_grupo3_parejas
{
    public partial class Form1 : Form
    {
        // Use this Random object to choose random icons for the squares
        Random random = new Random();

        // Each of these letters is an interesting icon
        // in the Webdings font,
        // and each icon appears twice in this list
        List<string> icons = new List<string>()
    {
        "!", "!", "N", "N", ",", ",", "k", "k",
        "b", "b", "v", "v", "w", "w", "z", "z"
    };
        /// <summary>
        /// Asignar cada icono de la lista de iconos a un cuadrado aleatorio  
        /// </summary>
        private void AssignIconsToSquares()
        {
            // El TableLayoutPanel tiene 16 etiquetas,
            // y la lista de iconos tiene 16 iconos,
            // por lo que un icono se extrae al azar de la lista
            // y agregado a cada etiqueta
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <resumen>
        /// El evento Click de cada etiqueta es manejado por este controlador de eventos
        /// </summary>
        /// <param name = "sender"> La etiqueta en la que se hizo clic </param>
        /// <param name = "e"></param>
        private void label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // Si la etiqueta en la que se hizo clic es negra, el jugador hizo clic
                // un icono que ya ha sido revelado --
                // ignora el clic
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                clickedLabel.ForeColor = Color.Black;
            }
    
        
    }
}
/// <summary>
/// Every label's Click event is handled by this event handler
/// </summary>
/// <param name="sender">The label that was clicked</param>
/// <param name="e"></param>
private void label_Click(object sender, EventArgs e)
{
    Label clickedLabel = sender as Label;

    if (clickedLabel != null)
    {
        // If the clicked label is black, the player clicked
        // an icon that's already been revealed --
        // ignore the click
        if (clickedLabel.ForeColor == Color.Black)
            return;

        // If firstClicked is null, this is the first icon 
        // in the pair that the player clicked,
        // so set firstClicked to the label that the player 
        // clicked, change its color to black, and return
        if (firstClicked == null)
        {
            firstClicked = clickedLabel;
            firstClicked.ForeColor = Color.Black;

            return;
        }
    }
}
/// <summary>
/// This timer is started when the player clicks 
/// two icons that don't match,
/// so it counts three quarters of a second 
/// and then turns itself off and hides both icons
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
private void timer1_Tick(object sender, EventArgs e)
{
    object timer1 = null;
    // Stop the timer
    object p = timer1.Stop();

    object firstClicked = null;
    // Hide both icons
    firstClicked.Fore Color = firstClicked.BackColor;
    object secondClicked = null;
    secondClicked.ForeColor = secondClicked.BackColor;

    // Reset firstClicked and secondClicked 
    // so the next time a label is
    // clicked, the program knows it's the first click
    firstClicked = null;
    secondClicked = null;
}/// <summary>
/// Every label's Click event is handled by this event handler
/// </summary>
/// <param name="sender">The label that was clicked</param>
/// <param name="e"></param>
private void label_Click(object sender, EventArgs e)
{
    object timer1 = null;
    // The timer is only on after two non-matching 
    // icons have been shown to the player, 
    // so ignore any clicks if the timer is running
    if (timer1.Enabled == true)
    {
        return;
    }

    Label clickedLabel = sender as Label;

    if (clickedLabel != null)
    {
        // If the clicked label is black, the player clicked
        // an icon that's already been revealed --
        // ignore the click
        if (clickedLabel.ForeColor == Color.Black)
            return;

        object firstClicked = null;
        // If firstClicked is null, this is the first icon
        // in the pair that the player clicked, 
        // so set firstClicked to the label that the player 
        // clicked, change its color to black, and return
        if (firstClicked == null)
        {
            firstClicked = clickedLabel;
            return;
        }

        Label

                // If the player gets this far, the timer isn't
                // running and firstClicked isn't null,
                // so this must be the second icon the player clicked
                // Set its color to black
                secondClicked = clickedLabel;
        secondClicked.ForeColor = Color.Black;

        // If the player gets this far, the player 
        // clicked two different icons, so start the 
        // timer (which will wait three quarters of 
        // a second, and then hide the icons)
        object p = timer1.Start();
    }
}