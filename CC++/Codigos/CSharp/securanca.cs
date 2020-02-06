private void RellenaBases(){
    // usaremos una variable de tipo nodo y un
    // entero para mostrar las bds
    TreeNode Nodo;
    Int32 i;
            // construimos el adapatador para obtener los nobres de las bases de datos...
    SqlDataAdapter da= new SqlDataAdapter("Select name From master..sysdatabases",conexion);
            // creamos el dataset que contendrá nuestra información..
    DataSet dt= new DataSet("Bases De Datos");
            // Rellenamos el dataset..
    da.Fill(dt);
            // Rellenamos el treeview
    bds.Nodes.Clear();
    Nodo = bds.Nodes.Add("BD");
    bds.CheckBoxes=true;
            for (i=0;i<=dt.Tables[0].Rows.Count-1;i++)
        {
            Nodo.Nodes.Add(dt.Tables[0].Rows[i].ItemArray[0].ToString());
        }
}
