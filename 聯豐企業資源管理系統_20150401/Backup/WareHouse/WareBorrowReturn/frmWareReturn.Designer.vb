﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWareReturn
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
        Me.components = New System.ComponentModel.Container
        Me.Remark = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
        Me.Grid = New DevExpress.XtraGrid.GridControl
        Me.popWareWB = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.popWareReturnAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.popWareOutDel = New System.Windows.Forms.ToolStripMenuItem
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.AutoID = New DevExpress.XtraGrid.Columns.GridColumn
        Me.M_Code = New DevExpress.XtraGrid.Columns.GridColumn
        Me.M_Name = New DevExpress.XtraGrid.Columns.GridColumn
        Me.M_Gauge = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RemarkItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
        Me.M_Unit = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Qty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCalcEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        Me.NoReturnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        Me.QtyItemCalcEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        Me.MCodeText = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.RepositoryItemButtonEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        Me.RepositoryItemButtonEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        Me.RepositoryItemGridLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.rtxtAP_NO = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit
        Me.Label5 = New System.Windows.Forms.Label
        Me.ButtonEdit2 = New DevExpress.XtraEditors.ButtonEdit
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.sk = New DevExpress.XtraEditors.SimpleButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LabReReturn = New System.Windows.Forms.Label
        Me.TxtReReturn = New DevExpress.XtraEditors.TextEdit
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtWH = New DevExpress.XtraEditors.ButtonEdit
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.LabMsg = New System.Windows.Forms.Label
        Me.txtWBID = New DevExpress.XtraEditors.TextEdit
        Me.PrintButton = New DevExpress.XtraEditors.SimpleButton
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popWareWB.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RemarkItemMemoExEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCalcEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QtyItemCalcEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MCodeText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemGridLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rtxtAP_NO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TxtReReturn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWBID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Remark
        '
        Me.Remark.Caption = "備注"
        Me.Remark.ColumnEdit = Me.RepositoryItemMemoExEdit1
        Me.Remark.FieldName = "Remark"
        Me.Remark.Name = "Remark"
        Me.Remark.Visible = True
        Me.Remark.VisibleIndex = 6
        Me.Remark.Width = 200
        '
        'RepositoryItemMemoExEdit1
        '
        Me.RepositoryItemMemoExEdit1.AutoHeight = False
        Me.RepositoryItemMemoExEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit1.Name = "RepositoryItemMemoExEdit1"
        Me.RepositoryItemMemoExEdit1.ShowIcon = False
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.ContextMenuStrip = Me.popWareWB
        Me.Grid.EmbeddedNavigator.Name = ""
        Me.Grid.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Grid.Location = New System.Drawing.Point(2, 138)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.RemarkItemMemoExEdit1, Me.QtyItemCalcEdit, Me.RepositoryItemCheckEdit1, Me.RepositoryItemButtonEdit2, Me.MCodeText, Me.RepositoryItemTextEdit2, Me.RepositoryItemComboBox1, Me.RepositoryItemButtonEdit3, Me.RepositoryItemButtonEdit4, Me.RepositoryItemGridLookUpEdit1, Me.rtxtAP_NO, Me.RepositoryItemMemoExEdit1, Me.RepositoryItemCalcEdit1})
        Me.Grid.Size = New System.Drawing.Size(805, 325)
        Me.Grid.TabIndex = 182
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'popWareWB
        '
        Me.popWareWB.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.popWareReturnAdd, Me.popWareOutDel})
        Me.popWareWB.Name = "popWareInput"
        Me.popWareWB.Size = New System.Drawing.Size(157, 48)
        '
        'popWareReturnAdd
        '
        Me.popWareReturnAdd.Image = Global.LFERP.My.Resources.Resources.QueryAppend
        Me.popWareReturnAdd.Name = "popWareReturnAdd"
        Me.popWareReturnAdd.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.popWareReturnAdd.Size = New System.Drawing.Size(156, 22)
        Me.popWareReturnAdd.Text = "新增(&A)..."
        '
        'popWareOutDel
        '
        Me.popWareOutDel.Image = Global.LFERP.My.Resources.Resources.QueryDelete
        Me.popWareOutDel.Name = "popWareOutDel"
        Me.popWareOutDel.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.popWareOutDel.Size = New System.Drawing.Size(156, 22)
        Me.popWareOutDel.Text = "刪除(&D)"
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.AutoID, Me.M_Code, Me.M_Name, Me.M_Gauge, Me.M_Unit, Me.Qty, Me.NoReturnQty, Me.Remark})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsCustomization.AllowColumnMoving = False
        Me.GridView1.OptionsCustomization.AllowFilter = False
        Me.GridView1.OptionsCustomization.AllowSort = False
        Me.GridView1.OptionsFilter.AllowColumnMRUFilterList = False
        Me.GridView1.OptionsFilter.AllowFilterEditor = False
        Me.GridView1.OptionsFilter.AllowMRUFilterList = False
        Me.GridView1.OptionsSelection.UseIndicatorForSelection = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.RowAutoHeight = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'AutoID
        '
        Me.AutoID.Caption = "AutoID"
        Me.AutoID.FieldName = "AutoID"
        Me.AutoID.Name = "AutoID"
        Me.AutoID.OptionsColumn.ReadOnly = True
        '
        'M_Code
        '
        Me.M_Code.Caption = "物料編碼"
        Me.M_Code.FieldName = "M_Code"
        Me.M_Code.Name = "M_Code"
        Me.M_Code.OptionsColumn.ReadOnly = True
        Me.M_Code.Visible = True
        Me.M_Code.VisibleIndex = 0
        Me.M_Code.Width = 142
        '
        'M_Name
        '
        Me.M_Name.Caption = "物料名稱"
        Me.M_Name.FieldName = "M_Name"
        Me.M_Name.Name = "M_Name"
        Me.M_Name.OptionsColumn.AllowEdit = False
        Me.M_Name.OptionsColumn.ReadOnly = True
        Me.M_Name.Visible = True
        Me.M_Name.VisibleIndex = 1
        Me.M_Name.Width = 95
        '
        'M_Gauge
        '
        Me.M_Gauge.Caption = "規格"
        Me.M_Gauge.ColumnEdit = Me.RemarkItemMemoExEdit1
        Me.M_Gauge.FieldName = "M_Gauge"
        Me.M_Gauge.Name = "M_Gauge"
        Me.M_Gauge.OptionsColumn.ReadOnly = True
        Me.M_Gauge.Visible = True
        Me.M_Gauge.VisibleIndex = 2
        Me.M_Gauge.Width = 122
        '
        'RemarkItemMemoExEdit1
        '
        Me.RemarkItemMemoExEdit1.AutoHeight = False
        Me.RemarkItemMemoExEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RemarkItemMemoExEdit1.Name = "RemarkItemMemoExEdit1"
        Me.RemarkItemMemoExEdit1.ShowIcon = False
        '
        'M_Unit
        '
        Me.M_Unit.Caption = "單位"
        Me.M_Unit.FieldName = "M_Unit"
        Me.M_Unit.Name = "M_Unit"
        Me.M_Unit.OptionsColumn.ReadOnly = True
        Me.M_Unit.Visible = True
        Me.M_Unit.VisibleIndex = 3
        '
        'Qty
        '
        Me.Qty.Caption = "還刀數"
        Me.Qty.ColumnEdit = Me.RepositoryItemCalcEdit1
        Me.Qty.FieldName = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.Visible = True
        Me.Qty.VisibleIndex = 4
        '
        'RepositoryItemCalcEdit1
        '
        Me.RepositoryItemCalcEdit1.AutoHeight = False
        Me.RepositoryItemCalcEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemCalcEdit1.Name = "RepositoryItemCalcEdit1"
        '
        'NoReturnQty
        '
        Me.NoReturnQty.Caption = "未還刀數"
        Me.NoReturnQty.FieldName = "NoReturnQty"
        Me.NoReturnQty.Name = "NoReturnQty"
        Me.NoReturnQty.OptionsColumn.ReadOnly = True
        Me.NoReturnQty.Visible = True
        Me.NoReturnQty.VisibleIndex = 5
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'QtyItemCalcEdit
        '
        Me.QtyItemCalcEdit.AutoHeight = False
        Me.QtyItemCalcEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.QtyItemCalcEdit.Name = "QtyItemCalcEdit"
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'RepositoryItemButtonEdit2
        '
        Me.RepositoryItemButtonEdit2.AutoHeight = False
        Me.RepositoryItemButtonEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemButtonEdit2.Name = "RepositoryItemButtonEdit2"
        '
        'MCodeText
        '
        Me.MCodeText.AutoHeight = False
        Me.MCodeText.Name = "MCodeText"
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Items.AddRange(New Object() {"申領人員寫錯,倉庫發實物"})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'RepositoryItemButtonEdit3
        '
        Me.RepositoryItemButtonEdit3.AutoHeight = False
        Me.RepositoryItemButtonEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemButtonEdit3.Name = "RepositoryItemButtonEdit3"
        '
        'RepositoryItemButtonEdit4
        '
        Me.RepositoryItemButtonEdit4.AutoHeight = False
        Me.RepositoryItemButtonEdit4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemButtonEdit4.Name = "RepositoryItemButtonEdit4"
        '
        'RepositoryItemGridLookUpEdit1
        '
        Me.RepositoryItemGridLookUpEdit1.AutoHeight = False
        Me.RepositoryItemGridLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemGridLookUpEdit1.Name = "RepositoryItemGridLookUpEdit1"
        Me.RepositoryItemGridLookUpEdit1.NullText = ""
        Me.RepositoryItemGridLookUpEdit1.View = Me.GridView2
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'rtxtAP_NO
        '
        Me.rtxtAP_NO.AutoHeight = False
        Me.rtxtAP_NO.Name = "rtxtAP_NO"
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Appearance.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdSave.Appearance.Options.UseFont = True
        Me.cmdSave.Image = Global.LFERP.My.Resources.Resources.SharingRequestAllow
        Me.cmdSave.Location = New System.Drawing.Point(586, 469)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(90, 30)
        Me.cmdSave.TabIndex = 183
        Me.cmdSave.Text = "確定(&O)"
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Appearance.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmdExit.Appearance.Options.UseFont = True
        Me.cmdExit.Image = Global.LFERP.My.Resources.Resources.SharingRequestDeny
        Me.cmdExit.Location = New System.Drawing.Point(705, 469)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(90, 30)
        Me.cmdExit.TabIndex = 184
        Me.cmdExit.Text = "取消(&C)"
        '
        'TextEdit1
        '
        Me.TextEdit1.Enabled = False
        Me.TextEdit1.Location = New System.Drawing.Point(531, 20)
        Me.TextEdit1.Margin = New System.Windows.Forms.Padding(6)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.Appearance.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextEdit1.Properties.Appearance.Options.UseFont = True
        Me.TextEdit1.Size = New System.Drawing.Size(120, 24)
        Me.TextEdit1.TabIndex = 5
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(99, 59)
        Me.DateEdit1.Margin = New System.Windows.Forms.Padding(6)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Appearance.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DateEdit1.Properties.Appearance.Options.UseFont = True
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Size = New System.Drawing.Size(120, 24)
        Me.DateEdit1.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(450, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "還刀人(&N):"
        '
        'ButtonEdit2
        '
        Me.ButtonEdit2.Location = New System.Drawing.Point(325, 20)
        Me.ButtonEdit2.Margin = New System.Windows.Forms.Padding(6)
        Me.ButtonEdit2.Name = "ButtonEdit2"
        Me.ButtonEdit2.Properties.Appearance.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ButtonEdit2.Properties.Appearance.Options.UseFont = True
        Me.ButtonEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.ButtonEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ButtonEdit2.Size = New System.Drawing.Size(120, 24)
        Me.ButtonEdit2.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(218, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "還刀人部門(&D):"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(3, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 15)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "還刀日期(&E):"
        '
        'sk
        '
        Me.sk.Appearance.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.sk.Appearance.Options.UseFont = True
        Me.sk.Location = New System.Drawing.Point(736, 16)
        Me.sk.Name = "sk"
        Me.sk.Size = New System.Drawing.Size(57, 28)
        Me.sk.TabIndex = 6
        Me.sk.Text = "刷卡(&S)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.LabReReturn)
        Me.GroupBox1.Controls.Add(Me.TxtReReturn)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextEdit1)
        Me.GroupBox1.Controls.Add(Me.DateEdit1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ButtonEdit2)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.sk)
        Me.GroupBox1.Controls.Add(Me.txtWH)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(805, 93)
        Me.GroupBox1.TabIndex = 179
        Me.GroupBox1.TabStop = False
        '
        'LabReReturn
        '
        Me.LabReReturn.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabReReturn.ForeColor = System.Drawing.SystemColors.Desktop
        Me.LabReReturn.Location = New System.Drawing.Point(448, 63)
        Me.LabReReturn.Name = "LabReReturn"
        Me.LabReReturn.Size = New System.Drawing.Size(82, 17)
        Me.LabReReturn.TabIndex = 186
        '
        'TxtReReturn
        '
        Me.TxtReReturn.Enabled = False
        Me.TxtReReturn.Location = New System.Drawing.Point(325, 59)
        Me.TxtReReturn.Margin = New System.Windows.Forms.Padding(6)
        Me.TxtReReturn.Name = "TxtReReturn"
        Me.TxtReReturn.Properties.Appearance.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TxtReReturn.Properties.Appearance.Options.UseFont = True
        Me.TxtReReturn.Size = New System.Drawing.Size(120, 24)
        Me.TxtReReturn.TabIndex = 185
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(223, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 15)
        Me.Label3.TabIndex = 184
        Me.Label3.Text = "代還刀人(&B):"
        '
        'txtWH
        '
        Me.txtWH.Location = New System.Drawing.Point(99, 20)
        Me.txtWH.Margin = New System.Windows.Forms.Padding(6)
        Me.txtWH.Name = "txtWH"
        Me.txtWH.Properties.Appearance.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtWH.Properties.Appearance.Options.UseFont = True
        Me.txtWH.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.txtWH.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtWH.Size = New System.Drawing.Size(120, 24)
        Me.txtWH.TabIndex = 1
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(6, 25)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(88, 15)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "倉      庫(&W):"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label4.Location = New System.Drawing.Point(657, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 183
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(7, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 24)
        Me.Label1.TabIndex = 178
        Me.Label1.Text = "還樣辦刀"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(1, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(805, 36)
        Me.PictureBox1.TabIndex = 177
        Me.PictureBox1.TabStop = False
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label20.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(589, 10)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 13)
        Me.Label20.TabIndex = 180
        Me.Label20.Text = "還刀單號："
        '
        'LabMsg
        '
        Me.LabMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabMsg.AutoSize = True
        Me.LabMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabMsg.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabMsg.ForeColor = System.Drawing.Color.Black
        Me.LabMsg.Location = New System.Drawing.Point(164, 14)
        Me.LabMsg.Name = "LabMsg"
        Me.LabMsg.Size = New System.Drawing.Size(25, 13)
        Me.LabMsg.TabIndex = 185
        Me.LabMsg.Text = "***"
        '
        'txtWBID
        '
        Me.txtWBID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWBID.Location = New System.Drawing.Point(668, 5)
        Me.txtWBID.Name = "txtWBID"
        Me.txtWBID.Properties.Appearance.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtWBID.Properties.Appearance.Options.UseFont = True
        Me.txtWBID.Properties.ReadOnly = True
        Me.txtWBID.Size = New System.Drawing.Size(127, 22)
        Me.txtWBID.TabIndex = 181
        '
        'PrintButton
        '
        Me.PrintButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrintButton.Appearance.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.PrintButton.Appearance.Options.UseFont = True
        Me.PrintButton.Image = Global.LFERP.My.Resources.Resources.PrintDialogAccess
        Me.PrintButton.Location = New System.Drawing.Point(442, 469)
        Me.PrintButton.Name = "PrintButton"
        Me.PrintButton.Size = New System.Drawing.Size(90, 30)
        Me.PrintButton.TabIndex = 186
        Me.PrintButton.Text = "還刀單(&P)"
        Me.PrintButton.Visible = False
        '
        'frmWareReturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 501)
        Me.Controls.Add(Me.PrintButton)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.txtWBID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabMsg)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmWareReturn"
        Me.Text = "frmWareReturn"
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popWareWB.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RemarkItemMemoExEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCalcEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QtyItemCalcEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MCodeText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemGridLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rtxtAP_NO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TxtReReturn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWBID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Remark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents popWareWB As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents popWareReturnAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popWareOutDel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents M_Code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents M_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents M_Gauge As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RemarkItemMemoExEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents Qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NoReturnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents QtyItemCalcEdit As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents MCodeText As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemButtonEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemButtonEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemGridLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents rtxtAP_NO As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ButtonEdit2 As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents sk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtWH As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents LabMsg As System.Windows.Forms.Label
    Friend WithEvents txtWBID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabReReturn As System.Windows.Forms.Label
    Friend WithEvents TxtReReturn As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents AutoID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoExEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents RepositoryItemCalcEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
    Friend WithEvents PrintButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents M_Unit As DevExpress.XtraGrid.Columns.GridColumn
End Class
