Imports BISoft.Ejercicios.Aplicacion.Haddlers
Imports BISoft.Ejercicios.Aplicacion.Servicios
Imports BISoft.Ejercicios.Dominio.Contratos
Imports BISoft.Ejercicios.Dominio.Entidades
Imports BISoft.Ejercicios.Infraestructura.Contextos
Imports BISoft.Ejercicios.Infraestructura.Repositorios
Imports SimpleInjector

Public Class MEnu

    Private contenedor As Container
    Private notificationHandler As NotificationHandler(Of Producto)
    Private notificationProveedorHandler As NotificationHandler(Of Proveedor)


    Dim frmProductos As frmProductos
    Dim frmCompras As frmCompras
    Public Sub New()
        InitializeComponent()
        contenedor = New Container()

        ConfigurarIoC()
        notificationHandler = New NotificationHandler(Of Producto)
    End Sub

    Private Sub ConfigurarIoC()

        contenedor.Register(Of ProductosService)()

        contenedor.Register(Of IProductosRepository, ProductosRepository)()
        contenedor.Register(Of ICategoriasRepository, CategoriasRepository)()
        contenedor.Register(Of IFabricantesRepository, FabricantesRepository)()

        contenedor.Register(Of OutboxRepository)()
        contenedor.Register(Of Context)(Lifestyle.Singleton)

        'Dim Registration = contenedor.GetRegistration(GetType(Context)).Registration

        'Registration.SuppressDiagnosticWarning(
        '        DiagnosticType.DisposableTransientComponent,
        '            "Reason of suppression")

        contenedor.Verify()


    End Sub

    Private Sub btnProveedores_Click(sender As Object, e As EventArgs) Handles btnProveedores.Click
        Dim frm As New frmProveedores
        frm.Tema = "Tema"
        frm.Show()
    End Sub

    Private Sub btnProductos_Click(sender As Object, e As EventArgs) Handles btnProductos.Click
        Dim emailService As New EmailService()
        emailService.SendEmail("ivan@gmail.com", "Hola", "Hola Ivan")

        Dim productosService = contenedor.GetInstance(Of ProductosService)()
        notificationHandler.AddSubscriber("Crear", frmCompras)
        notificationHandler.AddSubscriber("Actualizar", frmCompras)
        frmProductos = New frmProductos(productosService, notificationHandler)
        frmProductos.Show()
    End Sub

    Private Sub btnCompras_Click(sender As Object, e As EventArgs) Handles btnCompras.Click

        Dim productosService = contenedor.GetInstance(Of ProductosService)()

        frmCompras = New frmCompras(productosService)
        frmCompras.Show()
    End Sub
End Class
