Imports BISoft.Ejercicios.Presentacion.Infraestructura.Builder
Imports BISoft.Ejercicios.Presentacion.Infraestructura.Contratos
Imports BISoft.Ejercicios.Presentacion.Infraestructura.Fachadas
Imports BISoft.Ejercicios.Presentacion.Infraestructura.Observador
Imports BISoft.Ejercicios.Shared.Dtos


Public Class frmCompras
    Implements ISubscriber(Of ProductoDto), IObserver(Of CompraFacade)

    Private ReadOnly _productosService As IProductosService
    Private ReadOnly _sucursalesService As ISucursalesService
    Private ReadOnly _proveedoresService As IProveedoresService
    Private ReadOnly _comprasService As IComprasService

    Private _compra As CompraFacade



    Public Sub New(productoService As IProductosService, comprasService As IComprasService,
                   sucuralesService As ISucursalesService, proveedoresService As IProveedoresService)
        InitializeComponent()

        _comprasService = comprasService

        '''Crear repositorios
        'Dim productosRepository = ProductosRepositoryFactory.CrearProductosRepository("EF")
        'Dim sucursalesRepository = SucursalesRepositoryFactory.CrearSucursalesRepository()
        'Dim proveedoresRepository = ProveedoresRepositoryFactory.CrearProveedoresRepository("EF")


        _productosService = productoService 'New ProductosService(productosRepository)
        _sucursalesService = sucuralesService
        _proveedoresService = proveedoresService

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

    Public Function Update(element As ProductoDto) As Task Implements ISubscriber(Of ProductoDto).Update
        ''Actualizar de lista de productos
        ''Mensaje de actualizacion
        Me.Text += "Producto actualizado"
        Return Task.CompletedTask
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click



        Dim sucursalId = cmbSucursal.SelectedValue

        Dim compra = New CompraDto(sucursalId)

        'Dim detalle = New CompraDetalle With {
        '    .Cantidad = 10,
        '    .Precio = 10,
        '    .ProductoId = 4000
        '}

        Dim listaDetalles = New List(Of ProductoPermitidoDto)


        Dim productoPermitidoNuevo = New _
            ProductoPermitidoDto(1, 1, "Suc1", 10)



        Dim productoPermitido = New ProductoPermitidoDtoBuilder() _
            .WithProductoId(1) _
            .WithDescripcion("Un producto") _
            .WithSucursalId(1) _
            .Build()
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