﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWareQCLoadNO
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton
        Me.txtPM_NO = New DevExpress.XtraEditors.TextEdit
        Me.Label21 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GoIn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AutoID = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.txtPM_NO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Appearance.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdExit.Appearance.Options.UseFont = True
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.Image = Global.LFERP.My.Resources.Resources.SharingRequestDeny
        Me.cmdExit.Location = New System.Drawing.Point(421, 254)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 25)
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.Text = "取消(&C)"
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Appearance.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdSave.Appearance.Options.UseFont = True
        Me.cmdSave.Image = Global.LFERP.My.Resources.Resources.SharingRequestAllow
        Me.cmdSave.Location = New System.Drawing.Point(329, 254)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 25)
        Me.cmdSave.TabIndex = 4
        Me.cmdSave.Text = "確定(&O)"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Location = New System.Drawing.Point(432, 6)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(69, 25)
        Me.SimpleButton1.TabIndex = 2
        Me.SimpleButton1.Text = "載入(&L)"
        '
        'txtPM_NO
        '
        Me.txtPM_NO.Location = New System.Drawing.Point(82, 7)
        Me.txtPM_NO.Name = "txtPM_NO"
        Me.txtPM_NO.Properties.Appearance.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtPM_NO.Properties.Appearance.Options.UseFont = True
        Me.txtPM_NO.Size = New System.Drawing.Size(345, 22)
        Me.txtPM_NO.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(4, 12)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(84, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "發出單號(&I)："
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GoIn, Me.Column1, Me.Column2, Me.Column3, Me.AutoID})
        Me.DataGridView1.Location = New System.Drawing.Point(0, 36)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(502, 209)
        Me.DataGridView1.TabIndex = 3
        '
        'GoIn
        '
        Me.GoIn.HeaderText = "加入"
        Me.GoIn.Name = "GoIn"
        Me.GoIn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GoIn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.GoIn.Width = 60
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "M_Name"
        Me.Column1.HeaderText = "物料名稱"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "M_Gauge"
        Me.Column2.HeaderText = "規格"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 400
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "M_Code"
        Me.Column3.HeaderText = "物料編號"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'AutoID
        '
        Me.AutoID.DataPropertyName = "AutoID"
        Me.AutoID.HeaderText = "抽檢流水號"
        Me.AutoID.Name = "AutoID"
        Me.AutoID.ReadOnly = True
        Me.AutoID.Visible = False
        '
        'frmWareQCLoadNO
        '
        Me.AcceptButton = Me.cmdExit
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdExit
        Me.ClientSize = New System.Drawing.Size(503, 283)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.txtPM_NO)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWareQCLoadNO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "選擇抽檢物料"
        CType(Me.txtPM_NO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtPM_NO As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GoIn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AutoID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
