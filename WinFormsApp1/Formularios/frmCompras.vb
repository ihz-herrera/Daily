Imports BISoft.Ejercicios.Aplicacion.Fabricas
Imports BISoft.Ejercicios.Aplicacion.Servicios

Public Class frmCompras


    Private ReadOnly _productosService As ProductosService
    Private ReadOnly _sucursalesService As SucursalesService
    Private ReadOnly _proveedoresService As ProveedoresService


    Public Sub New(productoService As ProductosService)
        InitializeComponent()


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

        Dim productos = _productosService.ObtenerProductos()
        Dim sucursales = _sucursalesService.ObtenerSucursales()
        Dim proveedores = _proveedoresService.ObtenerProveedores()


        Await Task.WhenAll(productos, sucursales, proveedores)

        cmbProducto.DataSource = Await productos
        cmbProducto.DisplayMember = "Descripcion"
        cmbProducto.ValueMember = "ProductoId"

        cmbSucursal.DataSource = Await sucursales
        cmbSucursal.DisplayMember = "Nombre"
        cmbSucursal.ValueMember = "Id"

        cmbProveedor.DataSource = Await proveedores
        cmbProveedor.DisplayMember = "Nombre"
        cmbProveedor.ValueMember = "Id"

        MsgBox("Datos cargados correctamente")

    End Sub
End Class