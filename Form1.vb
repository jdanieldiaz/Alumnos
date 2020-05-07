Imports MySql.Data.MySqlClient
Public Class Form1
    Dim conexion As MySqlConnection = New MySqlConnection
    Dim cmd As New MySqlCommand
    Sub ActualizarSelect()
        'variable de la clase 30-4
        Dim ds As DataSet = New DataSet
        Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter

        conexion.ConnectionString = "server=localhost; database=curso_visual;Uid=root;Pwd=;"

        Try
            conexion.Open()
            'MsgBox("nos conectamos")
            cmd.Connection = conexion

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
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click




        conexion.ConnectionString = "server=localhost; database=curso_visual;Uid=root;Pwd=;"

        Try
            conexion.Open()
            'MsgBox("nos conectamos")
            cmd.Connection = conexion

            cmd.CommandText = "INSERT INTO alumnos(nombre) VALUES(@nombre)"
            cmd.Prepare()

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text)
            cmd.ExecuteNonQuery()
            txtNombre.Clear()

            conexion.Close()

            ' MsgBox("Felcitaciones Usted fue ingresaro como alunno al curso de Daniel! ")
            ActualizarSelect()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarSelect()
    End Sub

    Private Sub grdAlumnos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdAlumnos.CellContentClick

    End Sub

    Private Sub grdAlumnos_SelectionChanged(sender As Object, e As EventArgs) Handles grdAlumnos.SelectionChanged
        If (grdAlumnos.SelectedRows.Count > 0) Then
            txtNombre.Text = grdAlumnos.Item("nombre", grdAlumnos.SelectedRows(0).Index).Value
            txtID.Text = grdAlumnos.Item("id", grdAlumnos.SelectedRows(0).Index).Value
        End If

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        conexion.ConnectionString = "server=localhost; database=curso_visual;Uid=root;Pwd=;"

        Try
            conexion.Open()
            'MsgBox("nos conectamos")
            cmd.Connection = conexion

            cmd.CommandText = "UPDATE alumnos SET nombre=@nombre WHERE id=@id"
            cmd.Prepare()

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text)
            cmd.Parameters.AddWithValue("@id", txtID.Text)
            cmd.ExecuteNonQuery()
            txtNombre.Clear()
            txtID.Clear()

            conexion.Close()

            ' MsgBox("Felcitaciones Usted fue ingresaro como alunno al curso de Daniel! ")
            ActualizarSelect()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
