Imports SimpleInjector
Imports System.Net.Http.Headers
Imports BISoft.Ejercicios.Aplicacion.Servicios
Imports BISoft.Ejercicios.Infraestructura.Contratos
Imports BISoft.Ejercicios.Infraestructura.Repositorios
Imports BISoft.Ejercicios.Dominio.Contratos
Imports BISoft.Ejercicios.Infraestructura.Contextos
Imports BISoft.Ejercicios.Dominio.Entidades

Public Class MEnu

    Private contenedor As Container


    Public Sub New()
        InitializeComponent()
        contenedor = New Container()

        ConfigurarIoC()
    End Sub

    Private Sub ConfigurarIoC()

        contenedor.Register(Of ProductosService)()

        contenedor.Register(Of IProductosRepository, ProductosRepository)()
        contenedor.Register(Of ICategoriasRepository, CategoriasRepository)()
        contenedor.Register(Of IFabricantesRepository, FabricantesRepository)()

        contenedor.Register(Of OutboxRepository)()

        contenedor.Register(Of Context)(Lifestyle.Singleton)

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

        Dim frm As New frmProductos(productosService)
        frm.Show()
    End Sub

    Private Sub btnCompras_Click(sender As Object, e As EventArgs) Handles btnCompras.Click

        Dim productosService = contenedor.GetInstance(Of ProductosService)()

        Dim frm As New frmCompras(productosService)
        frm.Show()
    End Sub
End Class
