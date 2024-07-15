<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MEnu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnProveedores = New Button()
        btnProductos = New Button()
        btnCompras = New Button()
        SuspendLayout()
        ' 
        ' btnProveedores
        ' 
        btnProveedores.Location = New Point(12, 55)
        btnProveedores.Name = "btnProveedores"
        btnProveedores.Size = New Size(102, 29)
        btnProveedores.TabIndex = 0
        btnProveedores.Text = "Proveedores"
        btnProveedores.UseVisualStyleBackColor = True
        ' 
        ' btnProductos
        ' 
        btnProductos.Location = New Point(12, 90)
        btnProductos.Name = "btnProductos"
        btnProductos.Size = New Size(102, 29)
        btnProductos.TabIndex = 1
        btnProductos.Text = "Productos"
        btnProductos.UseVisualStyleBackColor = True
        ' 
        ' btnCompras
        ' 
        btnCompras.Location = New Point(12, 125)
        btnCompras.Name = "btnCompras"
        btnCompras.Size = New Size(102, 29)
        btnCompras.TabIndex = 2
        btnCompras.Text = "Compras"
        btnCompras.UseVisualStyleBackColor = True
        ' 
        ' MEnu
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnCompras)
        Controls.Add(btnProductos)
        Controls.Add(btnProveedores)
        Name = "MEnu"
        Text = "Form1"
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnProveedores As Button
    Friend WithEvents btnProductos As Button
    Friend WithEvents btnCompras As Button

End Class
