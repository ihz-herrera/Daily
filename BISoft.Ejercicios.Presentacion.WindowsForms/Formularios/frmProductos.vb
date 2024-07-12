Imports BISoft.Ejercicios.Aplicacion.Fabricas
Imports BISoft.Ejercicios.Infraestructura.Contextos
Imports BISoft.Ejercicios.Infraestructura.Entidades
Imports BISoft.Ejercicios.Infraestructura.Repositorios

Public Class frmProductos
    Private Sub frmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim contexto As New Context
        Dim productos = contexto.Productos.ToList()

        dgvProductos.DataSource = productos



    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            Dim repositorio As ProductosRepository = ProductosRepositoryFactory.GetProductosRepository("EF")


            Dim producto As Producto = repositorio.ObtenerPorExpresion(Function(p) _
                                                                           p.ProductoId = txtId.Text
                                                                           )


            Dim productoCrear As New Producto(
                    txtId.Text,
                    txtDescripcion.Text,
                    txtPrecio.Text,
                    txtCosto.Text,
                    chkEstatus.Checked
            )

            repositorio.Crear(producto)
            MessageBox.Show("Producto guardado correctamente")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
End Class