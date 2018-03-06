using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Packets for SQL
using System.Data.SqlClient;

namespace LAB1
{
    public partial class MainForm : Form
    {
        public SqlConnection connection = new SqlConnection(
            "Data Source=localhost;Initial Catalog=TvShows;Integrated Security=true"
            );
        public int selectedShowId;
        public int selectedEpisodeId;
        

        public MainForm()
        {
            InitializeComponent();
            populateShowsDataGrid();
            populateEpisodesDataGrid();
            showsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            episodesDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void populateShowsDataGrid()
        {
            /*
             * Populates the Shows Data Grid 
            */
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            // Define the SQL command
            da.SelectCommand = new SqlCommand("SELECT * FROM Shows", connection);

            // Clear previous data set
            ds.Clear();

            // Fill the data set with query results
            da.Fill(ds);

            // Show the values in grid
            showsDataGrid.DataSource = ds.Tables[0];

            // Mark the selected show as the firstOne
            try
            {
                this.selectedShowId = (int)showsDataGrid.Rows[0].Cells[0].Value;
            } 
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        }

        private void showsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
             * Callback for showsDataGrid
             */

            // Fill Episodes from clicked show
            //this.episodesTableAdapter.Fill(
            //    this.episodesDataSet.Episodes, 
            //    (int)showsDataGrid.Rows[showsDataGrid.CurrentRow.Index].Cells[0].Value
            //    );

            try
            {
                this.selectedShowId = (int)showsDataGrid.Rows[showsDataGrid.CurrentRow.Index].Cells[0].Value;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                this.selectedShowId = -1;
            }

          
            populateEpisodesDataGrid( );
        }


        private void populateEpisodesDataGrid()
        {
            /*
             * Populates the Episodes Data Grid given a ShowsId
            */

            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            // Define the SQL command
            da.SelectCommand = new SqlCommand("SELECT * FROM EPISODES WHERE EPISODES.ShowsId = @id", connection);
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = selectedShowId;

            // Clear previous data set
            ds.Clear();

            // Fill the data set with query results
            da.Fill(ds);

            // Show the values in grid
            episodesDataGrid.DataSource = ds.Tables[0];

            // Mark the selected episodes as the firstOne
            try
            {
                this.selectedEpisodeId = (int)episodesDataGrid.Rows[0].Cells[0].Value;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void episodesDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Click event on the episodes Data Grid
            try
            {
                this.selectedEpisodeId = (int)episodesDataGrid.Rows[episodesDataGrid.CurrentRow.Index].Cells[0].Value;
            }
            catch(Exception exception) {
                Console.WriteLine(exception.Message);
                this.selectedEpisodeId = -1;
            }
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Delete the selected Episode
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            // Make sure the connection is active
            if(connection.State == ConnectionState.Closed)
                connection.Open();

            // Execute the SQL query
            da.DeleteCommand = new SqlCommand("DELETE FROM EPISODES WHERE EPISODES.EpisodesId = @id", connection);
            da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int).Value = this.selectedEpisodeId;
            da.DeleteCommand.ExecuteNonQuery();


            // Refresh the Episodes list
            this.populateEpisodesDataGrid(  );

            // Delete Selection from EpisodesGrid & reset selected episodes
            episodesDataGrid.ClearSelection();
            this.selectedEpisodeId = -1;
            
            //this.episodesTableAdapter.Fill(
            //    this.episodesDataSet.Episodes,
            //    (int)showsDataGrid.Rows[showsDataGrid.CurrentRow.Index].Cells[0].Value
            //);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //SqlDataAdapter da = new SqlDataAdapter();
            //DataSet ds = new DataSet();

            //try
            //{
            //da.InsertCommand = new SqlCommand("INSERT INTO Table(C1, C2)" +
            //                                              "VALUES (@a, @b)", connection );

            //da.InsertCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = textBox1.Text;
            //da.InsertCommand.Parameters.Add("@b", SqlDbType.VarChar).Value = textBox1.Text;

            //connection.Open();
            //da.InsertCommand.ExecuteNonQuery();
            //connection.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    connection.Close();
            //}
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

 

        private void showsDataGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void episodesDataGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            Console.WriteLine("mergeeee");
        }

        private void episodesDataGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            Console.WriteLine("added");
        }

        private void episodesDataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Console.WriteLine("rows added");
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'episodesDataSet.Episodes' table. You can move, or remove it, as needed.
           // this.episodesTableAdapter.Fill(this.episodesDataSet.Episodes, 1);
            // TODO: This line of code loads data into the 'tvShowsDataSet.Shows' table. You can move, or remove it, as needed.
            //this.showsTableAdapter.Fill(this.tvShowsDataSet.Shows);

        }

        private void episodesDataGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

        }

      
    }
}
