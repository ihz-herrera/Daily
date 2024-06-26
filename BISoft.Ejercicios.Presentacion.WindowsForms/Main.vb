Public Class Form1

    Public Sub New()
        InitializeComponent()
        ' Establecer cadena de conexion en variable de ambiente
        Environment.SetEnvironmentVariable("CONEXION_BD", "Server=.;Database=Prueba;Trusted_Connection=True;")

    End Sub

    Private Sub btnProveedores_Click(sender As Object, e As EventArgs) Handles btnProveedores.Click
        MostrarFormularioProveedores()
    End Sub

    Private Sub MostrarFormularioProveedores()
        Dim frmProveedores As New frmProveedores
        frmProveedores.Show()
    End Sub
End Class
