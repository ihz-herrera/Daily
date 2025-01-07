<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProveedores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProveedores))
        Label1 = New Label()
        txtId = New TextBox()
        txtNombre = New TextBox()
        Label2 = New Label()
        txtDireccion = New TextBox()
        Label3 = New Label()
        btnGuardas = New Button()
        Button1 = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(37, 39)
        Label1.Name = "Label1"
        Label1.Size = New Size(22, 20)
        Label1.TabIndex = 0
        Label1.Text = "Id"
        ' 
        ' txtId
        ' 
        txtId.Location = New Point(37, 62)
        txtId.Name = "txtId"
        txtId.Size = New Size(125, 27)
        txtId.TabIndex = 1
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(37, 121)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(185, 27)
        txtNombre.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(37, 98)
        Label2.Name = "Label2"
        Label2.Size = New Size(64, 20)
        Label2.TabIndex = 2
        Label2.Text = "Nombre"
        ' 
        ' txtDireccion
        ' 
        txtDireccion.Location = New Point(37, 179)
        txtDireccion.Name = "txtDireccion"
        txtDireccion.Size = New Size(185, 27)
        txtDireccion.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(37, 156)
        Label3.Name = "Label3"
        Label3.Size = New Size(72, 20)
        Label3.TabIndex = 4
        Label3.Text = "Dirección"
        ' 
        ' btnGuardas
        ' 
        btnGuardas.Location = New Point(37, 247)
        btnGuardas.Name = "btnGuardas"
        btnGuardas.Size = New Size(94, 29)
        btnGuardas.TabIndex = 6
        btnGuardas.Text = "Guardar"
        btnGuardas.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), Image)
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Location = New Point(179, 62)
        Button1.Name = "Button1"
        Button1.Size = New Size(32, 29)
        Button1.TabIndex = 7
        Button1.UseVisualStyleBackColor = True
        ' 
        ' frmProveedores
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Button1)
        Controls.Add(btnGuardas)
        Controls.Add(txtDireccion)
        Controls.Add(Label3)
        Controls.Add(txtNombre)
        Controls.Add(Label2)
        Controls.Add(txtId)
        Controls.Add(Label1)
        Name = "frmProveedores"
        Text = "Proveedores"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtId As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnGuardas As Button
    Friend WithEvents Button1 As Button
End Class
