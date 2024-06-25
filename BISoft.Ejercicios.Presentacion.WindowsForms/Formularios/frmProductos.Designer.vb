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
        TextBox1 = New TextBox()
        Label2 = New Label()
        TextBox3 = New TextBox()
        Label4 = New Label()
        chkEstatus = New CheckBox()
        btnGuardar = New Button()
        ProveedorBindingSource = New BindingSource(components)
        DataGridView1 = New DataGridView()
        CType(ProveedorBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
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
        ' TextBox1
        ' 
        TextBox1.Location = New Point(12, 89)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(266, 27)
        TextBox1.TabIndex = 3
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
        ' TextBox3
        ' 
        TextBox3.Location = New Point(12, 144)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(266, 27)
        TextBox3.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 121)
        Label4.Name = "Label4"
        Label4.Size = New Size(50, 20)
        Label4.TabIndex = 6
        Label4.Text = "Precio"
        ' 
        ' chkEstatus
        ' 
        chkEstatus.AutoSize = True
        chkEstatus.Location = New Point(12, 186)
        chkEstatus.Name = "chkEstatus"
        chkEstatus.Size = New Size(77, 24)
        chkEstatus.TabIndex = 8
        chkEstatus.Text = "Estatus"
        chkEstatus.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(12, 232)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(94, 29)
        btnGuardar.TabIndex = 9
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' ProveedorBindingSource
        ' 
        ProveedorBindingSource.DataSource = GetType(Infraestructura.Entidades.Proveedor)
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(321, 24)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.RowTemplate.Height = 29
        DataGridView1.Size = New Size(467, 237)
        DataGridView1.TabIndex = 10
        ' 
        ' frmProductos
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 287)
        Controls.Add(DataGridView1)
        Controls.Add(btnGuardar)
        Controls.Add(chkEstatus)
        Controls.Add(TextBox3)
        Controls.Add(Label4)
        Controls.Add(TextBox1)
        Controls.Add(Label2)
        Controls.Add(txtId)
        Controls.Add(Label1)
        Name = "frmProductos"
        Text = "Productos"
        CType(ProveedorBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtId As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkEstatus As CheckBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents ProveedorBindingSource As BindingSource
    Friend WithEvents DataGridView1 As DataGridView
End Class
