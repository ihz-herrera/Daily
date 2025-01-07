Imports BISoft.Ejercicios.Presentacion.Infraestructura.Contratos
Imports BISoft.Ejercicios.Presentacion.Infraestructura.Haddlers
Imports BISoft.Ejercicios.Shared.Dtos
Imports SimpleInjector

Public Class MEnu

    Private contenedor As Container
    Private notificationHandler As NotificationHandler(Of ProductoDto)
    Private notificationProveedorHandler As NotificationHandler(Of ProveedorDto)


    Dim frmProductos As frmProductos
    Dim frmCompras As frmCompras
    Public Sub New()
        InitializeComponent()
        contenedor = New Container()

        ConfigurarIoC()
        notificationHandler = New NotificationHandler(Of ProductoDto)
    End Sub

    Private Sub ConfigurarIoC()

        'contenedor.Register(Of ProductosService)()
        'contenedor.Register(Of ComprasService)()

        'contenedor.Register(Of IProductosRepository, ProductosRepository)()
        'contenedor.Register(Of ICategoriasRepository, CategoriasRepository)()
        'contenedor.Register(Of IFabricantesRepository, FabricantesRepository)()

        'contenedor.Register(Of IOutboxRepository, OutboxRepository)()
        'contenedor.Register(Of Context)(Lifestyle.Singleton)

        'contenedor.Register(Of IComprasRepository, ComprasRepository)()

        'Dim Registration = contenedor.GetRegistration(GetType(Context)).Registration

        'Registration.SuppressDiagnosticWarning(
        '        DiagnosticType.DisposableTransientComponent,
        '            "Reason of suppression")

        contenedor.Verify()


    End Sub

    Private Sub btnProveedores_Click(sender As Object, e As EventArgs) Handles btnProveedores.Click
        Dim frm As New frmProveedores(contenedor.GetInstance(Of IProveedoresService)())
        frm.Tema = "Tema"
        frm.Show()
    End Sub

    Private Sub btnProductos_Click(sender As Object, e As EventArgs) Handles btnProductos.Click
        Dim productosService = contenedor.GetInstance(Of IProductosService)()
        notificationHandler.AddSubscriber(frmCompras, "Crear", "Actualizar", "Error", "MuchasMas")
        'notificationHandler.AddSubscriber("Actualizar", frmCompras)
        frmProductos = New frmProductos(productosService, notificationHandler)
        frmProductos.Show()
    End Sub

    Private Sub btnCompras_Click(sender As Object, e As EventArgs) Handles btnCompras.Click

        Dim productosService = contenedor.GetInstance(Of IProductosService)()
        Dim compraService = contenedor.GetInstance(Of IComprasService)()
        Dim sucursalesService = contenedor.GetInstance(Of ISucursalesService)()
        Dim proveedoresService = contenedor.GetInstance(Of IProveedoresService)()

        frmCompras = New frmCompras(productosService, compraService, sucursalesService, proveedoresService)
        frmCompras.Show()
    End Sub
End Class
