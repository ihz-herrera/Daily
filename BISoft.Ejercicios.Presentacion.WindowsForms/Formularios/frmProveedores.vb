Imports BISoft.Ejercicios.Aplicacion.Fabricas
Imports BISoft.Ejercicios.Infraestructura.Contextos
Imports BISoft.Ejercicios.Infraestructura.Contratos
Imports BISoft.Ejercicios.Infraestructura.Entidades
Imports BISoft.Ejercicios.Infraestructura.Repositorios
Imports Microsoft.EntityFrameworkCore

Public Class frmProveedores
    Private Sub frmProveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnGuardas_Click(sender As Object, e As EventArgs) Handles btnGuardas.Click

        Dim contexto As New Context

        'Consultar cadena de conexion de variables de ambiente
        Dim cadenaConexion = Environment.GetEnvironmentVariable("CONEXION_BD")
        'Consulta typo repositorio de las variables de entorno
        Dim tipoRepositorio = Environment.GetEnvironmentVariable("TIPO_REPOSITORIO")



        Dim repo As IProveedoresRepository = ProveedoresRepositoryFactory _
        .GetProveedoresRepository(tipoRepositorio)

        'Consultar si el proveedor ya existe
        Dim proveedor = repo.ObtenerProveedorPorId(txtId.Text)

        If (proveedor IsNot Nothing) Then

            proveedor = New Proveedor
            proveedor.Id = txtId.Text
            proveedor.Nombre = txtNombre.Text
            proveedor.Direccion = txtDireccion.Text

            repo.ActualizarProveedor(proveedor)


        Else
            proveedor = New Proveedor
            proveedor.Id = txtId.Text
            proveedor.Nombre = txtNombre.Text
            proveedor.Direccion = txtDireccion.Text

            repo.CrearProveedor(proveedor)
        End If




        MsgBox("Proveedor guardado correctamente")

    End Sub
End Class