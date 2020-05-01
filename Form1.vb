Imports MySql.Data.MySqlClient
Public Class Form1
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click

        Dim conexion As MySqlConnection
        conexion = New MySqlConnection

        Dim cmd As New MySqlCommand
        'variable de la clase 30-4
        Dim ds As DataSet = New DataSet
        Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter

        conexion.ConnectionString = "server=localhost; database=curso_visual;Uid=root;Pwd=;"

        Try
            conexion.Open()
            'MsgBox("nos conectamos")
            cmd.Connection = conexion

            cmd.CommandText = "INSERT INTO alumnos(nombre) VALUES(@nombre)"
            cmd.Prepare()

            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text)
            cmd.ExecuteNonQuery()
            txtNombre.Clear()

            cmd.CommandText = "SELECT * FROM alumnos ORDER BY nombre ASC"
            adaptador.SelectCommand = cmd
            adaptador.Fill(ds, "Tabla")
            grdAlumnos.DataSource = ds
            grdAlumnos.DataMember = "Tabla"

            conexion.Close()

            ' MsgBox("Felcitaciones Usted fue ingresaro como alunno al curso de Daniel! ")


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
