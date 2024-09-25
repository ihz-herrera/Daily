Imports BISoft.Ejercicios.Aplicacion.Dtos.Parametros
Imports BISoft.Ejercicios.Aplicacion.Fabricas
Imports BISoft.Ejercicios.Aplicacion.Helpers
Imports BISoft.Ejercicios.Aplicacion.Servicios
Imports BISoft.Ejercicios.Dominio.Builders
Imports BISoft.Ejercicios.Dominio.Entidades
Imports BISoft.Ejercicios.Dominio.Observador
Imports BISoft.Ejercicios.Infraestructura.Repositorios


''Todo: Bloquear tareas asincronas en los eventos

Public Class frmProductos
    'Implements IPublisher(Of Producto)

    'Private ListaObservadores As List(Of ISubscriber(Of Producto)) = New List(Of ISubscriber(Of Producto))

    Private ReadOnly _productoService As ProductosService
    Private _pagerProductList As PagerList(Of Producto)
    Private _notificationHandler As IPublisher(Of Producto)

    Public Sub New(productoService As ProductosService, notificationHandler As IPublisher(Of Producto))
        InitializeComponent()

        Dim repositorio As ProductosRepository = ProductosRepositoryFactory.CrearProductosRepository("EF")
        _productoService = productoService ' New ProductosService(repositorio)
        _notificationHandler = notificationHandler

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

            Await _notificationHandler.Notify(producto, "Compras:Cancelar", "MuchosMas")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Async Sub frmProductos_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Await CargarProductos(1)
        ActualizarPaginaGrid()


    End Sub

    Private Async Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try

            Await _pagerProductList.Next()

            ActualizarPaginaGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ActualizarPaginaGrid()
        dgvProductos.DataSource = _pagerProductList
        dgvProductos.Refresh()
        lblPagination.Text = String.Format("Pagina {0} de {1}", _pagerProductList.PageIndex, _pagerProductList.TotalPages)

        If (_pagerProductList.PageIndex = 1) Then
            btnPrevius.Enabled = False
        Else
            btnPrevius.Enabled = True
        End If

        If (_pagerProductList.PageIndex = _pagerProductList.TotalPages) Then
            btnNext.Enabled = False
        Else
            btnNext.Enabled = True
        End If


    End Sub

    Private Async Sub btnPrevius_Click(sender As Object, e As EventArgs) Handles btnPrevius.Click
        Try
            Await _pagerProductList.Previus()

            ActualizarPaginaGrid()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Async Function CargarProductos(page As Integer) As Task

        Dim paginationParameters = New PaginationParameters() With {
    .PageNumber = page,
    .PageSize = 1000
    }

        _pagerProductList = Await _productoService.ObtenerProductoPaginados(
        paginationParameters
        )


    End Function

    Private Sub btnLoadMore_Click(sender As Object, e As EventArgs) Handles btnLoadMore.Click

        Try

            _pagerProductList.LoadMore()

            Dim rowNumber = dgvProductos.Rows.Count
            dgvProductos.DataSource = Nothing

            ActualizarPaginaGrid()

            dgvProductos.FirstDisplayedScrollingRowIndex = rowNumber

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'Public Sub AddSubscriber(subscriber As ISubscriber(Of Producto)) Implements IPublisher(Of Producto).AddSubscriber
    '    ListaObservadores.Add(subscriber)
    'End Sub

    'Public Sub RemoveSubscriber(subscriber As ISubscriber(Of Producto)) Implements IPublisher(Of Producto).RemoveSubscriber
    '    ListaObservadores.Remove(subscriber)
    'End Sub

    'Public Function Notify(element As Producto) As Task Implements IPublisher(Of Producto).Notify
    '    For Each observador In ListaObservadores
    '        observador.Update(element)
    '    Next

    '    Return Task.CompletedTask
    'End Function


End Class