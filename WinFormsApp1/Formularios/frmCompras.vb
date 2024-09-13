Imports BISoft.Ejercicios.Aplicacion.Builder
Imports BISoft.Ejercicios.Aplicacion.Dtos
Imports BISoft.Ejercicios.Aplicacion.Fabricas
Imports BISoft.Ejercicios.Aplicacion.Servicios
Imports BISoft.Ejercicios.Dominio.Entidades
Imports BISoft.Ejercicios.Dominio.Observador

Public Class frmCompras
    Implements ISubscriber(Of Producto)

    Private ReadOnly _productosService As ProductosService
    Private ReadOnly _sucursalesService As SucursalesService
    Private ReadOnly _proveedoresService As ProveedoresService
    Private ReadOnly _comprasService As ComprasService


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

        Dim productoPermitido = New ProductosPermitidosDtoBuilder().WithProductoId(1).WithDescripcion("Un producto").WithSucursalId(1).Build()
        '    1, 2, "Un producto", True)

        'listaDetalles.Add(productoPermitido)
        listaDetalles.Add(cmbProducto.SelectedValue)

        '' compra.CompraDetalles.Add(detalle)



        _comprasService.CrearCompra(compra, listaDetalles)

        MsgBox("Compra guardada correctamente")



    End Sub
End Class