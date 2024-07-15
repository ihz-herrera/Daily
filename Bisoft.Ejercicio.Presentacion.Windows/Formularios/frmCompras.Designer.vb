<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompras
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        cmbProveedor = New ComboBox()
        Label1 = New Label()
        Label2 = New Label()
        cmbProducto = New ComboBox()
        dgvCompras = New DataGridView()
        btnGuardar = New Button()
        Label3 = New Label()
        cmbSucursal = New ComboBox()
        CType(dgvCompras, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' cmbProveedor
        ' 
        cmbProveedor.FormattingEnabled = True
        cmbProveedor.Location = New Point(12, 108)
        cmbProveedor.Name = "cmbProveedor"
        cmbProveedor.Size = New Size(219, 28)
        cmbProveedor.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 85)
        Label1.Name = "Label1"
        Label1.Size = New Size(77, 20)
        Label1.TabIndex = 1
        Label1.Text = "Proveedor"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 143)
        Label2.Name = "Label2"
        Label2.Size = New Size(69, 20)
        Label2.TabIndex = 3
        Label2.Text = "Producto"
        ' 
        ' cmbProducto
        ' 
        cmbProducto.FormattingEnabled = True
        cmbProducto.Location = New Point(12, 166)
        cmbProducto.Name = "cmbProducto"
        cmbProducto.Size = New Size(219, 28)
        cmbProducto.TabIndex = 2
        ' 
        ' dgvCompras
        ' 
        dgvCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCompras.Location = New Point(288, 12)
        dgvCompras.Name = "dgvCompras"
        dgvCompras.RowHeadersWidth = 51
        dgvCompras.RowTemplate.Height = 29
        dgvCompras.Size = New Size(597, 426)
        dgvCompras.TabIndex = 4
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(12, 403)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(111, 35)
        btnGuardar.TabIndex = 5
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 31)
        Label3.Name = "Label3"
        Label3.Size = New Size(63, 20)
        Label3.TabIndex = 7
        Label3.Text = "Sucursal"
        ' 
        ' cmbSucursal
        ' 
        cmbSucursal.FormattingEnabled = True
        cmbSucursal.Location = New Point(12, 54)
        cmbSucursal.Name = "cmbSucursal"
        cmbSucursal.Size = New Size(219, 28)
        cmbSucursal.TabIndex = 6
        ' 
        ' frmCompras
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(897, 450)
        Controls.Add(Label3)
        Controls.Add(cmbSucursal)
        Controls.Add(btnGuardar)
        Controls.Add(dgvCompras)
        Controls.Add(Label2)
        Controls.Add(cmbProducto)
        Controls.Add(Label1)
        Controls.Add(cmbProveedor)
        Name = "frmCompras"
        Text = "Compras"
        CType(dgvCompras, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cmbProveedor As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbProducto As ComboBox
    Friend WithEvents dgvCompras As DataGridView
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbSucursal As ComboBox
End Class
