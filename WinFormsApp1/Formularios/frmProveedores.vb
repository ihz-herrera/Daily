Imports BISoft.Ejercicios.Aplicacion.Fabricas
Imports BISoft.Ejercicios.Aplicacion.Servicios
Imports BISoft.Ejercicios.Infraestructura
Imports BISoft.Ejercicios.Infraestructura.Contextos
Imports BISoft.Ejercicios.Infraestructura.Contratos
Imports BISoft.Ejercicios.Infraestructura.Entidades
Imports BISoft.Ejercicios.Infraestructura.Repositorios
Imports Microsoft.EntityFrameworkCore

Public Class frmProveedores


    Private isBusy As Boolean = False
    Private ReadOnly _proveedoresService As ProveedoresService

    ''Crear contructor  
    Public Sub New()
        InitializeComponent()

        ' Consultar cadena de conexion de variables de ambiente
        Dim cadenaConexion As String = Environment.GetEnvironmentVariable("CONEXION_BD")
        ' Consulta typo repositorio de las variables de entorno
        Dim tipoRepositorio As String = Environment.GetEnvironmentVariable("TIPO_REPOSITORIO")

        Dim repo = ProveedoresRepositoryFactory _
            .CrearProveedoresRepository(tipoRepositorio)

        _proveedoresService = New ProveedoresService(repo)

    End Sub



    Private Async Sub btnGuardas_Click(sender As Object, e As EventArgs) Handles btnGuardas.Click

        Try
            If isBusy Then
                Return
            End If

            isBusy = True

            Await _proveedoresService _
                .GuardarProveedor(txtId.Text, txtNombre.Text, txtDireccion.Text)
            MsgBox("Proveedor guardado correctamente")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            isBusy = False
        End Try

    End Sub


End Class