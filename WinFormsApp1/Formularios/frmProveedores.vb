Imports BISoft.Ejercicios.Presentacion.Infraestructura.Contratos

Public Class frmProveedores


    Private isBusy As Boolean = False
    Private ReadOnly _proveedoresService As IProveedoresService

    Public Property Tema As String

    ''Crear contructor  
    Public Sub New(service As IProveedoresService)
        InitializeComponent()
        _proveedoresService = service
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