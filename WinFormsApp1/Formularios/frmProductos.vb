Imports BISoft.Ejercicios.Aplicacion.Fabricas
Imports Bisoft.Ejercicios.Dominio.Builders
Imports Bisoft.Ejercicios.Infraestructura.Contextos
Imports Bisoft.Ejercicios.Infraestructura.Entidades
Imports Bisoft.Ejercicios.Infraestructura.Repositorios
Imports BISoft.Ejercicios.Aplicacion.Servicios
Imports BISoft.Ejercicios.Aplicacion.Dtos.Parametros

Public Class frmProductos

    Private ReadOnly _productoService As ProductosService
    Private _page As Int32 = 1

    Public Sub New()
        InitializeComponent()

        Dim repositorio As ProductosRepository = ProductosRepositoryFactory.CrearProductosRepository("EF")
        _productoService = New ProductosService(repositorio)

    End Sub

    Private Sub frmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Async Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            Dim producto = ProductoBuilder.Empty _
                .WithId(txtId.Text) _
                .WithDescripcion(txtDescripcion.Text) _
                .WithPrecio(txtPrecio.Text) _
                .WithCosto(txtCosto.Text) _
                .WithStatus(chkEstatus.Checked) _
                .Build()

            Await _productoService.CrearProducto(producto)


            MessageBox.Show("Producto guardado correctamente")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Async Sub frmProductos_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Dim result = Await _productoService.ObtenerProductos()


    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        _page += 1
        CargarProductos(_page)
    End Sub

    Private Async Sub CargarProductos(page As Int32)

        Dim paginationParameters = New PaginationParameters() With {
            .PageNumber = page,
            .PageSize = 10
        }

        Dim result = Await _productoService.ObtenerProductoPaginados(
            paginationParameters
        )

        dgvProductos.DataSource = result
    End Sub


End Class