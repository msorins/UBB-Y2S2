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
using System.Configuration;

namespace LAB1
{
    public partial class MainForm : Form
    {
        public SqlConnection connection = new SqlConnection(
            "Data Source=localhost;Initial Catalog=TvShows;Integrated Security=true"
            );
        public int selectedParentId;
        public int selectedChildrenId;

        public string parentName;
        public string[] parentColumnsName;

        public string childrenName;
        public string[] childrenColumnsName;
        

        public MainForm()
        {
            InitializeComponent();

            populateConfigs();
            populateParentDataGrid();
            populateEpisodesDataGrid();

            // Mark the selected child as the firstOne
            try
            {
                this.selectedChildrenId = (int)childrenDataGrid.Rows[0].Cells[0].Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            parentDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            childrenDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        public void populateConfigs()
        {
            this.parentName = ConfigurationManager.AppSettings["parent"];
            this.childrenName = ConfigurationManager.AppSettings["children"];

            this.parentColumnsName = getColumnsName(this.parentName);
            this.childrenColumnsName = getColumnsName(this.childrenName);

            this.labelParent.Text = this.parentName;
            this.labelChildren.Text = this.childrenName;
        }

        public string[] getColumnsName(String tableName)
        {
            List<string> listacolumnas = new List<string>();
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "select c.name from sys.columns c inner join sys.tables t on t.object_id = c.object_id and t.name = '"+ tableName +"' and t.type = 'U'";
                if (connection.State == ConnectionState.Closed)
                    this.connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listacolumnas.Add(reader.GetString(0));
                    }
                }
            }
            return listacolumnas.ToArray();
        }

        private void populateParentDataGrid()
        {
            /*
             * Populates the Shows Data Grid 
            */
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            // Make sure the connection is active
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            // Define the SQL command
            da.SelectCommand = new SqlCommand("SELECT * FROM " + this.parentName, connection);

            // Clear previous data set
            ds.Clear();

            // Fill the data set with query results
            da.Fill(ds);

            // Show the values in grid
            parentDataGrid.DataSource = ds.Tables[0];

            // Mark the selected show as the firstOne
            try
            {
                this.selectedParentId = (int)parentDataGrid.Rows[0].Cells[0].Value;
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
                this.selectedParentId = (int)parentDataGrid.Rows[parentDataGrid.CurrentRow.Index].Cells[0].Value;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                this.selectedParentId = -1;
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

            // Make sure the connection is active
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            // Define the SQL command
            da.SelectCommand = new SqlCommand("SELECT * FROM "+ this.childrenName +" WHERE "+ this.parentName +"Id = @id", connection);
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = selectedParentId;

            // Clear previous data set
            ds.Clear();

            // Fill the data set with query results
            da.Fill(ds);

            // Show the values in grid
            childrenDataGrid.DataSource = ds.Tables[0];
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void episodesDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Click event on the episodes Data Grid
            try
            {
                this.selectedChildrenId = (int)childrenDataGrid.Rows[childrenDataGrid.CurrentRow.Index].Cells[0].Value;
            }
            catch(Exception exception) {
                Console.WriteLine(exception.Message);
                this.selectedChildrenId = -1;
            }
    
        }

        private void deleteSelectedButton_Click(object sender, EventArgs e)
        {
            // Delete the selected Episode
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            // Make sure the connection is active
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            // Execute the SQL query
            da.DeleteCommand = new SqlCommand("DELETE FROM "+ this.childrenName +" WHERE "+ this.childrenName +"Id = @id", connection);
            da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int).Value = this.selectedChildrenId;
            da.DeleteCommand.ExecuteNonQuery();


            // Refresh the Episodes list
            this.populateEpisodesDataGrid();

            // Delete Selection from EpisodesGrid & reset selected episodes
            childrenDataGrid.ClearSelection();
            this.selectedChildrenId = -1;

            //this.episodesTableAdapter.Fill(
            //    this.episodesDataSet.Episodes,
            //    (int)showsDataGrid.Rows[showsDataGrid.CurrentRow.Index].Cells[0].Value
            //);
        }

        private void episodesDataGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            // Add row event (on episodes data grid)
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            // Make sure the connection is active
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            // Execute the SQL query
            string columnNames = "";
            string nulls = "";
            for (int i = 1; i < this.childrenColumnsName.Length; i++)
            {
                columnNames += this.childrenColumnsName[i];
                if (this.childrenColumnsName[i].Substring(0, this.childrenColumnsName[i].Length - 2).Equals(this.parentName))
                    nulls += this.selectedParentId.ToString();
                else
                    nulls += "NULL";
                if (i < this.childrenColumnsName.Length - 1)
                {
                    columnNames += ", ";
                    nulls += ", ";
                }
            }

            da.InsertCommand = new SqlCommand("INSERT INTO "+ this.childrenName +"("+ columnNames +") VALUES("+ nulls +") ", connection);
            da.InsertCommand.ExecuteNonQuery();


            // Refresh the Episodes list
            this.populateEpisodesDataGrid();

            // Delete Selection from EpisodesGrid & reset selected episodes
            childrenDataGrid.ClearSelection();
            this.selectedChildrenId = -1;

        }

        private void episodesDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Delete the selected Episode
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            // Make sure the connection is active
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            // Prepare the sql query
            string whatToSet = "";
            for(int i = 1; i < this.childrenColumnsName.Length; i++)
            {
                whatToSet += this.childrenColumnsName[i] + " = " + "@" + this.childrenColumnsName[i];

                if (i < this.childrenColumnsName.Length - 1)
                    whatToSet += ", ";
            }

            // Execute the SQL query
            da.UpdateCommand = new SqlCommand("UPDATE "+ this.childrenName +" SET "+ whatToSet +"  WHERE "+ this.childrenName + "."+ this.childrenName +"Id = @id", connection);

            for(int i = 1; i < this.childrenColumnsName.Length; i++)
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT " + this.childrenColumnsName[i] + " FROM " + this.childrenName;
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.KeyInfo);
                SqlDbType type = (SqlDbType)(int) reader.GetSchemaTable().Rows[0]["ProviderType"];
                reader.Close();

                da.UpdateCommand.Parameters.Add( "@" + this.childrenColumnsName[i], type).Value = childrenDataGrid.Rows[e.RowIndex].Cells[i].Value;
            }

            da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int).Value = this.selectedChildrenId;
            da.UpdateCommand.ExecuteNonQuery();
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
