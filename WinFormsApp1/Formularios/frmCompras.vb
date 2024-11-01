Imports System.Net.Http
Imports BISoft.Ejercicios.Aplicacion.Builder
Imports BISoft.Ejercicios.Aplicacion.Dtos
Imports BISoft.Ejercicios.Aplicacion.Fabricas
Imports BISoft.Ejercicios.Aplicacion.Fachadas
Imports BISoft.Ejercicios.Aplicacion.Servicios
Imports BISoft.Ejercicios.Dominio.Entidades
Imports BISoft.Ejercicios.Dominio.Observador

Public Class frmCompras
    Implements ISubscriber(Of Producto), IObserver(Of CompraFacade)

    Private ReadOnly _productosService As ProductosService
    Private ReadOnly _sucursalesService As SucursalesService
    Private ReadOnly _proveedoresService As ProveedoresService
    Private ReadOnly _comprasService As ComprasService

    Private _compra As CompraFacade



    Public Sub New(productoService As ProductosService, comprasService As ComprasService)
        InitializeComponent()

        _comprasService = comprasService

        ''Crear repositorios
        Dim productosRepository = ProductosRepositoryFactory.CrearProductosRepository("EF")
        Dim sucursalesRepository = SucursalesRepositoryFactory.CrearSucursalesRepository()
        Dim proveedoresRepository = ProveedoresRepositoryFactory.CrearProveedoresRepository("EF")


        _productosService = productoService 'New ProductosService(productosRepository)
        _sucursalesService = New SucursalesService(sucursalesRepository)
        _proveedoresService = New ProveedoresService(proveedoresRepository)

    End Sub



    Private Sub frmCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Async Sub frmCompras_Shown(sender As Object, e As EventArgs) Handles Me.Shown



        Dim sucursales = _sucursalesService.ObtenerSucursales()
        Dim proveedores = _proveedoresService.ObtenerProveedores()


        Await Task.WhenAll(sucursales, proveedores)



        cmbSucursal.DataSource = Await sucursales
        cmbSucursal.DisplayMember = "Nombre"
        cmbSucursal.ValueMember = "Id"

        cmbProveedor.DataSource = Await proveedores
        cmbProveedor.DisplayMember = "Nombre"
        cmbProveedor.ValueMember = "Id"

        ''Se carga la lista de productos permitidos para la sucursal seleccionada
        ''despues de cargar las sucursales
        Dim sucursalId = cmbSucursal.SelectedValue

        Dim productos = Await _comprasService.ProductosPermitidos(sucursalId)

        cmbProducto.DataSource = productos
        cmbProducto.DisplayMember = "Descripcion"
        cmbProducto.ValueMember = "ProductoId"


        MsgBox("Datos cargados correctamente")

    End Sub

    Public Function Update(element As Producto) As Task Implements ISubscriber(Of Producto).Update
        ''Actualizar de lista de productos
        ''Mensaje de actualizacion
        Me.Text += "Producto actualizado"
        Return Task.CompletedTask
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click


        Dim compra = New Compra()

        'Dim detalle = New CompraDetalle With {
        '    .Cantidad = 10,
        '    .Precio = 10,
        '    .ProductoId = 4000
        '}

        Dim listaDetalles = New List(Of ProductoPermitidoDto)

        Dim productoPermitido = New ProductoPermitidoDtoBuilder().WithProductoId(1).WithDescripcion("Un producto").WithSucursalId(1).Build()
        '    1, 2, "Un producto", True)

        'listaDetalles.Add(productoPermitido)
        listaDetalles.Add(cmbProducto.SelectedValue)

        '' compra.CompraDetalles.Add(detalle)



        _comprasService.CrearCompra(compra, listaDetalles)

        MsgBox("Compra guardada correctamente")



    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        If (_compra Is Nothing) Then
            _compra = New CompraFacade()
            _compra.Subscribe(Me)
        End If

        Dim producto = CType(cmbProducto.SelectedItem, ProductoPermitidoDto)

        _compra.AgregarLinea(producto)


    End Sub

    Public Sub OnCompleted() Implements IObserver(Of CompraFacade).OnCompleted
        Limpiar()
    End Sub

    Private Sub Limpiar()
        ''Limpiar controles
        txtArtivulos.Text = ""
        txtSubTotal.Text = ""
        dgvCompras.DataSource = Nothing
    End Sub



    Public Sub OnError([error] As Exception) Implements IObserver(Of CompraFacade).OnError

        MessageBox.Show([error].Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub

    Public Sub OnNext(value As CompraFacade) Implements IObserver(Of CompraFacade).OnNext

        txtArtivulos.Text = value.Articulos.ToString()
        txtSubTotal.Text = value.SubTotal.ToString()

        dgvCompras.DataSource = Nothing
        dgvCompras.DataSource = value.Lineas
        dgvCompras.Update()
        dgvCompras.Refresh()

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If (_compra Is Nothing) Then
            Exit Sub
        End If

        Dim producto = CType(cmbProducto.SelectedItem, ProductoPermitidoDto)

        _compra.EliminarLinea(producto)
    End Sub
End Class