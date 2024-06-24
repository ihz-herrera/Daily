Imports BISoft.Ejercicios.Infraestructura.Contextos
Imports BISoft.Ejercicios.Infraestructura.Entidades
Imports Microsoft.EntityFrameworkCore

Public Class frmProveedores
    Private Sub frmProveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnGuardas_Click(sender As Object, e As EventArgs) Handles btnGuardas.Click

        Dim contexto As New Context


        'Consultar si el proveedor ya existe
        Dim proveedor = contexto.Proveedores.Where(Function(p) p.Id = txtId.Text _
            Or p.Nombre = txtNombre.Text).AsNoTracking.FirstOrDefault

        If (proveedor IsNot Nothing) Then

            'proveedor.Nombre = txtNombre.Text
            'proveedor.Direccion = txtDireccion.Text

            proveedor = New Proveedor
            proveedor.Id = txtId.Text
            proveedor.Nombre = txtNombre.Text
            proveedor.Direccion = txtDireccion.Text

            contexto.Proveedores.Update(proveedor)


        Else
            proveedor = New Proveedor
            proveedor.Id = txtId.Text
            proveedor.Nombre = txtNombre.Text
            proveedor.Direccion = txtDireccion.Text

            'Agregamos el proveedor al contexto
            contexto.Proveedores.Add(proveedor)
        End If


        'Guardamos los cambios
        contexto.SaveChanges()

        MsgBox("Proveedor guardado correctamente")

    End Sub
End Class