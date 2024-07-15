Imports BISoft.Ejercicios.Aplicacion.Fabricas
Imports Bisoft.Ejercicios.Dominio.Builders
Imports Bisoft.Ejercicios.Infraestructura.Contextos
Imports Bisoft.Ejercicios.Infraestructura.Entidades
Imports Bisoft.Ejercicios.Infraestructura.Repositorios

Public Class frmProductos
    Private Sub frmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim repo As ProductosRepository = ProductosRepositoryFactory _
                .GetProductosRepository("EF")

        Dim productos = repo.ObtenerTodos()

        dgvProductos.DataSource = productos

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            Dim repositorio As ProductosRepository = ProductosRepositoryFactory.GetProductosRepository("EF")

            Dim productoConsulta As Producto = repositorio _
                                .ObtenerPorExpresion(Function(p) _
                                     p.ProductoId = txtId.Text
                                )


            Dim producto = ProductoBuilder.Empty _
                .WithId(txtId.Text) _
                .WithDescripcion(txtDescripcion.Text) _
                .WithPrecio(txtPrecio.Text) _
                .WithCosto(txtCosto.Text) _
                .WithStatus(chkEstatus.Checked) _
                .Build()

            If productoConsulta IsNot Nothing Then
                repositorio.Actualizar(producto)
            Else
                repositorio.Crear(producto)
            End If



            'Dim productoCrear As New Producto(
            '        txtId.Text,
            '        txtDescripcion.Text,
            '        txtPrecio.Text,
            '        txtCosto.Text,
            '        chkEstatus.Checked
            ')


            MessageBox.Show("Producto guardado correctamente")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


End Class