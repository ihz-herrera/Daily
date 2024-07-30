<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductos
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
        components = New ComponentModel.Container()
        Label1 = New Label()
        txtId = New TextBox()
        txtDescripcion = New TextBox()
        Label2 = New Label()
        txtPrecio = New TextBox()
        Label4 = New Label()
        chkEstatus = New CheckBox()
        btnGuardar = New Button()
        ProveedorBindingSource = New BindingSource(components)
        dgvProductos = New DataGridView()
        txtCosto = New TextBox()
        Label3 = New Label()
        btnNext = New Button()
        btnPrevius = New Button()
        btnLoadMore = New Button()
        lblPagination = New Label()
        txtBuscador = New TextBox()
        CType(ProveedorBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvProductos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(22, 20)
        Label1.TabIndex = 0
        Label1.Text = "Id"
        ' 
        ' txtId
        ' 
        txtId.Location = New Point(12, 32)
        txtId.Name = "txtId"
        txtId.Size = New Size(125, 27)
        txtId.TabIndex = 1
        ' 
        ' txtDescripcion
        ' 
        txtDescripcion.Location = New Point(12, 89)
        txtDescripcion.Name = "txtDescripcion"
        txtDescripcion.Size = New Size(266, 27)
        txtDescripcion.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 66)
        Label2.Name = "Label2"
        Label2.Size = New Size(87, 20)
        Label2.TabIndex = 2
        Label2.Text = "Descripción"
        ' 
        ' txtPrecio
        ' 
        txtPrecio.Location = New Point(12, 144)
        txtPrecio.Name = "txtPrecio"
        txtPrecio.Size = New Size(266, 27)
        txtPrecio.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 121)
        Label4.Name = "Label4"
        Label4.Size = New Size(50, 20)
        Label4.TabIndex = 4
        Label4.Text = "Precio"
        ' 
        ' chkEstatus
        ' 
        chkEstatus.AutoSize = True
        chkEstatus.Location = New Point(12, 243)
        chkEstatus.Name = "chkEstatus"
        chkEstatus.Size = New Size(77, 24)
        chkEstatus.TabIndex = 8
        chkEstatus.Text = "Estatus"
        chkEstatus.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(12, 289)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(94, 29)
        btnGuardar.TabIndex = 9
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' dgvProductos
        ' 
        dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProductos.Location = New Point(313, 66)
        dgvProductos.Name = "dgvProductos"
        dgvProductos.RowHeadersWidth = 51
        dgvProductos.RowTemplate.Height = 29
        dgvProductos.Size = New Size(632, 252)
        dgvProductos.TabIndex = 10
        ' 
        ' txtCosto
        ' 
        txtCosto.Location = New Point(12, 200)
        txtCosto.Name = "txtCosto"
        txtCosto.Size = New Size(266, 27)
        txtCosto.TabIndex = 7
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 177)
        Label3.Name = "Label3"
        Label3.Size = New Size(47, 20)
        Label3.TabIndex = 6
        Label3.Text = "Costo"
        ' 
        ' btnNext
        ' 
        btnNext.Location = New Point(843, 324)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(90, 40)
        btnNext.TabIndex = 11
        btnNext.Text = ">>"
        btnNext.UseVisualStyleBackColor = True
        ' 
        ' btnPrevius
        ' 
        btnPrevius.Location = New Point(634, 326)
        btnPrevius.Name = "btnPrevius"
        btnPrevius.Size = New Size(90, 40)
        btnPrevius.TabIndex = 12
        btnPrevius.Text = "<<"
        btnPrevius.UseVisualStyleBackColor = True
        ' 
        ' btnLoadMore
        ' 
        btnLoadMore.Location = New Point(313, 326)
        btnLoadMore.Name = "btnLoadMore"
        btnLoadMore.Size = New Size(90, 40)
        btnLoadMore.TabIndex = 13
        btnLoadMore.Text = "Load"
        btnLoadMore.UseVisualStyleBackColor = True
        ' 
        ' lblPagination
        ' 
        lblPagination.AutoSize = True
        lblPagination.Location = New Point(741, 334)
        lblPagination.Name = "lblPagination"
        lblPagination.Size = New Size(96, 20)
        lblPagination.TabIndex = 14
        lblPagination.Text = "lblPagination"
        ' 
        ' txtBuscador
        ' 
        txtBuscador.Location = New Point(313, 33)
        txtBuscador.Name = "txtBuscador"
        txtBuscador.Size = New Size(632, 27)
        txtBuscador.TabIndex = 15
        ' 
        ' frmProductos
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(945, 378)
        Controls.Add(txtBuscador)
        Controls.Add(lblPagination)
        Controls.Add(btnLoadMore)
        Controls.Add(btnPrevius)
        Controls.Add(btnNext)
        Controls.Add(txtCosto)
        Controls.Add(Label3)
        Controls.Add(dgvProductos)
        Controls.Add(btnGuardar)
        Controls.Add(chkEstatus)
        Controls.Add(txtPrecio)
        Controls.Add(Label4)
        Controls.Add(txtDescripcion)
        Controls.Add(Label2)
        Controls.Add(txtId)
        Controls.Add(Label1)
        Name = "frmProductos"
        Text = "Productos"
        CType(ProveedorBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvProductos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtId As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkEstatus As CheckBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents ProveedorBindingSource As BindingSource
    Friend WithEvents dgvProductos As DataGridView
    Friend WithEvents txtCosto As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrevius As Button
    Friend WithEvents btnLoadMore As Button
    Friend WithEvents lblPagination As Label
    Friend WithEvents txtBuscador As TextBox
End Class
