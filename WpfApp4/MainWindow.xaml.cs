using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Listar_Click(object sender, RoutedEventArgs e)
        {

            try {

                // Para trabajar con conexion a base de datos SQL, tenemos que tener instalalado
                // System.Data.SqlClient
                // Escribir SqlConnection -> Elegir instalar con admininstrador de paquetes


                // Creamos un objeto para la conexion a bd SQL

                string cadena = "Server=DEV\\SQLEXPRESS; Database=Lab03DB; Integrated Security=True";

                SqlConnection conection = new SqlConnection(cadena);

                // Abrimos nuestra coenxtion
                conection.Open();

                // Usamos nuestra consulta sql o conexion <. comnando
                SqlCommand command = new SqlCommand("Select * from Students", conection);

               // ListClient lisCli = new ListClient();
                

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // Para que funcione nuestra table necesitamos un adaptador
               DataTable dataTable = new DataTable();


                //adapter.Fill(dataTable);

                // cerramos la conexion
                conection.Close();


                // Usamos nuestro objeto de tabla o DataGrid para poder mostrarlo datos en este

                ListClient.ItemsSource = dataTable.DefaultView;

                //MessageBox.Show("Conextion establecidad");

            } catch (Exception)
            {
                MessageBox.Show("No se pudo conectar");

                throw;
            }
        }
    }
}